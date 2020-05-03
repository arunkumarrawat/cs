namespace RadTreeViewTest
{
    partial class TreeView_LoadOnDemand
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
            this.radTreeView1 = new Telerik.WinControls.UI.RadTreeView();
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).BeginInit();
            this.SuspendLayout();
            // 
            // radTreeView1
            // 
            this.radTreeView1.ExpandAnimation = Telerik.WinControls.UI.ExpandAnimation.None;
            this.radTreeView1.Location = new System.Drawing.Point(30, 34);
            this.radTreeView1.Name = "radTreeView1";
            this.radTreeView1.Size = new System.Drawing.Size(251, 384);
            this.radTreeView1.SpacingBetweenNodes = -1;
            this.radTreeView1.TabIndex = 0;
            this.radTreeView1.Text = "radTreeView1";
            this.radTreeView1.NodesNeeded += new Telerik.WinControls.UI.NodesNeededEventHandler(this.radTreeView1_NodesNeeded);
            // 
            // TreeView_LoadOnDemand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 451);
            this.Controls.Add(this.radTreeView1);
            this.Name = "TreeView_LoadOnDemand";
            this.Text = "TreeView_LoadOnDemand";
            ((System.ComponentModel.ISupportInitialize)(this.radTreeView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTreeView radTreeView1;
    }
}