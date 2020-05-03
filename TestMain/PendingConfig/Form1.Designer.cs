namespace PendingConfig
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn1 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            this.radGridView = new Telerik.WinControls.UI.RadGridView();
            this.radToggleButton1 = new Telerik.WinControls.UI.RadToggleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cSplitButton1 = new PendingConfig.CSplitButton();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem2 = new Telerik.WinControls.UI.RadMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToggleButton1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cSplitButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // radGridView
            // 
            this.radGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGridView.Location = new System.Drawing.Point(3, 3);
            // 
            // radGridView
            // 
            this.radGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "Id";
            gridViewTextBoxColumn1.HeaderText = "Id";
            gridViewTextBoxColumn1.MaxWidth = 200;
            gridViewTextBoxColumn1.MinWidth = 100;
            gridViewTextBoxColumn1.Name = "Id";
            gridViewTextBoxColumn1.Width = 200;
            gridViewCheckBoxColumn1.FieldName = "Approve";
            gridViewCheckBoxColumn1.HeaderText = "Approve";
            gridViewCheckBoxColumn1.MaxWidth = 100;
            gridViewCheckBoxColumn1.MinWidth = 50;
            gridViewCheckBoxColumn1.Name = "Approve";
            gridViewCheckBoxColumn1.Width = 100;
            gridViewDateTimeColumn1.FieldName = "ApprovedDate";
            gridViewDateTimeColumn1.HeaderText = "ApprovedDate";
            gridViewDateTimeColumn1.MaxWidth = 100;
            gridViewDateTimeColumn1.MinWidth = 50;
            gridViewDateTimeColumn1.Name = "ApprovedDate";
            gridViewDateTimeColumn1.Width = 100;
            gridViewImageColumn1.FieldName = "ProgressBar";
            gridViewImageColumn1.HeaderText = "ProgressBar";
            gridViewImageColumn1.MaxWidth = 200;
            gridViewImageColumn1.MinWidth = 100;
            gridViewImageColumn1.Name = "ProgressBar";
            gridViewImageColumn1.Width = 119;
            gridViewCommandColumn1.MaxWidth = 100;
            gridViewCommandColumn1.MinWidth = 50;
            gridViewCommandColumn1.Name = "column3";
            gridViewCommandColumn1.Width = 100;
            this.radGridView.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewCheckBoxColumn1,
            gridViewDateTimeColumn1,
            gridViewImageColumn1,
            gridViewCommandColumn1});
            this.radGridView.Name = "radGridView";
            this.radGridView.Size = new System.Drawing.Size(636, 248);
            this.radGridView.TabIndex = 0;
            this.radGridView.Text = "radGridView1";
            this.radGridView.ValueChanged += new System.EventHandler(this.radGridView_ValueChanged);
            // 
            // radToggleButton1
            // 
            this.radToggleButton1.Location = new System.Drawing.Point(109, 3);
            this.radToggleButton1.Name = "radToggleButton1";
            this.radToggleButton1.Size = new System.Drawing.Size(100, 23);
            this.radToggleButton1.TabIndex = 1;
            this.radToggleButton1.Text = "radToggleButton1";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.radGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(642, 299);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.radToggleButton1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(426, 257);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(213, 39);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // cSplitButton1
            // 
            this.cSplitButton1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1,
            this.radMenuItem2});
            this.cSplitButton1.Location = new System.Drawing.Point(3, 3);
            this.cSplitButton1.Name = "cSplitButton1";
            this.cSplitButton1.Size = new System.Drawing.Size(100, 33);
            this.cSplitButton1.TabIndex = 0;
            this.cSplitButton1.Text = "cSplitButton1";
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.AccessibleDescription = "radMenuItem1";
            this.radMenuItem1.AccessibleName = "radMenuItem1";
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "radMenuItem1";
            this.radMenuItem1.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            this.radMenuItem1.Click += new System.EventHandler(this.radMenuItem1_Click);
            // 
            // radMenuItem2
            // 
            this.radMenuItem2.AccessibleDescription = "radMenuItem2";
            this.radMenuItem2.AccessibleName = "radMenuItem2";
            this.radMenuItem2.Name = "radMenuItem2";
            this.radMenuItem2.Text = "radMenuItem2";
            this.radMenuItem2.Visibility = Telerik.WinControls.ElementVisibility.Visible;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 299);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGridView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radToggleButton1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cSplitButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView radGridView;
        private Telerik.WinControls.UI.RadToggleButton radToggleButton1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private CSplitButton cSplitButton1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem2;
    }
}

