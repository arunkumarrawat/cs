using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using System.Threading;


[assembly: AllowPartiallyTrustedCallers]
namespace ScratchWeb
{
    delegate void updateLabelDeletage();
    public partial class FirstPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblName.Text = DateTime.Now.ToString();
            ThreadPool.QueueUserWorkItem(new WaitCallback(updateLable));

            Thread.Sleep(6000);
        }

        private void updateLable(Object stateInfo)
        {
            while (true)
            {
                lblName.Text = DateTime.Now.ToString();
                Thread.Sleep(1000);
            }
        }
    }
}