using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ChildCallFather
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //@example: child form call father form using delegate
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
