using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace TcpServer
{
    class Program
    {

        private const int BUFSIZE = 1024;
        static void Main(string[] args)
        {
            int serverPort = 8000;
            TcpListener listener = null;

            try
            {
                listener = new TcpListener(IPAddress.Any, serverPort);
                listener.Start();
            }
            catch (SocketException e)
            {
                Console.WriteLine(e.ErrorCode + ":" + e.Message);
                Environment.Exit(e.ErrorCode);
            }


            byte[] receiveBuffer = new byte[BUFSIZE];
            int byteReceived;

            for (; ; )
            {
                TcpClient client = null;
                NetworkStream netStream = null;

                try
                {
                    client = listener.AcceptTcpClient();
                    netStream = client.GetStream();
                    Console.WriteLine("Handling Client - ");
                    int totalBytesEchoed = 0;

                    while ((byteReceived = netStream.Read(receiveBuffer, 0, receiveBuffer.Length)) > 0)
                    {
                        //Console.WriteLine(receiveBuffer);
                        netStream.Write(receiveBuffer, totalBytesEchoed, byteReceived);
                        totalBytesEchoed += byteReceived;
                    }

                    Console.WriteLine("echoed {0} bytes.", totalBytesEchoed);
                    //netStream.Close();
                    client.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine( e.Message);
                    //netStream.Close();
                }
            }
        }
    }
}
