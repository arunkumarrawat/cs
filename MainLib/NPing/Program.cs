using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using MainLib.Network;

namespace NPing
{
    class Program
    {
        static void Main(string[] args)
        {

            if(args.Length < 1)
            {
                Console.WriteLine("NPing <host-address> <counter>");
            }

            if(args.Length < 2)
            {

            }

            CPing ping = new CPing();
            
        }
    }
}
