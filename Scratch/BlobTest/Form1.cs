using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Configuration;

namespace BlobTest
{
    public partial class Form1 : Form
    {

        #region Private
        private string connectionString = string.Empty;
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private bool regexValidate(string text)
        {
            Regex r = new Regex("^[a-zA-Z0-9_,:.\\\\\\- ]+$");
            if (r.IsMatch(text))
            {
                return true;
            }
            return false;
        }

        private void tbxName_Validating(object sender, CancelEventArgs e)
        {
            if (regexValidate(tbxName.Text) == false)
            {
                e.Cancel = true;
                tbxName.Focus();
            }
        }

        private void tbxTags_Validating(object sender, CancelEventArgs e)
        {
            if (regexValidate(tbxTags.Text) == false)
            {
                e.Cancel = true;
                tbxTags.Focus();
            }
        }

        private void tbxFilePath_Validating(object sender, CancelEventArgs e)
        {
            if (regexValidate(tbxFilePath.Text) == false)
            {
                e.Cancel = true;
                tbxFilePath.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string fileType = "docx";

            if (ValidateFilePath(tbxFilePath.Text))
            {
                FileStream fileStream = new FileStream(tbxFilePath.Text, FileMode.Open, FileAccess.Read);

                string knowledgeName = tbxName.Text;
                string knowledgeTag = tbxTags.Text;
                string filepath = tbxFilePath.Text;
                int knowledgeInt = 123456;
                //byte[] arrayHashValue;
                //MD5CryptoServiceProvider msp = new MD5CryptoServiceProvider();
                //arrayHashValue = msp.ComputeHash(fileStream);
                //fileStream.Close();
                //string strHashValue = System.BitConverter.ToString(arrayHashValue);
                int intHashValue = fileStream.GetHashCode();
                fileStream.Close();
                SQLConnect_ExecuteNonQuery("InsertFile"
                    ,knowledgeName
                    ,knowledgeTag
                    ,knowledgeInt
                    ,fileType
                    ,filepath);
            }
            else
            {
                MessageBox.Show("File Path is not exists");
            }

        }

        public static bool ValidateFilePath(string path)
        {
            //ToDo
            return true;
        }

        public static DataTable SQLConnect_command(string spName, params object[] parameterValues)
        {
            //Data Source=ip;Initial Catalog=dbname;
            DataTable dt = null;
            string connectToSQL = "Data Source=localhost;Initial Catalog=Firebird;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectToSQL))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand("", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "spName";
                    //command.Parameters.Add("@int", SqlDbType.Int);
                    for (int i = 0; i < parameterValues.Length; i++)
                        command.Parameters[i].Value = parameterValues[i];
                    using (SqlDataAdapter reader = new SqlDataAdapter(command))
                    {
                        dt = new DataTable();
                        reader.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static int SQLConnect_ExecuteNonQuery(string spName, params object[] parameterValues)
        {
            //Data Source=ip;Initial Catalog=dbname;
            string connectToSQL = "Data Source=localhost;Initial Catalog=Firebird;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectToSQL))
            {
                con.Open();
                using (SqlCommand command = new SqlCommand(spName, con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlCommandBuilder.DeriveParameters(command);
                    command.CommandText = spName;
                    //command.Parameters.Add("@int", SqlDbType.Int);
                    foreach (SqlParameter p in command.Parameters)
                    {
                        Console.WriteLine(p.ParameterName);
                    }
                    command.Parameters.RemoveAt(0);
                    for (int i = 0; i < parameterValues.Length; i++)
                        command.Parameters[i].Value = parameterValues[i];
                    
                    command.ExecuteNonQuery();
                    con.Close();
                    return 0;
                }
            }
        }

        private void filebrowse_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search s = new Search();
            s.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
        }
    }
}
