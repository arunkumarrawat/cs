using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChildCallFather
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Child c = new Child();
            c.StartPosition = FormStartPosition.CenterParent;
            c.cf += privateFunctionInFatherClass;
            c.ShowDialog();
        }

        private void privateFunctionInFatherClass(object sender, EventArgs e)
        {
            object[] result = (object[]) sender;
            Child c = result[0] as Child;
            string s = result[1] as string;
            //MessageBox.Show((string)sender);
            ChildTwo c2 = new ChildTwo();
            c2.cf += c.popup;

            c2.ShowDialog();
        }
    }
}
