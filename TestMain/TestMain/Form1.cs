using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Telerik.WinControls;

namespace TestMain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-AU");
            radTextBox1.Text = DateTime.UtcNow.ToString(ci);
            DataTable dt = new DataTable();
            dt.Columns.Add("DateTime",typeof(DateTime));
            dt.Rows.Add(DateTime.UtcNow);
            radGridView1.DataSource = dt;
        }

        private void radGridView1_CommandCellClick(object sender, EventArgs e)
        {
            RadMessageBox.Show("CommandCell event invoked");
        }
    }
}
