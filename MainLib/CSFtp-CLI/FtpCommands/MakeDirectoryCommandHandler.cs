using CSFtp_CLI.ftp;
using CSFtp_CLI.FtpCommandsBase;

namespace CSFtp_CLI.FtpCommands
{
    class MakeDirectoryCommandHandler : MakeDirectoryCommandHandlerBase
    {
        public MakeDirectoryCommandHandler(FtpConnectionObject connectionObject)
            : base("MKD", connectionObject)
        {

        }
    }
}
