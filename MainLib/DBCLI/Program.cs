using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DBCLI.sageConfig;
using System.Diagnostics;

namespace DBCLI
{
    class Program
    {
        private static void OnEntryWritten(object source, EntryWrittenEventArgs e)
        {
            string watchLog = "System";
            string logName = watchLog;
            int e1 = 0;
            EventLog log = new EventLog(logName);
            e1 = log.Entries.Count - 1; // last entry
            Console.WriteLine(log.Entries[e1].Message);
            log.Close();  // close log
        }


        static void Main(string[] args)
        {

            string configvalue1 = ConfigurationManager.AppSettings["countoffiles"];
            string configvalue2 = ConfigurationManager.AppSettings["logfilelocation"];

            Console.WriteLine(configvalue1);
            Console.WriteLine(configvalue2);

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;
            Console.WriteLine(connectionString);

            var sageConfig = (SageCRMConfig)ConfigurationManager.GetSection("sageCRM");

            // Loop through each instance in the SageCRMInstanceCollection
            foreach (SageCRMInstanceElement instance in sageConfig.SageCRMInstances)
            {
                // Write the instance information to the Console
                Console.WriteLine("{0} {1} {2}",
                    instance.Name,
                    instance.Server,
                    instance.InstallationName);
            }

            while (true)
            {
                string watchLog = "System";
                EventLog myLog = new EventLog(watchLog);
                // set event handler
                myLog.EntryWritten += new EntryWrittenEventHandler(OnEntryWritten);
                myLog.EnableRaisingEvents = true;
            }


        }
    }
}
