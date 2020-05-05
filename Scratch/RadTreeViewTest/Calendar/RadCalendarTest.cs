using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MainLib;

namespace RadTreeViewTest.Calendar
{
    public partial class RadCalendarTest : Form
    {
        private NMFile file = new NMFile();
        public RadCalendarTest()
        {
            InitializeComponent();
        }

        private void RadCalendarTest_Load(object sender, EventArgs e)
        {
            //radCalendar1.SelectedDates.AddRange(new DateTime[3]());

            DialogResult result = MessageBox.Show(
                "Are there any other products in the carton?",
                "Question",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
);
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            string filePath = "Calendar\\FileVersion.txt";
            string content = file.ReadAllTextFile(filePath);
            string[] array = content.Split('.');

            int buildNumber = int.Parse(array[2]) + 1;

            string output = array[0] + "." + array[1] + "." + buildNumber + ".0";
            file.WriteAllTextFile(filePath,output);

            radLabel1.Text = output;
        }
    }
}
