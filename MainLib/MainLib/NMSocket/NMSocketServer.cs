using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace MainLib.NMSocket
{
    public class NMSocketServer
    {
        Socket socket;

        byte[] bytes = new Byte[1024];
        Socket handler = null;
        /// <summary>
        /// 
        /// </summary>
        public NMSocketServer(int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

            // Create a TCP/IP socket.
            socket = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(localEndPoint);
            socket.Listen(port);
        }

        public string receive()
        {
            string data = null;
            try
            {

                // An incoming connection needs to be processed.
                if (handler == null || handler.Connected == false || SocketConnected(handler) == false)
                {
                    handler = socket.Accept();
                    send("220 FTP Server Ready!!!\r\n");
                }

                while (true)
                {
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        break;
                    }
                    return data;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return data;
        }

        public void send(string data)
        {
            if (handler == null) return;

            // Echo the data back to the client.
            byte[] msg = Encoding.ASCII.GetBytes(data);

            handler.Send(msg);
        }

        public void close()
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        public void closeHandler()
        {
            if (handler != null)
            {
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
                handler = null;
            }
        }

        bool SocketConnected(Socket s)
        {
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if (part1 & part2)
            {//connection is closed
                return false;
            }
            return true;
        }
    }
}

/*
 * using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MainLib.NMSocket;
using MainLib;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NMSystem.IsUserAnAdminW());
            NMSocketServer server = new NMSocketServer(21);
            int i = 1;
            while (i <= 6)
            {
                string receive = server.receive();

                

                if (string.IsNullOrEmpty(receive)) continue;

                Console.WriteLine(receive);

                if (receive.StartsWith("QUIT")) 
                    server.closeHandler();

                if(receive.StartsWith("USER"))
                    server.send("331 need password\r\n");
                else
                server.send("220 successfully\r\n");
            }

            server.close();
        }
    }
}

 */
