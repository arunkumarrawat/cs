using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace PingTest
{
    //@example: ping in C#
    class Program
    {
        static void printHelp()
        {
            Console.WriteLine("PintTest [target IPAddress]");
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                printHelp();    
                return;
            }
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 1200;
            PingReply reply;
            while (true)
            {
                reply = pingSender.Send(args[0], timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    Console.Write("Reply from: {0}\t", reply.Address.ToString());
                    //Console.Write("RoundTrip time: {0}\t", reply.RoundtripTime);
                    Console.Write("Time to live: {0}\t", reply.Options.Ttl);
                    //Console.Write("Don't fragment: {0}\t", reply.Options.DontFragment);
                    Console.Write("Bytes: {0}\t", reply.Buffer.Length);
                    Console.WriteLine("");
                }
                Thread.Sleep(1000);
            }
        }
    }
}
