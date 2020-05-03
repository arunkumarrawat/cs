namespace RadTreeViewTest
{
    partial class TreeView_Performance
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
            this.radTreeViewDemo = new Telerik.WinControls.UI.RadTreeView();
            this.radBtnLoad = new Telerik.WinControls.UI.RadButton();
            this.radProgressBar1 = new Telerik.WinControls.UI.RadProgressBar();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeViewDemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.SuspendLayout();
            // 
            // radTreeViewDemo
            // 
            this.radTreeViewDemo.AllowAdd = true;
            this.radTreeViewDemo.AllowDefaultContextMenu = true;
            this.radTreeViewDemo.AllowEdit = true;
            this.radTreeViewDemo.AllowRemove = true;
            this.radTreeViewDemo.Location = new System.Drawing.Point(12, 29);
            this.radTreeViewDemo.Name = "radTreeViewDemo";
            this.radTreeViewDemo.Size = new System.Drawing.Size(236, 312);
            this.radTreeViewDemo.SpacingBetweenNodes = -1;
            this.radTreeViewDemo.TabIndex = 0;
            this.radTreeViewDemo.Text = "radTreeView1";
            // 
            // radBtnLoad
            // 
            this.radBtnLoad.Location = new System.Drawing.Point(287, 29);
            this.radBtnLoad.Name = "radBtnLoad";
            this.radBtnLoad.Size = new System.Drawing.Size(130, 26);
            this.radBtnLoad.TabIndex = 1;
            this.radBtnLoad.Text = "Load 5000 Node";
            this.radBtnLoad.Click += new System.EventHandler(this.radBtnLoad_Click);
            // 
            // radProgressBar1
            // 
            this.radProgressBar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radProgressBar1.ImageIndex = -1;
            this.radProgressBar1.ImageKey = "";
            this.radProgressBar1.ImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.radProgressBar1.Location = new System.Drawing.Point(265, 62);
            this.radProgressBar1.Name = "radProgressBar1";
            this.radProgressBar1.SeparatorColor1 = System.Drawing.Color.White;
            this.radProgressBar1.SeparatorColor2 = System.Drawing.Color.White;
            this.radProgressBar1.SeparatorColor3 = System.Drawing.Color.White;
            this.radProgressBar1.SeparatorColor4 = System.Drawing.Color.White;
            this.radProgressBar1.Size = new System.Drawing.Size(167, 25);
            this.radProgressBar1.TabIndex = 2;
            this.radProgressBar1.Text = "radProgressBar1";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(287, 106);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(57, 16);
            this.radLabel1.TabIndex = 3;
            this.radLabel1.Text = "radLabel1";
            // 
            // TreeView_Performance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 372);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radProgressBar1);
            this.Controls.Add(this.radBtnLoad);
            this.Controls.Add(this.radTreeViewDemo);
            this.Name = "TreeView_Performance";
            this.Text = "TreeView_Performance";
            ((System.ComponentModel.ISupportInitialize)(this.radTreeViewDemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radBtnLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTreeView radTreeViewDemo;
        private Telerik.WinControls.UI.RadButton radBtnLoad;
        private Telerik.WinControls.UI.RadProgressBar radProgressBar1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}