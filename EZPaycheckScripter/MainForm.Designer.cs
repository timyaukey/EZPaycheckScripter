namespace EZPaycheckScripter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblPasteData = new System.Windows.Forms.Label();
            this.txtPayrollData = new System.Windows.Forms.TextBox();
            this.lblParsedPaychecks = new System.Windows.Forms.Label();
            this.lstParsedPaychecks = new System.Windows.Forms.ListBox();
            this.pickerPayDate = new System.Windows.Forms.DateTimePicker();
            this.lblPayDate = new System.Windows.Forms.Label();
            this.lblPeriodStart = new System.Windows.Forms.Label();
            this.pickerPeriodStart = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodEnd = new System.Windows.Forms.Label();
            this.pickerPeriodEnd = new System.Windows.Forms.DateTimePicker();
            this.btnCreateScript = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPasteData
            // 
            this.lblPasteData.AutoSize = true;
            this.lblPasteData.Location = new System.Drawing.Point(12, 9);
            this.lblPasteData.Name = "lblPasteData";
            this.lblPasteData.Size = new System.Drawing.Size(120, 13);
            this.lblPasteData.TabIndex = 0;
            this.lblPasteData.Text = "Paste Payroll Data Here";
            // 
            // txtPayrollData
            // 
            this.txtPayrollData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPayrollData.Location = new System.Drawing.Point(12, 25);
            this.txtPayrollData.Multiline = true;
            this.txtPayrollData.Name = "txtPayrollData";
            this.txtPayrollData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPayrollData.Size = new System.Drawing.Size(573, 170);
            this.txtPayrollData.TabIndex = 1;
            this.txtPayrollData.TextChanged += new System.EventHandler(this.txtPayrollData_TextChanged);
            // 
            // lblParsedPaychecks
            // 
            this.lblParsedPaychecks.AutoSize = true;
            this.lblParsedPaychecks.Location = new System.Drawing.Point(15, 202);
            this.lblParsedPaychecks.Name = "lblParsedPaychecks";
            this.lblParsedPaychecks.Size = new System.Drawing.Size(96, 13);
            this.lblParsedPaychecks.TabIndex = 2;
            this.lblParsedPaychecks.Text = "Parsed Paychecks";
            // 
            // lstParsedPaychecks
            // 
            this.lstParsedPaychecks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstParsedPaychecks.FormattingEnabled = true;
            this.lstParsedPaychecks.IntegralHeight = false;
            this.lstParsedPaychecks.Location = new System.Drawing.Point(12, 218);
            this.lstParsedPaychecks.Name = "lstParsedPaychecks";
            this.lstParsedPaychecks.Size = new System.Drawing.Size(573, 182);
            this.lstParsedPaychecks.TabIndex = 3;
            // 
            // pickerPayDate
            // 
            this.pickerPayDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pickerPayDate.CustomFormat = "";
            this.pickerPayDate.Location = new System.Drawing.Point(77, 458);
            this.pickerPayDate.Name = "pickerPayDate";
            this.pickerPayDate.Size = new System.Drawing.Size(200, 20);
            this.pickerPayDate.TabIndex = 9;
            this.pickerPayDate.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            // 
            // lblPayDate
            // 
            this.lblPayDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPayDate.AutoSize = true;
            this.lblPayDate.Location = new System.Drawing.Point(9, 464);
            this.lblPayDate.Name = "lblPayDate";
            this.lblPayDate.Size = new System.Drawing.Size(51, 13);
            this.lblPayDate.TabIndex = 8;
            this.lblPayDate.Text = "Pay Date";
            // 
            // lblPeriodStart
            // 
            this.lblPeriodStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPeriodStart.AutoSize = true;
            this.lblPeriodStart.Location = new System.Drawing.Point(9, 412);
            this.lblPeriodStart.Name = "lblPeriodStart";
            this.lblPeriodStart.Size = new System.Drawing.Size(62, 13);
            this.lblPeriodStart.TabIndex = 4;
            this.lblPeriodStart.Text = "Period Start";
            // 
            // pickerPeriodStart
            // 
            this.pickerPeriodStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pickerPeriodStart.CustomFormat = "";
            this.pickerPeriodStart.Location = new System.Drawing.Point(77, 406);
            this.pickerPeriodStart.Name = "pickerPeriodStart";
            this.pickerPeriodStart.Size = new System.Drawing.Size(200, 20);
            this.pickerPeriodStart.TabIndex = 5;
            this.pickerPeriodStart.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            // 
            // lblPeriodEnd
            // 
            this.lblPeriodEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPeriodEnd.AutoSize = true;
            this.lblPeriodEnd.Location = new System.Drawing.Point(9, 438);
            this.lblPeriodEnd.Name = "lblPeriodEnd";
            this.lblPeriodEnd.Size = new System.Drawing.Size(59, 13);
            this.lblPeriodEnd.TabIndex = 6;
            this.lblPeriodEnd.Text = "Period End";
            // 
            // pickerPeriodEnd
            // 
            this.pickerPeriodEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pickerPeriodEnd.CustomFormat = "";
            this.pickerPeriodEnd.Location = new System.Drawing.Point(77, 432);
            this.pickerPeriodEnd.Name = "pickerPeriodEnd";
            this.pickerPeriodEnd.Size = new System.Drawing.Size(200, 20);
            this.pickerPeriodEnd.TabIndex = 7;
            this.pickerPeriodEnd.Value = new System.DateTime(1980, 1, 1, 0, 0, 0, 0);
            // 
            // btnCreateScript
            // 
            this.btnCreateScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateScript.Location = new System.Drawing.Point(370, 454);
            this.btnCreateScript.Name = "btnCreateScript";
            this.btnCreateScript.Size = new System.Drawing.Size(215, 23);
            this.btnCreateScript.TabIndex = 10;
            this.btnCreateScript.Text = "Create ezPaycheck AutoIt Script";
            this.btnCreateScript.UseVisualStyleBackColor = true;
            this.btnCreateScript.Click += new System.EventHandler(this.btnCreateScript_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 489);
            this.Controls.Add(this.btnCreateScript);
            this.Controls.Add(this.lblPeriodEnd);
            this.Controls.Add(this.pickerPeriodEnd);
            this.Controls.Add(this.lblPeriodStart);
            this.Controls.Add(this.pickerPeriodStart);
            this.Controls.Add(this.lblPayDate);
            this.Controls.Add(this.pickerPayDate);
            this.Controls.Add(this.lstParsedPaychecks);
            this.Controls.Add(this.lblParsedPaychecks);
            this.Controls.Add(this.txtPayrollData);
            this.Controls.Add(this.lblPasteData);
            this.Name = "MainForm";
            this.Text = "ezPaycheck AutoIt Scripter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPasteData;
        private System.Windows.Forms.TextBox txtPayrollData;
        private System.Windows.Forms.Label lblParsedPaychecks;
        private System.Windows.Forms.ListBox lstParsedPaychecks;
        private System.Windows.Forms.DateTimePicker pickerPayDate;
        private System.Windows.Forms.Label lblPayDate;
        private System.Windows.Forms.Label lblPeriodStart;
        private System.Windows.Forms.DateTimePicker pickerPeriodStart;
        private System.Windows.Forms.Label lblPeriodEnd;
        private System.Windows.Forms.DateTimePicker pickerPeriodEnd;
        private System.Windows.Forms.Button btnCreateScript;
    }
}

