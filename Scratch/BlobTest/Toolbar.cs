using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BlobTest
{
    public partial class Toolbar : UserControl
    {
        public Toolbar()
        {
            InitializeComponent();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void buttons_MouseLeave(object sender, EventArgs e)
        {
            ((Button)sender).FlatStyle = FlatStyle.Flat;
        }

        private void buttons_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).FlatStyle = FlatStyle.Popup;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            buttons_MouseLeave(sender, e);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            buttons_MouseEnter(sender, e);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
