using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MainLib
{
    /// <summary>
    /// C# helper class in Evnironment
    /// </summary>
    public class NMEnvironment
    {
        /// <summary>
        /// Environment by Name
        /// </summary>
        /// <param name="environmentName"> such as PATH PATHEXT</param>
        /// <returns>whole string of Environment Name</returns>
        public string GetEnvironment(string environmentName)
        {
            try
            {
                string pathext = Environment.GetEnvironmentVariable(environmentName);
                return pathext;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }
            return string.Empty;
        }

        #region get Desktop Path
        /// <summary>
        /// Desktop Path
        /// </summary>
        /// <returns></returns>
        public string DesktopPath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        }

        /// <summary>
        /// Get Domain Name
        /// </summary>
        /// <returns>Full Domain Name</returns>
        public static string GetDomainName()
        {
            //comparing to Environment.UserDomainName;
            return System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
        }

        /// <summary>
        /// Get Download Folder
        /// </summary>
        /// <returns></returns>
        public static string GetDownloadFolder()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        }
        #endregion get Desktop Path
    }
}
