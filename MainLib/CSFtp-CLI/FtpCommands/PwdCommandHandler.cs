using CSFtp_CLI.ftp;
using CSFtp_CLI.FtpCommandsBase;

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
