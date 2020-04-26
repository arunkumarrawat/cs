using CSFtp_CLI.ftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFtp_CLI.FtpCommands
{
    class QuitCommandHandler : FtpCommandHandler
    {
        public QuitCommandHandler(FtpConnectionObject connectionObject)
            : base("QUIT", connectionObject)
        {

        }

        protected override string OnProcess(string sMessage)
        {
            return GetMessage(220, "Goodbye");
        }
    }
}
