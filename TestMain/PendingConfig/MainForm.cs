using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DatabaseLibrary;

namespace PendingConfig
{
    public partial class MainForm : Form
    {
        List<string> list = new List<string>()
        { 
          "RA0.DAT", 
          "RA1.DAT", 
          "RA2.DAT", 
          "RN4.DAT",
          "RX1.DAT",
          "RA100.DAT",
          "RA200.DAT",
          "RC0.DAT",
          "RC1.DAT",
          "RC2.DAT",// 10
          "RC3.DAT",
          "RN11.DAT",
          "RN12.DAT",
          "RN14.DAT",
          "RA100.DAT", // 15
          "RA116.DAT",
          "RN26.DAT",
          "RA6.DAT"
        };
        Database database = new Database("localhost","Test");

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnInsertData_Click(object sender, EventArgs e)
        {
            int siteId = 1000;
            int controllerId = 1;



            database.SQLConnect_ExecuteNonQuery("dbo.InsertPendingConfig", new object[] { });
        }

        private void btnStartDelete_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(DeleteDatabase));
        }

        private void DeleteDatabase(object sender)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
