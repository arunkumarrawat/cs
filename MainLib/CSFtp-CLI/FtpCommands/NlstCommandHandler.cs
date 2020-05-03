using CSFtp_CLI.ftp;
using CSFtp_CLI.FtpCommandsBase;

namespace CSFtp_CLI.FtpCommands
{
    class NlstCommandHandler : ListCommandHandlerBase
    {
        public NlstCommandHandler(FtpConnectionObject connectionObject)
            : base("NLST", connectionObject)
        {

        }

        protected override string BuildReply(string sMessage, string[] asFiles)
        {
            System.Diagnostics.Debugger.Launch();
            if (sMessage == "-L" || sMessage == "-l")
            {
                return BuildLongReply(asFiles);
            }
            else
            {
                return BuildShortReply(asFiles);
            }
        }
    }
}
