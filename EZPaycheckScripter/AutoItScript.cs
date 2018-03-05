using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EZPaycheckScripter
{
    public class AutoItScript
    {
        private StringBuilder scriptBuilder;
        private string windowVarName;

        public AutoItScript()
        {
            scriptBuilder = new StringBuilder();
            windowVarName = "$window"; 
        }

        public void AppendLine(string line)
        {
            scriptBuilder.AppendLine(line);
        }

        public void Run()
        {
            using (TextWriter writer = new StreamWriter("temp.au3"))
            {
                writer.Write(scriptBuilder.ToString());
            }
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("autoit3.exe", "temp.au3");
            startInfo.UseShellExecute = true;
            System.Diagnostics.Process.Start(startInfo);
        }

        public void SetDateControl(string controlName, DateTime value)
        {
            AppendLine("ControlFocus(" + windowVarName + ", \"\", \"[NAME:" + controlName + "]\")");
            AppendLine("Send(\"" + value.ToString("MM/dd/yyyy") + "\")");
        }

        public void SetTextBox(string controlName, double value)
        {
            SetTextBox(controlName, value.ToString("F2"));
        }

        public void SetTextBox(string controlName, decimal value)
        {
            SetTextBox(controlName, value.ToString("F2"));
        }

        private void SetTextBox(string controlName, string value)
        {
            AppendLine("ControlFocus(" + windowVarName + ", \"\", \"[NAME:" + controlName + "]\")");
            AppendLine("Send(\"" + value + "\")");
            //AppendLine("ControlSetText(" + windowVarName  + ", \"\", \"[NAME:" + controlName + "]\", \"" + value + "\")");
        }
    }
}
