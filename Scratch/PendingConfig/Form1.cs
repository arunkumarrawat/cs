using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DatabaseLibrary;
using System.Threading;
using Telerik.WinControls.UI;
using System.Globalization;

namespace PendingConfig
{
    public partial class Form1 : Form
    {
        private Database database;
        private bool notifyStop = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DataTable dt = new DataTable();
            /*
                Id TextBox
                Approve CheckBox
                ApproveDate DateTime
                ProgressBar Image
                            Command
             * */
            database = new Database("localhost","Test");

            DataSet ds = database.SQLConnect_command("dbo.GetDataTest", new object[] { });
            DataTable dt = ds.Tables[0];
            dt.Columns.Add("RowId", typeof(int));

            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dr["RowId"] = i++;
            }

            //dt.Columns.Add("Id",typeof(string));
            //dt.Columns.Add("Approve", typeof(bool));
            //dt.Columns.Add("ApproveDate", typeof(DateTime));
            //dt.Rows.Add("abc", true, DateTime.Now);
            this.radGridView.DataSource = dt;

            foreach (DataRow dr in dt.Rows)
            {
                
            }

            ThreadPool.QueueUserWorkItem(new WaitCallback(startProcess));
        }

        private void startProcess(object sender)
        {
            try
            {
                while (notifyStop)
                {
                    DataTable dt = radGridView.DataSource as DataTable;
                    beginUpdate();

                    foreach(DataRow dr in dt.Rows)
                    {
                        dr["Id"] = Int32.Parse(dr["Id"].ToString(), CultureInfo.InvariantCulture) + 1;
                    }

                    endUpdate();

                    Thread.Sleep(100);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
            }
        }

        private void beginUpdate()
        {
            if (InvokeRequired)
            {
                MethodInvoker method = new MethodInvoker(beginUpdate);
                Invoke(method);
                return;
            }
            radGridView.TableElement.BeginUpdate();
        }

        private void endUpdate()
        {
            if (InvokeRequired)
            {
                MethodInvoker method = new MethodInvoker(endUpdate);
                Invoke(method);
                return;
            }
            radGridView.TableElement.EndUpdate(false);
            this.radGridView.TableElement.Update(GridUINotifyAction.DataChanged);
            radGridView.MasterTemplate.Refresh(null);
        }

        private void radGridView_ValueChanged(object sender, EventArgs e)
        {
            beginUpdate();
            DataTable dt = radGridView.DataSource as DataTable;
            foreach (DataRow dr in dt.Rows)
            {
                dr["Id"] = Int32.Parse(dr["Id"].ToString(), CultureInfo.InvariantCulture)/2;
            }

            endUpdate();
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyStop = false;
        }

    }
}
