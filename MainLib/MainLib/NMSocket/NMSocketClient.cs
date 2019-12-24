using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace MainLib.NMSocket
{
    public class NMSocketClient
    {
        private Socket socket;

        //buffer
        byte[] bytes = new byte[1024];
        /// <summary>
        /// 
        /// </summary>
        /// <param name="port"></param>
        public NMSocketClient(string hostname, int port)
        {
            try
            {
                IPHostEntry ipHostInfo = Dns.Resolve(hostname);
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP  socket.
            Socket sender = new Socket(AddressFamily.InterNetwork, 
                SocketType.Stream, ProtocolType.Tcp );

            sender.Connect(remoteEP);
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public void Send(string message)
        {
            // Encode the data string into a byte array.
            byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

            // Send the data through the socket.
            int bytesSent = socket.Send(msg);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Receive()
        {
            try
            {
                int bytesRec = socket.Receive(bytes);
                return
                    Encoding.ASCII.GetString(bytes, 0, bytesRec);
            }
            catch (Exception)
            {

            }

            return string.Empty;
        }

        public void close()
        {
            // Release the socket.
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }
    }
}
