using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RadTreeViewTest.ExpressionMacro
{
    public partial class Expression : Form
    {
        private Dictionary<string, string> dict = new Dictionary<string, string>();
 
        public Expression()
        {
            InitializeComponent();
        }

        private void Expression_Load(object sender, EventArgs e)
        {
            dict.Add("key1", "key2");
            dict.Add("key2", "key3");

            //dict.Keys
            //radDropDownList1.DisplayMember = "Key";
            //radDropDownList1.ValueMember = "Value";
            //radDropDownList1.DataSource = dict;



        }

        private void radDropDownList1_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //string test = radDropDownList1.SelectedValue as string;
            //System.Diagnostics.Trace.WriteLine(test);
        }
    }
}
