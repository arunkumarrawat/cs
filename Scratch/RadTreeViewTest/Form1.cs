using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using RadTreeViewTest.RadButton;

namespace RadTreeViewTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            RadMenuItem item = new RadMenuItem("None");
            item.Click += new EventHandler(item_Click);
            this.radDropDownButton1.Items.Add(item);

            item = new RadMenuItem("Alphabetically");
            item.Click += new EventHandler(item_Click);
            this.radDropDownButton1.Items.Add(item);
        }

        private void item_Click(object sender, EventArgs e)
        {
            RadMenuItem item = (RadMenuItem)sender;
            this.radDropDownButton1.Text = item.Text;
            if (item.Text == "None")
            {
                radTreeView1.SortOrder = SortOrder.None;
                
            }
            else
            {
                radTreeView1.SortOrder = SortOrder.Ascending;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RadTreeNode root = this.radTreeView1.Nodes.Add("Programming");
            root.Nodes.Add("Microsoft Research News and Highlights");
            root.Nodes.Add("Joel on Software");
            root.Nodes.Add("Miguel de Icaza");
            root.Nodes.Add("channel 9");

            root = this.radTreeView1.Nodes.Add("News (1)");
            root.Nodes.Add("cnn.com (1)");
            root.Nodes.Add("msnbc.com");
            root.Nodes.Add("reuters.com");
            root.Nodes.Add("bbc.co.uk");

            root = this.radTreeView1.Nodes.Add("Personal (19)");
            root.Nodes.Add("sports (2)");
            RadTreeNode folder = root.Nodes.Add("fun (17)");
            folder.Nodes.Add("Lolcats (2)");
            folder.Nodes.Add("FFFOUND (15)");

            this.radTreeView1.Nodes.Add("Telerik blogs");
            this.radTreeView1.Nodes.Add("Techcrunch");
            this.radTreeView1.Nodes.Add("Engadget");
        }

        private void performanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeView_Performance tp = new TreeView_Performance();
            tp.ShowDialog();
        }

        private void loadOnDesmondToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeView_LoadOnDemand tl = new TreeView_LoadOnDemand();
            tl.ShowDialog();
        }

        private void stripButtonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Container_Grid g = new Container_Grid();
            //g.ShowDialog();
        }

        private void multiThreadLockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiThreadLock mtl = new MultiThreadLock();
            mtl.ShowDialog();
        }

        private void radListTestToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RadListTest rlt = new RadListTest();
            rlt.ShowDialog();
        }

        private void splitGridCalendarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SplitGrid_Calendar sgc = new SplitGrid_Calendar();

            sgc.ShowDialog();
        }

        private void radButtonTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RadButtonTest rbt = new RadButtonTest();
            rbt.ShowDialog();
        }
    }
}
