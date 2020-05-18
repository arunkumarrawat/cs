using MainLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibCLI
{
    public class FileHashEntry
    {
        public static void TMain(string[] args)
        {
            FileHash fileHash = new FileHash();

            string output = FileHash.md5str("Hello");
            Console.WriteLine(output);
        }
    }
}
