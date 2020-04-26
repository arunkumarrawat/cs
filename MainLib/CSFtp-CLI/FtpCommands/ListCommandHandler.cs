using CSFtp_CLI.ftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFtp_CLI.FtpCommands
{
    class ListCommandHandler : ListCommandHandlerBase
    {
        public ListCommandHandler(FtpConnectionObject connectionObject)
            : base("LIST", connectionObject)
        {

        }

        protected override string BuildReply(string sMessage, string[] asFiles)
        {
            System.Diagnostics.Debugger.Launch();
            return BuildLongReply(asFiles);
        }
    }
}
