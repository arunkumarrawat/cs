using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelHelper
{
    public class CSVHelper
    {
        public static List<string> readFile(string path)
        {
            var logFile = File.ReadAllLines(path);
            var logList = new List<string>(logFile);
            return logList;
        }
    }
}
