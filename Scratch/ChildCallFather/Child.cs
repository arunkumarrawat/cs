using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace ChildCallFather
{
    public partial class Child : Form
    {
        public EventHandler cf;
        public string internetString = Assembly.GetExecutingAssembly().GetName().Name;
        public Child()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cf != null)
                cf(new object[]{this,internetString}, null);
        }

        public void popup(object sender, EventArgs e)
        {
            MessageBox.Show("This is Child in popup()");
        }
    }
}
