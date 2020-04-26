using CSFtp_CLI.ftp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFtp_CLI.FtpCommands
{
    class StoreCommandHandler : FtpCommandHandler
    {
        private const int m_nBufferSize = 65536;

        public StoreCommandHandler(FtpConnectionObject connectionObject)
            : base("STOR", connectionObject)
        {

        }

        protected override string OnProcess(string sMessage)
        {
            string sFile = GetPath(sMessage);

            if (ConnectionObject.FileSystemObject.FileExists(sFile))
            {
                return GetMessage(553, "File already exists.");
            }

            IFile file = ConnectionObject.FileSystemObject.OpenFile(sFile, true);

            FtpReplySocket socketReply = new FtpReplySocket(ConnectionObject);

            if (!socketReply.Loaded)
            {
                return GetMessage(425, "Error in establishing data connection.");
            }

            byte[] abData = new byte[m_nBufferSize];

            SocketHelpers.Send(ConnectionObject.Socket, GetMessage(150, "Opening connection for data transfer."));

            int nReceived = socketReply.Receive(abData);

            while (nReceived > 0)
            {
                file.Write(abData, nReceived);
                nReceived = socketReply.Receive(abData);
            }

            file.Close();
            socketReply.Close();

            return GetMessage(226, "Uploaded file successfully.");
        }
    }
}
