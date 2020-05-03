namespace RadTreeViewTest.TimeSchedule
{
    partial class TimeScheduleCell
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.radCheckBox1 = new Telerik.WinControls.UI.RadCheckBox();
            this.radMaskedEditBox1 = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMaskedEditBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.radCheckBox1);
            this.panel1.Controls.Add(this.radMaskedEditBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 50);
            this.panel1.TabIndex = 0;
            // 
            // radCheckBox1
            // 
            this.radCheckBox1.Location = new System.Drawing.Point(17, 29);
            this.radCheckBox1.Name = "radCheckBox1";
            this.radCheckBox1.Size = new System.Drawing.Size(91, 18);
            this.radCheckBox1.TabIndex = 2;
            this.radCheckBox1.Text = "radCheckBox1";
            // 
            // radMaskedEditBox1
            // 
            this.radMaskedEditBox1.Location = new System.Drawing.Point(4, 4);
            this.radMaskedEditBox1.Name = "radMaskedEditBox1";
            this.radMaskedEditBox1.Size = new System.Drawing.Size(52, 20);
            this.radMaskedEditBox1.TabIndex = 0;
            this.radMaskedEditBox1.TabStop = false;
            this.radMaskedEditBox1.Text = "radMaskedEditBox1";
            // 
            // TimeScheduleCell
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panel1);
            this.Name = "TimeScheduleCell";
            this.Size = new System.Drawing.Size(134, 50);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radCheckBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMaskedEditBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadMaskedEditBox radMaskedEditBox1;
        private Telerik.WinControls.UI.RadCheckBox radCheckBox1;
    }
}
