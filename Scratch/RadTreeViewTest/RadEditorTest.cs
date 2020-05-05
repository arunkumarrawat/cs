using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RadTreeViewTest
{
    public partial class RadEditorTest : Form
    {
        public RadEditorTest()
        {
            InitializeComponent();
        }

        private void rckEnable_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
            if (rckEnable.Checked == true)
            {
                rckEnable.Text = "Disable";
                radMBTest.Enabled = false;
            }
            else if (rckEnable.Checked == false)
            {
                rckEnable.Text = "Enable";
                radMBTest.Enabled = true;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            radMBTest.Value = "00:00";
            radMBTest.Enabled = false;
        }
    }
}
