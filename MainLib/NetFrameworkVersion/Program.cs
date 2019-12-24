using MainLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFrameworkVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                NMSystem system = new NMSystem();

                system.GetVersionFromRegistry();
            }
            catch(Exception e)
            {
                System.Diagnostics.Trace.WriteLine(e.StackTrace);
            }
        }
    }
}
