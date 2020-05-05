using System;
using System.Data;
using System.Windows.Forms;

//Bind TextBox with DataTable using BindingManagerBase
namespace TextBoxBinding
{


    public partial class Form1 : Form
    {
        BindingManagerBase bmb;
        DataTable dt = new DataTable();
        TestObject to = new TestObject();
        DataRow[] dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Name", typeof(string));

            dt.Rows.Add(3, "abc");
            dt.Rows.Add(4, "def");

            textBox1.DataBindings.Add("Text", dt, "Name");
            bmb = this.BindingContext[dt];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bmb.Position = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bmb.Position = 3;
        }
    }

    public class TestObject
    {
        public string BindingTest
        {
            get;
            set;
        }
    }
}
