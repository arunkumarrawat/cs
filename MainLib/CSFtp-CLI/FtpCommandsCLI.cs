using CSFtp_CLI.ftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFtp_CLI
{
    public class FtpCommandsCLI
    {
        public static void Enter()
        {
            StandardFileSystemClassFactory fileFactory = new StandardFileSystemClassFactory();

            FtpConnectionObject theCommands = new FtpConnectionObject(fileFactory, 0, null);

            string strUser = "USER wudi\r";
            byte[] byteData = System.Text.Encoding.ASCII.GetBytes(strUser);

            theCommands.Process(byteData);

            string strPassword = "PASS 123456\r";

            byteData = System.Text.Encoding.ASCII.GetBytes(strPassword);

            theCommands.Process(byteData);
        }
    }
}
