using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DocumentSearcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            object filename = "";
            string strKey = "";
            object MissingValue = Type.Missing;

/*            Word.Application wp = new Word.ApplicationClass();
            Word.Document wd = wp.Documents.Open(ref filename, ref MissingValue,
            ref MissingValue, ref MissingValue,
            ref MissingValue, ref MissingValue,
            ref MissingValue, ref MissingValue,
            ref MissingValue, ref MissingValue,
            ref MissingValue, ref MissingValue,
            ref MissingValue, ref MissingValue,
            ref MissingValue, ref MissingValue);

            if (wd.Content.Text.IndexOf(strKey) >= 0)
            {
                MessageBox.Show("文档中包含指定的关键字！", "搜索结果", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("文档中没有指定的关键字！", "搜索结果", MessageBoxButtons.OK);
            } */
        }
    }
}
