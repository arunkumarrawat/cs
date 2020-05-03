using CSFtp_CLI.ftp;
using CSFtp_CLI.FtpCommandsBase;

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
