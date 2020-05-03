namespace LispWindows
{
    partial class Form1
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
            this.listBox = new System.Windows.Forms.ListBox();
            this.btnEval = new System.Windows.Forms.Button();
            this.txtEval = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 12;
            this.listBox.Location = new System.Drawing.Point(12, 11);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(195, 352);
            this.listBox.TabIndex = 0;
            // 
            // btnEval
            // 
            this.btnEval.Location = new System.Drawing.Point(231, 342);
            this.btnEval.Name = "btnEval";
            this.btnEval.Size = new System.Drawing.Size(75, 21);
            this.btnEval.TabIndex = 1;
            this.btnEval.Text = "&Eval";
            this.btnEval.UseVisualStyleBackColor = true;
            this.btnEval.Click += new System.EventHandler(this.btnEval_Click);
            // 
            // txtEval
            // 
            this.txtEval.Location = new System.Drawing.Point(231, 11);
            this.txtEval.Multiline = true;
            this.txtEval.Name = "txtEval";
            this.txtEval.Size = new System.Drawing.Size(257, 316);
            this.txtEval.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(360, 341);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 21);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 384);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtEval);
            this.Controls.Add(this.btnEval);
            this.Controls.Add(this.listBox);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button btnEval;
        private System.Windows.Forms.TextBox txtEval;
        private System.Windows.Forms.Button btnSave;
    }
}

