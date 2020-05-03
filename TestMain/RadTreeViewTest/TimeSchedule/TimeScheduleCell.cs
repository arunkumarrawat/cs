using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RadTreeViewTest.TimeSchedule
{
    public partial class TimeScheduleCell : UserControl
    {
        public TimeScheduleCell()
        {
            InitializeComponent();
        }

        /// <summary>
        ///
        /// </summary>
        public Telerik.WinControls.UI.RadMaskedEditBox RadMaskedEditBox1
        {
            get { return radMaskedEditBox1; }
            set { radMaskedEditBox1 = value; }
        }

        /// <summary>
        ///
        /// </summary>
        public Telerik.WinControls.UI.RadCheckBox RadCheckBox1
        {
            get { return radCheckBox1; }
            set { radCheckBox1 = value; }
        }

    }
}
