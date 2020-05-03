using CSFtp_CLI.ftp;
using CSFtp_CLI.FtpCommandsBase;

namespace CSFtp_CLI.FtpCommands
{
    class RemoveDirectoryCommandHandler : RemoveDirectoryCommandHandlerBase
    {
        public RemoveDirectoryCommandHandler(FtpConnectionObject connectionObject)
            : base("RMD", connectionObject)
        {

        }
    }
}
