using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFtp_CLI.ftp
{
    /// <summary>
	/// Encapsulates the functionality necessary to send data along the reply connection
	/// </summary>
	class FtpReplySocket
    {
        private System.Net.Sockets.TcpClient m_theSocket;

        public FtpReplySocket(FtpConnectionObject connectionObject)
        {
            m_theSocket = OpenSocket(connectionObject);
        }

        public bool Loaded
        {
            get
            {
                return m_theSocket != null;
            }
        }

        public void Close()
        {
            SocketHelpers.Close(m_theSocket);
            m_theSocket = null;
        }

        public bool Send(byte[] abData, int nSize)
        {
            return SocketHelpers.Send(m_theSocket, abData, 0, nSize);
        }

        public bool Send(char[] abChars, int nSize)
        {
            return SocketHelpers.Send(m_theSocket, System.Text.Encoding.ASCII.GetBytes(abChars), 0, nSize);
        }

        public bool Send(string sMessage)
        {
            byte[] abData = System.Text.Encoding.ASCII.GetBytes(sMessage);
            return Send(abData, abData.Length);
        }

        public int Receive(byte[] abData)
        {
            return m_theSocket.GetStream().Read(abData, 0, abData.Length);
        }

        static private System.Net.Sockets.TcpClient OpenSocket(FtpConnectionObject connectionObject)
        {
            System.Net.Sockets.TcpClient socketPasv = connectionObject.PasvSocket;

            if (socketPasv != null)
            {
                connectionObject.PasvSocket = null;
                return socketPasv;
            }

            return SocketHelpers.CreateTcpClient(connectionObject.PortCommandSocketAddress, connectionObject.PortCommandSocketPort);
        }
    }
}
