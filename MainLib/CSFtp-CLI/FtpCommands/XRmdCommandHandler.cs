using CSFtp_CLI.ftp;
using CSFtp_CLI.FtpCommandsBase;

namespace CSFtp_CLI.FtpCommands
{
    class XRmdCommandHandler : RemoveDirectoryCommandHandlerBase
    {
        public XRmdCommandHandler(FtpConnectionObject connectionObject)
            : base("XRMD", connectionObject)
        {

        }
    }
}
