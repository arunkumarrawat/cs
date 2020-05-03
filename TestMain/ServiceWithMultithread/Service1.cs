using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace ServiceWithMultithread
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        public void ServiceOnStart(string[] args)
        {
            OnStart(args);
        }

        public void ServiceOnStop()
        {
            OnStop();
        }

        protected override void OnStart(string[] args)
        {
            Thread.CurrentThread.Name = "Service";
            System.Diagnostics.Trace.WriteLine("########################### OnStart");
        }

        protected override void OnStop()
        {
            System.Diagnostics.Trace.WriteLine("########################### OnStop");
        }
    }
}
