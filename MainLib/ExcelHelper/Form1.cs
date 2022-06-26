using System.Text;
using System.Text.RegularExpressions;

namespace ExcelHelper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtTimeSheetCSVFile.Text = @"C:\test\timesheet.csv";
            txtDateCSVFile.Text = @"C:\test\date.csv";
        }

        private void btnTimeSheetInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select Time Sheet CSV";
            // openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "CSV file(*.csv)|*.csv";
            openFileDialog.ShowDialog();
            if(openFileDialog.FileName != null)
            {
                txtTimeSheetCSVFile.Text = openFileDialog.FileName;
            }
        }

        private void btnDate_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Select Date CSV";
            // openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "CSV file(*.csv)|*.csv";
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName != null)
            {
                txtDateCSVFile.Text = openFileDialog.FileName;
            }
        }

        private void btnConverter_Click(object sender, EventArgs e)
        {
            List<string> listTimeSheet = CSVHelper.readFile(txtTimeSheetCSVFile.Text);
            List<string> listDate = CSVHelper.readFile(txtDateCSVFile.Text);

            List<string> listRegex = new List<string>() {"M +\\(*.*\\)"};

            string regex = "([a-zA-Z ]+)\\([0-9\\.]+\\)";

            Dictionary<string, int> dict = new Dictionary<string, int>();
            StringBuilder sb = new StringBuilder();
            foreach (string x in listTimeSheet)
            {
                string[] t = x.Split(",");
                if (t.Length != 2) continue;
                string id = t[0];
                string strTimeSheet = t[1];
                Regex r = new Regex(regex, RegexOptions.IgnoreCase);
                Match match = r.Match(strTimeSheet);

                while(match.Success)
                {
                    string strDay = match.Groups[1].Value;
                    dict[strDay.Trim().ToLower()] = 1;
                    match = match.NextMatch();
                }

                foreach(string d in listDate) {
                    string[] td = d.Split(",");
                    if(dict.ContainsKey(td[1].Trim().ToLower()))
                    {
                        sb.AppendLine(string.Format("{0},{1}", id, td[0]));
                    }
                }
            }
            string outputPath = "C:\\test\\output.csv";
            File.WriteAllText(outputPath, sb.ToString());
            MessageBox.Show(string.Format("output to {0} successfully!! ", outputPath));
        }
    }
}