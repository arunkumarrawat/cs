using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TransferFileServer
{
    /// <summary>
    /// 
    /// </summary>
    public class TEventArgs : EventArgs
    {
        #region constructor
        string info;
        public TEventArgs(string info)
        {
            this.info = info;
        }
        #endregion
        /// <summary>
        /// the string info we get
        /// </summary>
        public string Info
        {
            get { return info; }
            set { info = value; }
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Server());
        }
    }
}
