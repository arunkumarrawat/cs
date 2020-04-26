using CSFtp_CLI.ftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFtp_CLI.FtpCommands
{
    class AlloCommandHandler : FtpCommandHandler
    {
        public AlloCommandHandler(FtpConnectionObject connectionObject)
            : base("ALLO", connectionObject)
        {

        }

        protected override string OnProcess(string sMessage)
        {
            return GetMessage(202, "Allo processed successfully (depreciated).");
        }

    }
}
