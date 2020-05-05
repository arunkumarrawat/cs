using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FlashGet
{
    /*
     *  split file into 5 pieces.
     *  copy each pieces using multi-threading
     *  merge 5 pieces into one file.
     */
    public partial class MultithreadCopyFile : Form
    {
        public MultithreadCopyFile()
        {
            InitializeComponent();
        }
    }
}
