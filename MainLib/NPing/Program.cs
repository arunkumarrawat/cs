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
            string configvalue1 = ConfigurationManager.AppSettings["countoffiles"];
            string configvalue2 = ConfigurationManager.AppSettings["logfilelocation"];

            Console.WriteLine(configvalue1);
            Console.WriteLine(configvalue2);

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
