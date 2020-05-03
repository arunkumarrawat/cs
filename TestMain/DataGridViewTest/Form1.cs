using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataGridViewTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Rows.Add(1, "name1");
            dt.Rows.Add(2, "name2");
            dataGridView.DataSource = dt;

            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.RowHeadersWidthSizeMode =
    DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridView.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            statusStrip.Renderer = new MySR();
            toolStripStatusLabel1.Text = "Test Text 1";
            toolStripStatusLabel2.Text = "Test Text 2";

            //menuStrip.Renderer = new MySR();

            listView.Clear();
            listView.Columns.Add("Id");
            listView.Columns.Add("Name");
            
            foreach (DataRow dr in dt.Rows)
            {
                string[] ar = Array.ConvertAll<object, string>(dr.ItemArray, p => p.ToString());
                listView.Items.Add(new ListViewItem(ar));
            }
        }
    }

    public class MySR : ToolStripSystemRenderer
    {
        public MySR() { }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            //base.OnRenderToolStripBorder(e);
            base.OnRenderToolStripBorder(e);
            e.Graphics.FillRectangle(Brushes.Black, e.ConnectedArea);
        }
    }

}
