using CSFtp_CLI.ftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFtp_CLI.FtpCommands
{
    /// <summary>
	/// Present working directory command handler
	/// </summary>
	class PwdCommandHandler : PwdCommandHandlerBase
    {
        public PwdCommandHandler(FtpConnectionObject connectionObject)
            : base("PWD", connectionObject)
        {

        }
    }
}
