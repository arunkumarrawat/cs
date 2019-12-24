using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace MainLib.Network
{
    public class CPing
    {
        public event EventHandler PingSuccessfulHandler;

        public void StartPing(string host,int counterTime)
        {
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
            reply = pingSender.Send(host, timeout, buffer, options);

            int counter = counterTime;
            while (counter-- > 0)
            {
                if (reply.Status == IPStatus.Success)
                {
                    if (PingSuccessfulHandler != null)
                        PingSuccessfulHandler(reply, new EventArgs());
                }
                Thread.Sleep(1000);
            }

            /*
             * Console.Write("Reply from: {0}\t", reply.Address.ToString());
                    //Console.Write("RoundTrip time: {0}\t", reply.RoundtripTime);
                    Console.Write("Time to live: {0}\t", reply.Options.Ttl);
                    //Console.Write("Don't fragment: {0}\t", reply.Options.DontFragment);
                    Console.Write("Bytes: {0}\t", reply.Buffer.Length);
                    Console.WriteLine("");
             */
        }
    }
}
