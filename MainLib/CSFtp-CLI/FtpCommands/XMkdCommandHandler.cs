using CSFtp_CLI.ftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFtp_CLI.FtpCommands
{
    class XMkdCommandHandler : MakeDirectoryCommandHandlerBase
    {
        public XMkdCommandHandler(FtpConnectionObject connectionObject)
            : base("XMKD", connectionObject)
        {

        }
    }
}
