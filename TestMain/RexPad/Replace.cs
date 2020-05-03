using System;
using System.Windows.Forms;

namespace RexPad
{
    public partial class Replace : Form
    {
        public Replace()
        {
            InitializeComponent();
        }

        //Declare two auto-priperties to indicate if the user has clicked find next of replace all
        public bool FindNextClicked { get; private set; }
        public bool ReplaceAllClicked { get; private set; }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //Set the click indicators to false
            FindNextClicked = false;
            ReplaceAllClicked = false;
            //Close the dialog
            this.Close();
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            //If the entered text is not empty
            if (findTextBox.Text != null)
            {
                //Indicate what button the user has clicked
                FindNextClicked = true;
                ReplaceAllClicked = false;
                //And set the functions text to find property to the entered text
                Functions.TextToFind = findTextBox.Text;
            }
        }

        private void replaceButton_Click(object sender, EventArgs e)
        {
            //If there is some text in both textBoxes
            if (findTextBox.Text != null && replaceTextBox.Text != null)
            {
                //Indicate that the user has clicked replace all
                ReplaceAllClicked = true;
                FindNextClicked = false;
                //Set the TextToFind and ReplacementText properties of the functions class to the entered text
                Functions.TextToFind = findTextBox.Text;
                Functions.ReplacementText = replaceTextBox.Text;
            }
        }

        private void Replace_Load(object sender, EventArgs e)
        {
            //If there is some text in the TextToFind property of the funciton class set it to the findTextBoxe's text
            if (Functions.TextToFind != null)
                findTextBox.Text = Functions.TextToFind;
            //If there is some text in the ReplacementText property of the funciton class set it to the replaceTextBox's text
            if (Functions.ReplacementText != null)
                replaceTextBox.Text = Functions.ReplacementText;
        }
    }
}
