using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MainLib
{
    /// <summary>
    /// This Class Contains All operation for Files
    /// </summary>
    public class CFile
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        public void Copy(string sourcePath, string destinationPath)
        {
            // use C# API

            try
            {
                File.Copy(sourcePath, destinationPath);
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Trace.Write(ex);
            }
        }
    }
}
