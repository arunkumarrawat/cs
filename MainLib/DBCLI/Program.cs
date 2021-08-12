using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DBCLI.sageConfig;

namespace DBCLI
{
    class Program
    {
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
        }
    }
}
