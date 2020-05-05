using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace PendingConfig
{
    public partial class CSplitButton : RadSplitButton
    {
        public CSplitButton()
        {
            InitializeComponent();
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);

            this.DropDownButtonElement.ActionButton.Focus();
        }

        public override string ThemeClassName
        {
            get
            {
                return typeof(RadSplitButton).FullName;
            }
        }
    }
}
