using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;

namespace FlashGet
{
    public partial class frmFlashGet : Form
    {
        private WebRequest httpRequest;
        private WebResponse httpResponse;
        private byte[] buffer;
        private Thread downloadThread;
        Stream ns;
        private string filename = @"d:\workspace\test\1.rar";
        private FileStream fs;
        private long length;
        private long downlength = 0;
        private long lastlength = 0;
        public delegate void updateData(string value); //设置委托用来更新主界面
        private int totalseconds = 0; //总用时
        private updateData UIDel; //
        public frmFlashGet()
        {
            InitializeComponent();
            buffer = new byte[4096];
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (tbxURLText.Text == null || tbxURLText.Text == "")
                return;

            httpRequest = WebRequest.Create(tbxURLText.Text);
            httpResponse = httpRequest.GetResponse();
            //MessageBox.Show(httpResponse.ContentLength.ToString());
            length = httpResponse.ContentLength;
            this.progressBar1.Maximum = (int)length;
            this.progressBar1.Minimum = 0;
            downloadThread = new Thread(new ThreadStart(downloadFile));
            //showThread = new Thread(new ThreadStart(show));
            fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
            downloadThread.Start();
            timer1.Interval = (1000) * 1;
            this.timer1.Enabled = true;
            this.timer1.Start();
            // showThread.Start();
        }

        private void downloadFile()
        {
            ns = httpResponse.GetResponseStream();
            int i;
            UIDel = new updateData(updateUI);
            while ((i = ns.Read(buffer, 0, buffer.Length)) > 0)
            {
                downlength += i;
                string value = downlength.ToString();
                this.Invoke(UIDel, value);
                fs.Write(buffer, 0, i);
            }
            MessageBox.Show("下载完毕");
            fs.Close();
            this.timer1.Enabled = false;
            this.lblDownloadSpeed.Text = (length / (1024 * totalseconds)) + "KB/s";
        }
        /* private void show()
         {
             UIDel = new updateData(updateUI);
             int value = 0;
             while (value <= 100)
             {
                 this.progressBar1.Value = value;
                 value++;
             } 
         }*/
        void updateUI(string value)
        {
            this.progressBar1.Value = Int32.Parse(value);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDownloadSpeed.Text = ((downlength - lastlength) / 1024) + "KB/S";
            lastlength = downlength;
            totalseconds++;
        }

        private void frmFlashGet_Load(object sender, EventArgs e)
        {

        }

        private void btBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = fbd.SelectedPath;
            }
        }

        private void get_fileName(Uri url)
        {
            
        }
    }
}
