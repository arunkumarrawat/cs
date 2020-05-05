namespace PendingConfig
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
            this.btnPendingConfig = new Telerik.WinControls.UI.RadButton();
            this.btnStartDelete = new Telerik.WinControls.UI.RadButton();
            this.btnInsertData = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnPendingConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStartDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInsertData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPendingConfig
            // 
            this.btnPendingConfig.Location = new System.Drawing.Point(21, 192);
            this.btnPendingConfig.Name = "btnPendingConfig";
            this.btnPendingConfig.Size = new System.Drawing.Size(130, 24);
            this.btnPendingConfig.TabIndex = 2;
            this.btnPendingConfig.Text = "Start Pending";
            // 
            // btnStartDelete
            // 
            this.btnStartDelete.Location = new System.Drawing.Point(21, 130);
            this.btnStartDelete.Name = "btnStartDelete";
            this.btnStartDelete.Size = new System.Drawing.Size(130, 24);
            this.btnStartDelete.TabIndex = 1;
            this.btnStartDelete.Text = "Start Delete";
            this.btnStartDelete.Click += new System.EventHandler(this.btnStartDelete_Click);
            // 
            // btnInsertData
            // 
            this.btnInsertData.Location = new System.Drawing.Point(21, 68);
            this.btnInsertData.Name = "btnInsertData";
            this.btnInsertData.Size = new System.Drawing.Size(130, 24);
            this.btnInsertData.TabIndex = 0;
            this.btnInsertData.Text = "Insert Data";
            this.btnInsertData.Click += new System.EventHandler(this.btnInsertData_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 265);
            this.Controls.Add(this.btnInsertData);
            this.Controls.Add(this.btnStartDelete);
            this.Controls.Add(this.btnPendingConfig);
            this.Name = "MainForm";
            this.Text = "main";
            ((System.ComponentModel.ISupportInitialize)(this.btnPendingConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStartDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnInsertData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnPendingConfig;
        private Telerik.WinControls.UI.RadButton btnStartDelete;
        private Telerik.WinControls.UI.RadButton btnInsertData;
    }
}