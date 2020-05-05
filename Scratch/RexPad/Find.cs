using System;
using System.Windows.Forms;

namespace RexPad
{
    public partial class Find : Form
    {
        public Find()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //Close the dialog
            this.Close();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            //Set the text to find property of the functions class to the entered text
            Functions.TextToFind = findTextBox.Text;
            //Close the form
            this.Close();
        }

        private void Find_Load(object sender, EventArgs e)
        {
            //If the text to find property of the function class is not empty set the text of the text box to it
            if (Functions.TextToFind != null)
                findTextBox.Text = Functions.TextToFind;
        }
    }
}
