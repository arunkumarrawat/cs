namespace RexPad
{
    partial class GoTo
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
            this.goToButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.lineTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // goToButton
            // 
            this.goToButton.Location = new System.Drawing.Point(94, 68);
            this.goToButton.Name = "goToButton";
            this.goToButton.Size = new System.Drawing.Size(75, 23);
            this.goToButton.TabIndex = 0;
            this.goToButton.Text = "Go To";
            this.goToButton.UseVisualStyleBackColor = true;
            this.goToButton.Click += new System.EventHandler(this.goToButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(175, 68);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // lineTextBox
            // 
            this.lineTextBox.Location = new System.Drawing.Point(12, 32);
            this.lineTextBox.Name = "lineTextBox";
            this.lineTextBox.Size = new System.Drawing.Size(238, 20);
            this.lineTextBox.TabIndex = 2;
            this.lineTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lineTextBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Line Number";
            // 
            // GoTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 102);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lineTextBox);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.goToButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoTo";
            this.Text = "Go To Line";
            this.Load += new System.EventHandler(this.GoTo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button goToButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox lineTextBox;
        private System.Windows.Forms.Label label1;
    }
}