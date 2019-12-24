using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MainLib
{
    /// <summary>
    /// File Helper
    /// </summary>
    public class FileHelper
    {
        System.IO.StreamReader file = null;
        int lineNo;
        /// <summary>
        /// 
        /// </summary>
        public FileHelper(string fileName)
        {
            file = new System.IO.StreamReader(fileName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ReadLine()
        {
            return file.ReadLine();
        }

        /// <summary>
        /// Reset to Original position 0
        /// </summary>
        public void Reset()
        {
            file.DiscardBufferedData();
            file.BaseStream.Seek(0, SeekOrigin.Begin);
            file.BaseStream.Position = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<string> ToList()
        {
            List<string> result = new List<string>();
            string line = string.Empty;
            int counter=0;
            while ((line = file.ReadLine()) != null)
            {
                result.Add(line);
                counter++;
            }
            return result;
        }

        /// <summary>
        /// Line Number Of File
        /// </summary>
        public int LineNumber
        {
            get
            {
                int counter = 0;
                string line = string.Empty;
                while ((line = file.ReadLine()) != null)
                {
                    counter++;
                }
                return counter;
            }
        }

    }
}
