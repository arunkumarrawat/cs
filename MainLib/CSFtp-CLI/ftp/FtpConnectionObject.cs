using CSFtp_CLI.FtpCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFtp_CLI.ftp
{
    public class FtpConnectionObject : FtpConnectionData
    {
        #region Member Variables

        private System.Collections.Hashtable m_theCommandHashTable = null;
        private IFileSystemClassFactory m_fileSystemClassFactory = null;

        #endregion

        #region Construction

        public FtpConnectionObject(IFileSystemClassFactory fileSystemClassFactory, int nId, System.Net.Sockets.TcpClient socket)
            : base(nId, socket)
        {
            m_theCommandHashTable = new System.Collections.Hashtable();
            m_fileSystemClassFactory = fileSystemClassFactory;

            LoadCommands();
        }

        #endregion

        public bool Login(string sPassword)
        {
            IFileSystem fileSystem = m_fileSystemClassFactory.Create(this.User, sPassword);

            if (fileSystem == null)
            {
                return false;
            }

            SetFileSystemObject(fileSystem);
            return true;
        }

        private void LoadCommands()
        {
            AddCommand(new UserCommandHandler(this));
            AddCommand(new PasswordCommandHandler(this));
            AddCommand(new QuitCommandHandler(this));
            AddCommand(new CwdCommandHandler(this));
            AddCommand(new PortCommandHandler(this));
            AddCommand(new PasvCommandHandler(this));
            AddCommand(new ListCommandHandler(this));
            AddCommand(new NlstCommandHandler(this));
            AddCommand(new PwdCommandHandler(this));
            AddCommand(new XPwdCommandHandler(this));
            AddCommand(new TypeCommandHandler(this));
            AddCommand(new RetrCommandHandler(this));
            AddCommand(new NoopCommandHandler(this));
            AddCommand(new SizeCommandHandler(this));
            AddCommand(new DeleCommandHandler(this));
            AddCommand(new AlloCommandHandler(this));
            AddCommand(new StoreCommandHandler(this));
            AddCommand(new MakeDirectoryCommandHandler(this));
            AddCommand(new RemoveDirectoryCommandHandler(this));
            AddCommand(new AppendCommandHandler(this));
            AddCommand(new RenameStartCommandHandler(this));
            AddCommand(new RenameCompleteCommandHandler(this));
            AddCommand(new XMkdCommandHandler(this));
            AddCommand(new XRmdCommandHandler(this));
        }

        private void AddCommand(FtpCommandHandler handler)
        {
            m_theCommandHashTable.Add(handler.Command, handler);
        }

        public void Process(Byte[] abData)
        {
            string sMessage = System.Text.Encoding.ASCII.GetString(abData);
            sMessage = sMessage.Substring(0, sMessage.IndexOf('\r'));

            FtpServerMessageHandler.SendMessage(Id, sMessage);

            string sCommand;
            string sValue;

            int nSpaceIndex = sMessage.IndexOf(' ');

            if (nSpaceIndex < 0)
            {
                sCommand = sMessage.ToUpper();
                sValue = "";
            }
            else
            {
                sCommand = sMessage.Substring(0, nSpaceIndex).ToUpper();
                sValue = sMessage.Substring(sCommand.Length + 1);
            }

            FtpCommandHandler handler = m_theCommandHashTable[sCommand] as FtpCommandHandler;

            if (handler == null)
            {
                FtpServerMessageHandler.SendMessage(Id, string.Format("\"{0}\" : Unknown command", sCommand));
                SocketHelpers.Send(Socket, "550 Unknown command\r\n");
            }
            else
            {
                handler.Process(sValue);
            }
        }
    }
}