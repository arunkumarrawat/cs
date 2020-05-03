using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Reflection;

namespace ServiceWithMultithread
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            Service1 service = new Service1();

            if (args.Length > 0)
            {
                Assembly assembly = Assembly.GetEntryAssembly();
                Console.WriteLine(assembly.GetName());

                service.ServiceOnStart(args);
                Console.WriteLine("Press Q to quit");
                while (Console.ReadKey().KeyChar != 'Q') ;
                service.ServiceOnStop();
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
			    { 
				    service 
			    };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
