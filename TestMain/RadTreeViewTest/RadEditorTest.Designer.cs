namespace RadTreeViewTest
{
    partial class RadEditorTest
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
            this.radMBTest = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.rckEnable = new Telerik.WinControls.UI.RadCheckBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radMBTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rckEnable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // radMBTest
            // 
            this.radMBTest.AllowPromptAsInput = false;
            this.radMBTest.AutoSize = true;
            this.radMBTest.Culture = null;
            this.radMBTest.Location = new System.Drawing.Point(46, 112);
            this.radMBTest.Mask = "##:##";
            this.radMBTest.Name = "radMBTest";
            this.radMBTest.Size = new System.Drawing.Size(55, 20);
            this.radMBTest.TabIndex = 0;
            this.radMBTest.TabStop = false;
            this.radMBTest.Text = "__:__";
            this.radMBTest.Value = "__:__";
            // 
            // rckEnable
            // 
            this.rckEnable.Location = new System.Drawing.Point(46, 88);
            this.rckEnable.Name = "rckEnable";
            this.rckEnable.Size = new System.Drawing.Size(53, 18);
            this.rckEnable.TabIndex = 1;
            this.rckEnable.Text = "Enable";
            this.rckEnable.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.rckEnable_ToggleStateChanged);
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(132, 112);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(78, 24);
            this.radButton1.TabIndex = 2;
            this.radButton1.Text = "radButton1";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // RadEditorTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 285);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.rckEnable);
            this.Controls.Add(this.radMBTest);
            this.Name = "RadEditorTest";
            this.Text = "RadEditorTest";
            ((System.ComponentModel.ISupportInitialize)(this.radMBTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rckEnable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadMaskedEditBox radMBTest;
        private Telerik.WinControls.UI.RadCheckBox rckEnable;
        private Telerik.WinControls.UI.RadButton radButton1;

    }
}