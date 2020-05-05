using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace RexPad
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region Declarations

        //Declare the variables that are going to be used in this project
        //Declare the string containing the file path
        private string _filePath;
        //Declare the original content of the file
        private string _oldFile;

        #endregion Declarations

        #region File Operations

        //Open a file
        private void Open()
        {
            //Save or not the changes made to the file
            SaveChanges();

            //Get the result of the dialog (Yes, No, ... )
            DialogResult result = openFileDialog1.ShowDialog();
            //Check if the user clicked 'Open'
            if (result == DialogResult.OK)
            {
                //Get the file path selected by the user
                _filePath = openFileDialog1.FileName;

                //If the filepath is not empty
                if (!string.IsNullOrWhiteSpace(_filePath))
                {
                    //Declare a variable to hold the text that is read
                    string text;
                    //Read the text of the file
                    using (var myReader = new StreamReader(_filePath))
                        text = _oldFile = myReader.ReadToEnd();
                    //Set the textboxs text to the files text
                    mainTextBox.Text = text;
                }
            }
        }

        //Save the current file
        private void Save(string fileToSave)
        {
            //If the file location specified is not empty
            if (!string.IsNullOrWhiteSpace(fileToSave))
            {
                //Save the file
                using (var myWriter = new StreamWriter(fileToSave))
                    myWriter.Write(mainTextBox.Text);
            }
        }

        private void SaveChanges()
        {
            //If the old file content is different from the current one
            if (_oldFile != mainTextBox.Text)
            {
                //If the file is not empty
                if (_oldFile != null && _filePath != null)
                {
                    //Prompt the user to save the changes
                    var result = MessageBox.Show("Do you want to save the changes to " + _filePath, "Saving Changes",
                                                 MessageBoxButtons.YesNo);
                    //If the user accepts save the changes
                    if (result == DialogResult.Yes)
                        Save(_filePath);
                }
            }
        }

        #endregion File Operations

        #region Text Operations

        private void Find(string textToFind, ref Find findForm)
        {
            //If there isn't found the text specified
            if (mainTextBox.Text.IndexOf(textToFind) == -1)
            {
                //Show a message to the user
                MessageBox.Show("Cannot find '" + textToFind + " '");
                //And show the dialog again
                findForm.ShowDialog();
            }
            else
            {
                //If it is found
                //Put the cursor at the start of it
                mainTextBox.SelectionStart = mainTextBox.Text.IndexOf(Functions.TextToFind);
                //And select it
                mainTextBox.SelectionLength = textToFind.Length;
            }
        }

        private void ReplaceAll(string textToReplace, string replacementText)
        {
            //Declare and initialize a new regex
            Regex regex = new Regex(textToReplace);
            //Replace the words
            string finishText = regex.Replace(mainTextBox.Text, replacementText);
            //If nothing is replaced the tell it to the user, if something has been replaced tell it to the user
            if (mainTextBox.Text == finishText)
                MessageBox.Show("Nothing was replaced, because there were no words to replace!");
            else
            {
                //Set the text of the text box to the finished text
                mainTextBox.Text = finishText;
                //Show a message to the user...
                MessageBox.Show("'" + textToReplace + "' was replaced by '" + replacementText + "'");
            }
        }

        #endregion Text Operations

        #region Interface Operations

        //Change the status bar state
        private void StatusBarChange()
        {
            //If it is already visible
            if (statusStrip1.Visible)
            {
                //Uncheck its icon in the menu
                statusBarToolStripMenuItem.Checked = false;
                //Hide it
                statusStrip1.Visible = false;
                //Resize the text box
            }
            else
            {
                //If it is hidden, then check its icon in the menu
                statusBarToolStripMenuItem.Checked = true;
                //Show it
                statusStrip1.Visible = true;
            }
        }

        //Update the status bar
        private void StatusBarUpdate()
        {
            //Declare the status bar line number and column number
            //Get the current line number
            int statusBarLine = mainTextBox.GetLineFromCharIndex(mainTextBox.GetFirstCharIndexOfCurrentLine());
            //Get the current column number
            int statusBarColumn = mainTextBox.SelectionStart - mainTextBox.GetFirstCharIndexOfCurrentLine();
            //Show the column and line numbers in the status bar
            toolStripStatusLabel1.Text = "Ln " + statusBarLine.ToString() + ", Col " + statusBarColumn.ToString();
        }

        //Change the text box mode
        private void TextBoxModeChange()
        {
            //Set the textbox wordwrap poperty in accordance to the word wrap menu item
            mainTextBox.WordWrap = wordWrapToolStripMenuItem.Checked;
            //Set the scroll bars in accordance to the textbox mode
            mainTextBox.ScrollBars = wordWrapToolStripMenuItem.Checked ? ScrollBars.Vertical : ScrollBars.Both;
        }

        #endregion Interface Options

        #region Menu Item Clicks

        #region File Menu Item Clicks

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Prompt the user to save the changes
            this.SaveChanges();
            //Set the file location to null
            _filePath = null;
            //Empty the textbox
            mainTextBox.Text = null;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open a file
            this.Open();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If the filepath is not empty then save it
            if (!string.IsNullOrWhiteSpace(_filePath))
                this.Save(_filePath);
            else
            {
                //if not show a dialog to create a new file
                DialogResult result = saveFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //If the user clicks 'save' then save it
                    _filePath = saveFileDialog1.FileName;
                    this.Save(_filePath);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Show the dialog
            DialogResult result = saveFileDialog1.ShowDialog();
            //If the user clicked 'Save'
            if (result == DialogResult.OK)
            {
                //Set the file to the selected filename
                _filePath = saveFileDialog1.FileName;
                //Then save the document
                Save(_filePath);
            }
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Sync the documents
            pageSetupDialog1.Document = printDocument1;
            //Show the page setup dialog
            DialogResult result = pageSetupDialog1.ShowDialog();
            //If the user clicks 'OK'
            if (result == DialogResult.OK)
            {
                //Set the document page and printer settings to the ones selected
                printDocument1.DefaultPageSettings = pageSetupDialog1.PageSettings;
                printDocument1.PrinterSettings = pageSetupDialog1.PrinterSettings;
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Sync the documents
            printPreviewDialog1.Document = printDocument1;

            //Show the dialog
            DialogResult result = printPreviewDialog1.ShowDialog();

            //If the user clicks 'OK' then print the document
            if (result == DialogResult.OK)
                printDocument1.Print();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Sync the settings of the document and the dialog
            printDialog1.PrinterSettings = printDocument1.PrinterSettings;
            //Open the dialog
            DialogResult result = printDialog1.ShowDialog();
            //Set the document of the dialog to the document
            printDialog1.Document = printDocument1;
            //If the user clicks 'OK' then print the page
            if (result == DialogResult.OK)
                printDocument1.Print();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Close the form
            this.Close();
        }

        #endregion File Menu Item Clicks

        #region Edit Menu Item Clicks

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If the textbox can't do an undo then disable it from the textbox menu
            if (mainTextBox.CanUndo == false)
                undoToolStripMenuItem.Enabled = false;
            //If the clipboard is empty then disable that from the menu item
            if (Clipboard.GetText() != "")
                pasteToolStripMenuItem.Enabled = false;
            //If nothing is selected
            if (mainTextBox.SelectionLength == 0)
            {
                //Disable cut and copy from the menu
                copyToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If undo is available undo the last move
            if (mainTextBox.CanUndo)
                mainTextBox.Undo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If something is selected cut it
            if (mainTextBox.SelectionLength != 0)
                mainTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If something is selected copy it to the clipboard
            if (mainTextBox.SelectionLength != 0)
                mainTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If there is something in the clipboard
            if (Clipboard.GetText() != "")
            {
                //Paste that into the textbox
                mainTextBox.Paste();
                //Set the cursor position to the end of the textbox
                mainTextBox.SelectionStart = mainTextBox.TextLength;
                mainTextBox.SelectionLength = 0;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Set a helper string to the current clipboard content
            string backup = Clipboard.GetText();
            //Cut something out of the textbox
            mainTextBox.Cut();
            //Clear the clipboard content
            Clipboard.Clear();
            //Set it to the original content
            Clipboard.SetText(backup);
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Declare and initialize a new Find Form
            Find findForm = new Find();
            //Show the find dialog
            findForm.ShowDialog();
            Find(Functions.TextToFind, ref findForm);
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Declare and initialize a new find form
            Find findForm = new Find();
            //Find the already determined text
            Find(Functions.TextToFind, ref findForm);
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Declare and initialize a new replace form
            Replace replaceForm = new Replace();
            //Show the replace form
            replaceForm.ShowDialog();
            //If find next was clicked, else if replace all was clicked then replace all occurences of the word
            if (replaceForm.FindNextClicked)
            {
                //Declare and initialize a new find form
                Find findForm = new Find();
                //And find the word
                Find(Functions.TextToFind, ref findForm);
            }
            else if (replaceForm.ReplaceAllClicked)
                ReplaceAll(Functions.TextToFind, Functions.ReplacementText);
        }

        private void goToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Declare the maximum number of lines
            Functions.MaxNumberOfLines = mainTextBox.Lines.Count();
            //Declare and initialize a new GoTo Form
            GoTo goToForm = new GoTo();
            //Show the dialog
            goToForm.ShowDialog();
            //If the user clicked 'Go To'
            if (goToForm.GoToClicked)
            {
                //Go to the line number entered
                mainTextBox.SelectionStart = mainTextBox.GetFirstCharIndexFromLine(Functions.GoToLineNumber - 1);
                mainTextBox.SelectionLength = 0;
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Select all text
            mainTextBox.SelectAll();
        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Add the current date and time to the textbox
            mainTextBox.Text += DateTime.Now;
        }

        #endregion Edit Menu Item Clicks

        #region Format Menu Item Clicks

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Change the textbox mode
            this.TextBoxModeChange();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Show the font dialog
            DialogResult result = fontDialog.ShowDialog();
            //If the user clicked ok, set the textbox font to the selected one
            if (result == DialogResult.OK)
                mainTextBox.Font = fontDialog.Font;
        }

        #endregion Format Menu Item Clicks

        #region View Menu Item Clicks

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Update the status bar mode
            this.StatusBarChange();
        }

        #endregion View Menu Item Clicks

        #region Help Menu Item Clicks

        private void aboutRexPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Initialize a new about box
            AboutRexPad aboutBox = new AboutRexPad();
            //Show the previously initialized about box
            aboutBox.ShowDialog();
        }

        #endregion Help Menu Item Clicks

        #endregion Menu Item Clicks

        #region TextBox Events

        private void mainTextBox_Changed(object sender, EventArgs e)
        {
            //Update the status bar
            this.StatusBarUpdate();
        }

        private void mainTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode.ToString() == "A")
            {
                //Ctrl + A = Select all
                mainTextBox.SelectionStart = 0;
                mainTextBox.SelectionLength = mainTextBox.Text.Length;
            }
        }

        #endregion TextBox Events

        #region MainForm Events

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Set the textbox mode
            this.TextBoxModeChange();
            //Update the status bar
            this.StatusBarUpdate();
            //Create a new event handler
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Prompt the user to save the changes
            this.SaveChanges();
        }

        #endregion MainForm Events

        private void printDocument1_PrintPage(Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //Declare new graphics
            Graphics g = e.Graphics;
            //Draw the current text in the textbox onto the document
            g.DrawString(mainTextBox.Text, mainTextBox.Font, Brushes.Black, 0, 0);
        }
    }
}