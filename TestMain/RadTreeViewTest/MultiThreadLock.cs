using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RadTreeViewTest.lib;

namespace RadTreeViewTest
{
    public partial class MultiThreadLock : Form
    {
        private Database viewController = new Database("localhost","Test");
        public MultiThreadLock()
        {
            InitializeComponent();
        }

        private void MultiThreadLock_Load(object sender, EventArgs e)
        {
            DataSet ds = viewController.SQLConnect_command("dbo.GetDataTest", new object[] { });
            DataTable dt = ds.Tables[0];

            radGridView1.DataSource = dt;
        }
    }
}
