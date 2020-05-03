namespace PropertyGridTest
{
    partial class ColorPanel
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.btnMore = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Location = new System.Drawing.Point(10, 15);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(70, 25);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Location = new System.Drawing.Point(10, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(31, 25);
            this.panel2.TabIndex = 1;
            this.panel2.Click += new System.EventHandler(this.panel_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Yellow;
            this.panel3.Location = new System.Drawing.Point(49, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(31, 25);
            this.panel3.TabIndex = 2;
            this.panel3.Click += new System.EventHandler(this.panel_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Green;
            this.panel4.Location = new System.Drawing.Point(10, 77);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(31, 25);
            this.panel4.TabIndex = 1;
            this.panel4.Click += new System.EventHandler(this.panel_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Blue;
            this.panel5.Location = new System.Drawing.Point(47, 77);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(31, 25);
            this.panel5.TabIndex = 3;
            this.panel5.Click += new System.EventHandler(this.panel_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Orange;
            this.panel6.Location = new System.Drawing.Point(10, 108);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(31, 25);
            this.panel6.TabIndex = 4;
            this.panel6.Click += new System.EventHandler(this.panel_Click);
            // 
            // btnMore
            // 
            this.btnMore.Location = new System.Drawing.Point(10, 139);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(70, 23);
            this.btnMore.TabIndex = 5;
            this.btnMore.Text = "More";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Black;
            this.panel7.Location = new System.Drawing.Point(47, 108);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(31, 25);
            this.panel7.TabIndex = 5;
            this.panel7.Click += new System.EventHandler(this.panel_Click);
            // 
            // ColorPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.btnMore);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ColorPanel";
            this.Size = new System.Drawing.Size(90, 186);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Panel panel7;
    }
}
