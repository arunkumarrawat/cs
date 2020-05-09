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
        public void initUserPasswordAndDirectory()
        {
            UserData userData = UserData.Get();
            userData.AddUser("wudi");

            userData.SetUserPassword("wudi", "123456");
            userData.SetUserStartingDirectory("wudi", "C:\\test");
            userData.Save();
        }

        public static void Enter()
        {
            StandardFileSystemClassFactory fileFactory = new StandardFileSystemClassFactory();

            FtpConnectionObject theCommands = new FtpConnectionObject(fileFactory, 0, null);

            UserData.Get().Load();

            string strUser = "USER wudi\r";
            theCommands.Process(Encoding.ASCII.GetBytes(strUser));

            string strPassword = "PASS 123456\r";
            theCommands.Process(Encoding.ASCII.GetBytes(strPassword));

            string strPwd = "PWD\r";
            theCommands.Process(Encoding.ASCII.GetBytes(strPwd));

            string strPort = "PORT 127,0,0,1,20,199\r";
            theCommands.Process(Encoding.ASCII.GetBytes(strPort));

            string strList = "NLST \r";
            theCommands.Process(Encoding.ASCII.GetBytes(strList));

            /*string strGet = "GET 1.txt \r";
            theCommands.Process(Encoding.ASCII.GetBytes(strGet));*/
        }
    }
}
