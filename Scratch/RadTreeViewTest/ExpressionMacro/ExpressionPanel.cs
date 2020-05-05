using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace RadTreeViewTest.ExpressionMacro
{
    public partial class ExpressionPanel : UserControl
    {
        public ExpressionPanel()
        {
            InitializeComponent();
        }

        private void ExpressionPanel_Load(object sender, EventArgs e)
        {
            RadDropDownList rddlSite = new RadDropDownList();
            rddlSite.Name = "Key1";
            panel2.Controls.Add(rddlSite);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Controls.RemoveByKey("Key1");
        }
    }
}
