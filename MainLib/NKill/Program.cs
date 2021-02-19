using MainLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NKill
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if(args.Length != 1)
                {

                }
                SystemHelper system = new SystemHelper();

                system.KillProcessByName();
            }
            catch (Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.StackTrace);
            }
        }
    }
}
