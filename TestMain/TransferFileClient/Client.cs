using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace TransferFileClient
{
    public partial class Client : Form
    {
        byte[] clientData;
        public Client()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                txtBoxFilePath.Text = openFileDialog.FileName;
        }

        private string getFileName(string fileNamePathString)
        {
            string[] fileNameOrPathNameStringArray = fileNamePathString.Split('\\');
            string fileName = fileNameOrPathNameStringArray[fileNameOrPathNameStringArray.Length - 1];
            return fileName;
        }

        private void ThreadHandler()
        {
            try
            {

            string filePathString = txtBoxFilePath.Text;

            string strFileName = getFileName(filePathString);

            Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            byte[] fileName = Encoding.UTF8.GetBytes(strFileName);
            byte[] fileData = File.ReadAllBytes(filePathString);

            byte[] fileNameLen = BitConverter.GetBytes(fileName.Length);


            clientData = new byte[4 + fileName.Length + fileData.Length];

            fileNameLen.CopyTo(clientData, 0);
            fileName.CopyTo(clientData, 4);
            fileData.CopyTo(clientData, 4 + fileName.Length);


            clientSock.Connect("localhost", 9050); //target machine's ip address and the port number
            clientSock.Send(clientData);
            clientSock.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("send fail\n" + e.Message + "\n" + e.StackTrace.ToString());
                throw;
            }
            MessageBox.Show("Send Successfully");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(new ThreadStart(ThreadHandler));
            t.IsBackground = true;
            t.Start();
        }
    }
}
