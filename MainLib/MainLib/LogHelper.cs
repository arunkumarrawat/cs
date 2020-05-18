using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainLib
{
    /// <summary>
    /// Log Helper to log debugging information
    /// </summary>
    public static class LogHelper
    {
        /// <summary>
        /// Log all message
        /// </summary>
        /// <param name="message"></param>
        public static void log(string message)
        {
            System.Diagnostics.Trace.WriteLine(System.Threading.Thread.CurrentThread.Name + " " + System.DateTime.Now + " " + System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.ToString() + " " + System.Reflection.MethodBase.GetCurrentMethod().Name + " " + System.Threading.Thread.CurrentThread.Name + " " + (new System.Diagnostics.StackFrame(0, true)).GetFileName() + " " + (new System.Diagnostics.StackFrame(0, true)).GetFileLineNumber().ToString() + System.Environment.StackTrace + System.Environment.NewLine);
            System.Diagnostics.Trace.WriteLine(message);
        }
    }
}
