using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlashGet2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //fgTreeView.Nodes.Add("Dwget");
            //fgTreeView.Nodes.Add("Downloading");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout fabout = new frmAbout();
            fabout.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
