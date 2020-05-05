using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading;
using log4net;
using System.Reflection;

namespace Log4NetTest.Test
{
    class Program
    {
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

        static void Main(string[] args)
        {
            //log4net.Config.XmlConfigurator.Configure();

            //ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

            log.Debug("Hello World!");
            log.Info("I'm a simple log4net tutorial.");
            log.Warn("... better be careful ...");
            log.Error("ruh-roh: an error occurred");
            log.Fatal("OMG we're dooooooomed!");

            log.Debug(System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);

            //LogWritter.Debug("web I Debug");

            //LogWritter.Info("web I Info");

            //LogWritter.Error("web I Error");

            //Thread t = new Thread(WriteY);          // Kick off a new thread
            //t.Start();                               // running WriteY()

            //// Simultaneously, do something on the main thread.
            //for (int i = 0; i < 10; i++) log.Debug("x" + i);
        }

        static void WriteY()
        {
            for (int i = 0; i < 1000; i++) log.Debug("y"+i);
        }
    }
}
