using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainLib;

namespace ConnectToSqlServer
{
    public partial class Form1 : Form
    {
        private string host = "192.168.2.6";
        private string databaseName = "Northwind";
        private string username = "sa";
        private string password = "123456";
        private SqlServerDatabase db;
        public Form1()
        {
            InitializeComponent();
            db = new SqlServerDatabase(host, databaseName, username, password);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = db.executesqlforDataTable("select * from dbo.Customers");
            dataGridView1.DataSource = dt;
        }
    }
}
