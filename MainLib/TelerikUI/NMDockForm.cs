using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace TelerikUI
{
    public partial class NMDockForm : ShapedForm
    {
        public NMDockForm()
        {
            InitializeComponent();
        }

        public void SetMax()
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }
    }
}
