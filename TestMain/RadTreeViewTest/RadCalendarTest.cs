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
    public partial class RadCalendarTest : Form
    {
        public RadCalendarTest()
        {
            InitializeComponent();
        }

        private void RadCalendarTest_Load(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are there any other products in the carton?",
                "Question",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
);
        }
    }
}
