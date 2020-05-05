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
    public partial class ChildTwo : Form
    {
        public EventHandler cf;

        public ChildTwo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cf != null)
                cf(sender, e);
        }
    }
}
