using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.WinControls.UI;

namespace TelerikUI
{
    /// <summary>
    /// Rad Button Encapsulation
    /// </summary>
    public class RadButtonX : RadButton
    {
        public string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public void setText(string s)
        {
            this.Text = s;
        }

        public void SetImageAboveText()
        {
            TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
        }

        public void SetDockToFill()
        {
            Dock = System.Windows.Forms.DockStyle.Fill;
        }
    }
}
