using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DBCLI.sageConfig
{
    public class SageCRMInstanceElement : ConfigurationElement
    {
        // Create a property to store the name of the Sage CRM Instance
        // - The "name" is the name of the XML attribute for the property
        // - The IsKey setting specifies that this field is used to identify
        //   element uniquely
        // - The IsRequired setting specifies that a value is required
        [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                // Return the value of the 'name' attribute as a string
                return (string)base["name"];
            }
            set
            {
                // Set the value of the 'name' attribute
                base["name"] = value;
            }
        }

        // Create a property to store the server of the Sage CRM Instance
        // - The "server" is the name of the XML attribute for the property
        // - The IsRequired setting specifies that a value is required
        [ConfigurationProperty("server", IsRequired = true)]
        public string Server
        {
            get
            {
                // Return the value of the 'server' attribute as a string
                return (string)base["server"];
            }
            set
            {
                // Set the value of the 'server' attribute
                base["server"] = value;
            }
        }

        // Create a property to store the installation name of the Sage CRM Instance
        // - The "installationName" is the name of the XML attribute for the property
        // - The IsRequired setting specifies that a value isn't required
        // - The DefaultValue setting specifies a value if none is specified in the XML
        [ConfigurationProperty("installationName", IsRequired = false, DefaultValue = "CRM")]
        public string InstallationName
        {
            get
            {
                return (string)base["installationName"];
            }
            set
            {
                base["installationName"] = value;
            }
        }
    }
}
