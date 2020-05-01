using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EZPaycheckScripter
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            pickerPeriodStart.Value = DateTime.Today;
            pickerPeriodEnd.Value = DateTime.Today;
            pickerPayDate.Value = DateTime.Today;
        }

        private void txtPayrollData_TextChanged(object sender, EventArgs e)
        {
            lstParsedPaychecks.Items.Clear();
            string[] lines = txtPayrollData.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                string[] fields = line.Split('\t');
                if (fields.Length > 1)
                {
                    if (fields.Length != 4)
                    {
                        MessageBox.Show("Invalid number of fields in line");
                        return;
                    }
                    string fullName = fields[0];
                    int firstSpace = fullName.IndexOf(' ');
                    string firstName = fullName.Substring(0, firstSpace);
                    string lastName = fullName.Substring(firstSpace + 1);
                    int firstDot = lastName.IndexOf('.');
                    if (firstDot > 0)
                    {
                        lastName = lastName.Substring(firstDot + 2);
                    }
                    Paycheck check = new Paycheck();
                    check.NameLastFirst = lastName + ", " + firstName;
                    try
                    {
                        check.HoursRegular = double.Parse(fields[1]);
                        check.HoursOT = double.Parse(fields[2]);
                        check.HoursOther = double.Parse(fields[3]);
                        check.TaxOther = (decimal)((check.HoursRegular + check.HoursOT + check.HoursOther) * 0.033 / 2.0);
                    }
                    catch
                    {
                        MessageBox.Show("Error parsing hours");
                        return;
                    }
                    lstParsedPaychecks.Items.Add(check);
                }
            }
        }

        private void btnCreateScript_Click(object sender, EventArgs e)
        {
            if (pickerPeriodStart.Value.Year < 2000 ||
                pickerPeriodEnd.Value.Year < 2000 ||
                pickerPayDate.Value.Year < 2000)
            {
                MessageBox.Show("Missing date(s)");
                return;
            }
            if (pickerPeriodEnd.Value <= pickerPeriodStart.Value)
            {
                MessageBox.Show("Period end must be after period start");
                return;
            }
            if (pickerPayDate.Value <= pickerPeriodEnd.Value)
            {
                MessageBox.Show("Pay date end must be after period end");
                return;
            }

            int paycheckCount = 0;
            AutoItScript script = new AutoItScript();
            script.AppendLine("#include \"MsgBoxConstants.au3\"");
            script.AppendLine("Local $empName");
            script.AppendLine("Local $empNameOld");

            foreach (Paycheck check in lstParsedPaychecks.Items)
            {
                check.PayDate = pickerPayDate.Value;
                if (check.PeriodStartDate != pickerPeriodStart.Value)
                {
                    MessageBox.Show("Invalid period start date");
                    return;
                }
                if (check.PeriodEndDate != pickerPeriodEnd.Value)
                {
                    MessageBox.Show("Invalid period end date");
                    return;
                }
                paycheckCount++;
                script.AppendLine("Local $window = WinWaitActive(\"ezPayCheck 202\", \"List Checks After\")");
                CreatePaycheck(script, check);
            }

            if (paycheckCount > 0)
            {
                script.Run();
                MessageBox.Show("Script started. Script will add a paycheck each time the \"Check List\" " + 
                    "window becomes active in ezPaycheck, and wait for you to save or cancel that check.");
            }
            else
            {
                MessageBox.Show("No paychecks.");
            }
        }


        private void CreatePaycheck(AutoItScript script, Paycheck check)
        {
            script.AppendLine("ControlClick($window,\"\",\"[NAME:button3]\")");  //Click the "Add" button
            script.AppendLine("$window = WinWaitActive(\"Payroll Data Input\", \"\")");
            script.AppendLine("ControlCommand($window, \"\", \"[NAME: cboEmployees]\",\"ShowDropDown\")");
            script.AppendLine("$empNameOld=\"\"");
            script.AppendLine("While -1");
            script.AppendLine("    $empName = ControlGetText($window, \"\", \"[NAME:cboEmployees]\")");
            script.AppendLine("    If $empName == $empNameOld Then");
            script.AppendLine("        MsgBox($MB_OK, \"Error\", \"Could not find employee\")");
            script.AppendLine("        Exit");
            script.AppendLine("    EndIf");
            script.AppendLine("    If $empName == \"" + check.NameLastFirst + "\" Then");
            script.AppendLine("        ExitLoop");
            script.AppendLine("    EndIf");
            script.AppendLine("    $empNameOld = $empName");
            script.AppendLine("    Send(\"{DOWN}\")");
            script.AppendLine("Wend");

            script.SetDateControl("dtpPayrollDate", check.PayDate);
            script.SetDateControl("dtpStartDate", check.PeriodStartDate);
            script.SetDateControl("dtpEndDate", check.PeriodEndDate);

            //script.SetTextBox("txtPayHourly", check.RateRegular);
            //script.SetTextBox("txtOTMultiplier", check.RateOT);
            //script.SetTextBox("txtPayHourlySick", check.RateRegular);
            //script.SetTextBox("txtPayHourlyVacation", check.RateRegular);

            script.SetTextBox("txtHrsRegular", check.HoursRegular);
            script.SetTextBox("txtHrsOT", check.HoursOT);
            script.SetTextBox("txtHrsSick", check.HoursOther);

            script.SetTextBox("txtUDPay1Val", check.EarningsBonus);
            script.SetTextBox("txtUD3Input", check.TaxOther);

            script.AppendLine("ControlClick($window,\"\",\"[NAME:btnCalculateCheck]\")");
            script.AppendLine("MsgBox($MB_OK, \"debug\", \"Paycheck entered for - \" & $empName )");
            //script.AppendLine("ControlClick($window,\"\",\"[NAME:btnSaveCheck]\")");
        }
    }
}
