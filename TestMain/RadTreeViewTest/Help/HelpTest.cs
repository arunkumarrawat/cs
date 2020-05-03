using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RadTreeViewTest.Help
{
    public partial class HelpTest : Form
    {
        public HelpTest()
        {
            InitializeComponent();
        }

        private void HelpTest_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowStyles[1].Height = 0;
        }

        private void HelpTest_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowStyles[1].Height = 36;
            tableLayoutPanel1.ColumnStyles[1].Width = 0;
        }
    }
}
