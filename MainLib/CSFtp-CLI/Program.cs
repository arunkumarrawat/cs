using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MainLib;
using CSFtp_CLI.ftp;

namespace CSFtp_CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHelper fileHelper = new FileHelper("./data/user.txt");

            List<string> content = fileHelper.ToList();

            foreach (string s in content)
            {
                string[] split = s.Split(',');

                foreach(string x in split)
                    Console.WriteLine(x);
            }

            StandardFileSystemClassFactory fileFactory = new StandardFileSystemClassFactory();

            FtpConnectionObject theCommands = new FtpConnectionObject(fileFactory, 0, null);

            string strUser = "USER wudi\r";
            byte[] byteData = System.Text.Encoding.ASCII.GetBytes(strUser);

            theCommands.Process(byteData);
        }
    }
}
