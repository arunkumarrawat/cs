using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DBCLI.sageConfig
{
    public class SageCRMConfig : ConfigurationSection
    {
        // Create a property that lets us access the collection
        // of SageCRMInstanceElements

        // Specify the name of the element used for the property
        [ConfigurationProperty("instances")]
        // Specify the type of elements found in the collection
        [ConfigurationCollection(typeof(SageCRMInstanceCollection))]
        public SageCRMInstanceCollection SageCRMInstances
        {
            get
            {
                // Get the collection and parse it
                return (SageCRMInstanceCollection)this["instances"];
            }
        }
    }
}
