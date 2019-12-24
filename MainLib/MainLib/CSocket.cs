using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MainLib
{
    /// <summary>
    /// Socket Connection 
    /// </summary>
    public class CSynSocket
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Socket CreateSocketServer()
        {
            try
            {
                // Establish the local endpoint for the socket.
                // Dns.GetHostName returns the name of the 
                // host running the application.
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

                // Create a TCP/IP socket.
                Socket listener = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);

                // Bind the socket to the local endpoint and 
                // listen for incoming connections.
                listener.Bind(localEndPoint);
                listener.Listen(10);

                return listener;
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.InnerException);
            }

            return null;
        }

        public void CreateSocketServerTest()
        {
            string data = null;
            Socket listener = CreateSocketServer();
            while (true)
            {
                Console.WriteLine("Waiting for a connection...");
                // Program is suspended while waiting for an incoming connection.
                Socket handler = listener.Accept();
                data = null;

                // An incoming connection needs to be processed.
                while (true)
                {
                    byte[]  bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        break;
                    }
                }

                // Show the data on the console.
                Console.WriteLine("Text received : {0}", data);

                // Echo the data back to the client.
                byte[] msg = Encoding.ASCII.GetBytes(data);

                handler.Send(msg);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
        }

    }
}
