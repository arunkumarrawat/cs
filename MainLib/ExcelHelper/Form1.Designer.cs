namespace ExcelHelper
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTimeSheetCSVFile = new System.Windows.Forms.TextBox();
            this.txtDateCSVFile = new System.Windows.Forms.TextBox();
            this.btnTimeSheetInput = new System.Windows.Forms.Button();
            this.btnDate = new System.Windows.Forms.Button();
            this.btnConverter = new System.Windows.Forms.Button();
            this.txtOutputFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtTimeSheetCSVFile
            // 
            this.txtTimeSheetCSVFile.Location = new System.Drawing.Point(148, 92);
            this.txtTimeSheetCSVFile.Name = "txtTimeSheetCSVFile";
            this.txtTimeSheetCSVFile.Size = new System.Drawing.Size(238, 23);
            this.txtTimeSheetCSVFile.TabIndex = 0;
            // 
            // txtDateCSVFile
            // 
            this.txtDateCSVFile.Location = new System.Drawing.Point(150, 133);
            this.txtDateCSVFile.Name = "txtDateCSVFile";
            this.txtDateCSVFile.Size = new System.Drawing.Size(236, 23);
            this.txtDateCSVFile.TabIndex = 1;
            // 
            // btnTimeSheetInput
            // 
            this.btnTimeSheetInput.Location = new System.Drawing.Point(408, 92);
            this.btnTimeSheetInput.Name = "btnTimeSheetInput";
            this.btnTimeSheetInput.Size = new System.Drawing.Size(75, 23);
            this.btnTimeSheetInput.TabIndex = 2;
            this.btnTimeSheetInput.Text = "Time Sheet";
            this.btnTimeSheetInput.UseVisualStyleBackColor = true;
            this.btnTimeSheetInput.Click += new System.EventHandler(this.btnTimeSheetInput_Click);
            // 
            // btnDate
            // 
            this.btnDate.Location = new System.Drawing.Point(408, 132);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(75, 23);
            this.btnDate.TabIndex = 3;
            this.btnDate.Text = "Date";
            this.btnDate.UseVisualStyleBackColor = true;
            this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
            // 
            // btnConverter
            // 
            this.btnConverter.Location = new System.Drawing.Point(150, 216);
            this.btnConverter.Name = "btnConverter";
            this.btnConverter.Size = new System.Drawing.Size(75, 23);
            this.btnConverter.TabIndex = 4;
            this.btnConverter.Text = "Generate";
            this.btnConverter.UseVisualStyleBackColor = true;
            this.btnConverter.Click += new System.EventHandler(this.btnConverter_Click);
            // 
            // txtOutputFile
            // 
            this.txtOutputFile.Location = new System.Drawing.Point(150, 170);
            this.txtOutputFile.Name = "txtOutputFile";
            this.txtOutputFile.Size = new System.Drawing.Size(236, 23);
            this.txtOutputFile.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(408, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Output";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 324);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOutputFile);
            this.Controls.Add(this.btnConverter);
            this.Controls.Add(this.btnDate);
            this.Controls.Add(this.btnTimeSheetInput);
            this.Controls.Add(this.txtDateCSVFile);
            this.Controls.Add(this.txtTimeSheetCSVFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txtTimeSheetCSVFile;
        private TextBox txtDateCSVFile;
        private Button btnTimeSheetInput;
        private Button btnDate;
        private Button btnConverter;
        private TextBox txtOutputFile;
        private Label label1;
    }
}