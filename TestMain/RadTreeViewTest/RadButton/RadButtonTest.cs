using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Threading;
using System.Security;

namespace RadTreeViewTest.RadButton
{
    public partial class RadButtonTest : Form
    {
        public RadButtonTest()
        {
            InitializeComponent();
        }

        private void radMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is the raddropdown list");
        }

        private void radRepeatButton1_Click(object sender, EventArgs e)
        {
            if (this.radProgressBar1.Value1 < this.radProgressBar1.Maximum)
            {
                this.radProgressBar1.Value1 += 1;
            }
            else
            {
                this.radProgressBar1.Value1 = this.radProgressBar1.Minimum;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            string[] rolesArray = { "managers", "executives" };
            try
            {
                // Set the principal to a new generic principal.
                //Thread.CurrentPrincipal =
                //    new GenericPrincipal(new GenericIdentity(
                //    "Bob", "Passport"), rolesArray);

                string[] roles = new string[10];
                if (windowsIdentity.IsAuthenticated)
                {
                    // Add custom NetworkUser role.

                    roles[0] = "NetworkUser";
                }

                if (windowsIdentity.IsGuest)
                {
                    // Add custom GuestUser role.

                    roles[1] = "GuestUser";
                }

                if (windowsIdentity.IsSystem)
                {
                    // Add custom SystemUser role.

                    roles[2] = "SystemUser";
                }

                // Construct a GenericIdentity object based on the current Windows

                // identity name and authentication type.

                string authenticationType = windowsIdentity.AuthenticationType;
                string userName = windowsIdentity.Name;
                GenericIdentity genericIdentity =
                    new GenericIdentity(userName, authenticationType);

                // Construct a GenericPrincipal object based on the generic identity

                // and custom roles for the user.

                Thread.CurrentPrincipal =
                    new GenericPrincipal(genericIdentity, roles);

            }
            catch (SecurityException secureException)
            {
                Console.WriteLine("{0}: Permission to set Principal " +
                    "is denied.", secureException.GetType().Name);
            }

            IPrincipal threadPrincipal = Thread.CurrentPrincipal;
            MessageBox.Show(string.Format("Name: {0}\nIsAuthenticated: {1}" +
                "\nAuthenticationType: {2}",
                threadPrincipal.Identity.Name,
                threadPrincipal.Identity.IsAuthenticated,
                threadPrincipal.Identity.AuthenticationType));
        }
    }
}
