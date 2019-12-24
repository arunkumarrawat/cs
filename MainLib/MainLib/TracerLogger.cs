using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MainLib
{
    /// <summary>
    /// 
    /// </summary>
    public class TracerLogger
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <param name="isDelete">if it is false then append to file, true to recreate the file</param>
        public TracerLogger(string fileName,bool isDelete)
        {
            if(isDelete)
            {
                FileInfo f = new FileInfo(fileName);

                if(f.Exists)
                {
                    f.Delete();
                }
            }

            System.Diagnostics.TextWriterTraceListener s = new System.Diagnostics.TextWriterTraceListener(fileName);
            System.Diagnostics.Trace.Listeners.Add(s);
            System.Diagnostics.Trace.AutoFlush = true;
        }

        /// <summary>
        /// Write Line
        /// </summary>
        /// <param name="output"></param>
        public void WriteLine(string output)
        {
            System.Diagnostics.Trace.WriteLine(output);
        }

        /// <summary>
        /// Write String without line
        /// </summary>
        /// <param name="output"></param>
        public void Write(string output)
        {
            System.Diagnostics.Trace.Write(output);
        }

        /// <summary>
        /// Trace Close
        /// </summary>
        public void Close()
        {
            System.Diagnostics.Trace.Close();
        }
    }
}
