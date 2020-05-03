using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RadTreeViewTest.lib;
using RadTreeViewTest.TestObject;

namespace RadTreeViewTest
{
    public partial class RadListTest : Form
    {
        private Database database = new Database("localhost","Test");
        private Dictionary<string, IpObject> objectHeap = new Dictionary<string, IpObject>();
        public RadListTest()
        {
            InitializeComponent();
        }

        private void RadListTest_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                objectHeap.Add("ip" + i, new IpObject() { Id = i, Name = "ip" + i });
            }

            radListControl1.BeginUpdate();
            radListControl1.DataSource = objectHeap.Keys;
            radListControl1.EndUpdate();

        }

        private void radListupdate()
        {
            radListControl1.BeginUpdate();
            if (radListControl1.DataSource != null)
            {
                radListControl1.DataSource = null;
            }

            radListControl1.DataSource = objectHeap.Keys;
            radListControl1.EndUpdate();
        }

        private void radListViewUpdate()
        {
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(radListControl1.FindString("ip10").ToString());
            MessageBox.Show(radListControl1.FindString("ip13333333", 0).ToString());
        }

    }
}
