using System;
using System.Windows.Forms;

namespace RexPad
{
    public partial class GoTo : Form
    {
        public GoTo()
        {
            InitializeComponent();
        }

        public bool GoToClicked { get; private set; }  

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //Set the GoTo indicator to false
            GoToClicked = false;
            //Close the dialog
            this.Close();
        }

        private void lineTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Let the user input only numbers
            int isNumber = 0;
            e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
        }

        private void goToButton_Click(object sender, EventArgs e)
        {
            //NOTE: No need to check if it's int because the user can't input anything other than a number
            
            // If input is empty show warning
            if (lineTextBox.Text != "")
            {
                //If the entered goToLineNumber is greater than the max number of lines 
                //then show the message to the user, else pass that value to the GoToLineNumber property and close the form
                if (int.Parse(lineTextBox.Text) > Functions.MaxNumberOfLines)
                    MessageBox.Show("The line number is beyond the total number of lines");
                else
                {
                    //Set the go to indicator to true
                    GoToClicked = true;
                    //Pass the value to the GoToLineNumber property
                    Functions.GoToLineNumber = int.Parse(lineTextBox.Text);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Please enter a line number");
            }
        }

        private void GoTo_Load(object sender, EventArgs e)
        {
            if (Functions.GoToLineNumber != 0)
                lineTextBox.Text = Functions.GoToLineNumber.ToString();
        }
    }
}
