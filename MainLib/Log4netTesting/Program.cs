using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4netTesting
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// @example: log4net - configuration and example
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            log.Info("This is a test", new Exception("test exception"));
            log.Error("This is a test", new Exception("test exception"));
        }
    }
}
