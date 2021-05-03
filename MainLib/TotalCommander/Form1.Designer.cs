namespace TotalCommander
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
            this.fileGridViewB = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pathB = new System.Windows.Forms.TextBox();
            this.upB = new System.Windows.Forms.Button();
            this.upA = new System.Windows.Forms.Button();
            this.pathA = new System.Windows.Forms.TextBox();
            this.fileListGridA = new System.Windows.Forms.DataGridView();
            this.btnMoveToB = new System.Windows.Forms.Button();
            this.btnMoveToA = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileGridViewB)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileListGridA)).BeginInit();
            this.SuspendLayout();
            // 
            // fileGridViewB
            // 
            this.fileGridViewB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileGridViewB.Location = new System.Drawing.Point(388, 167);
            this.fileGridViewB.Name = "fileGridViewB";
            this.fileGridViewB.Size = new System.Drawing.Size(240, 150);
            this.fileGridViewB.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(727, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // pathB
            // 
            this.pathB.Location = new System.Drawing.Point(388, 122);
            this.pathB.Name = "pathB";
            this.pathB.Size = new System.Drawing.Size(190, 20);
            this.pathB.TabIndex = 4;
            // 
            // upB
            // 
            this.upB.Location = new System.Drawing.Point(585, 122);
            this.upB.Name = "upB";
            this.upB.Size = new System.Drawing.Size(43, 20);
            this.upB.TabIndex = 5;
            this.upB.Text = "up";
            this.upB.UseVisualStyleBackColor = true;
            // 
            // upA
            // 
            this.upA.Location = new System.Drawing.Point(273, 123);
            this.upA.Name = "upA";
            this.upA.Size = new System.Drawing.Size(39, 20);
            this.upA.TabIndex = 8;
            this.upA.Text = "up";
            this.upA.UseVisualStyleBackColor = true;
            // 
            // pathA
            // 
            this.pathA.Location = new System.Drawing.Point(72, 123);
            this.pathA.Name = "pathA";
            this.pathA.Size = new System.Drawing.Size(194, 20);
            this.pathA.TabIndex = 7;
            this.pathA.TextChanged += new System.EventHandler(this.pathA_TextChanged);
            // 
            // fileListGridA
            // 
            this.fileListGridA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.fileListGridA.Location = new System.Drawing.Point(72, 168);
            this.fileListGridA.Name = "fileListGridA";
            this.fileListGridA.Size = new System.Drawing.Size(240, 150);
            this.fileListGridA.TabIndex = 6;
            // 
            // btnMoveToB
            // 
            this.btnMoveToB.Location = new System.Drawing.Point(318, 204);
            this.btnMoveToB.Name = "btnMoveToB";
            this.btnMoveToB.Size = new System.Drawing.Size(63, 23);
            this.btnMoveToB.TabIndex = 9;
            this.btnMoveToB.Text = ">>";
            this.btnMoveToB.UseVisualStyleBackColor = true;
            // 
            // btnMoveToA
            // 
            this.btnMoveToA.Location = new System.Drawing.Point(318, 246);
            this.btnMoveToA.Name = "btnMoveToA";
            this.btnMoveToA.Size = new System.Drawing.Size(63, 23);
            this.btnMoveToA.TabIndex = 10;
            this.btnMoveToA.Text = "<<";
            this.btnMoveToA.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 503);
            this.Controls.Add(this.btnMoveToA);
            this.Controls.Add(this.btnMoveToB);
            this.Controls.Add(this.upA);
            this.Controls.Add(this.pathA);
            this.Controls.Add(this.fileListGridA);
            this.Controls.Add(this.upB);
            this.Controls.Add(this.pathB);
            this.Controls.Add(this.fileGridViewB);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileGridViewB)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileListGridA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView fileGridViewB;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox pathB;
        private System.Windows.Forms.Button upB;
        private System.Windows.Forms.Button upA;
        private System.Windows.Forms.TextBox pathA;
        private System.Windows.Forms.DataGridView fileListGridA;
        private System.Windows.Forms.Button btnMoveToB;
        private System.Windows.Forms.Button btnMoveToA;
    }
}

