using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebMainLib
{
    public class WebHelper
    {
        /// <summary>
        /// Get IP address from client http header
        /// Need web site to test.
        /// </summary>
        /// <returns></returns>
        public string ClientAddress()
        {
            var userIpAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if(string.IsNullOrEmpty(userIpAddress) || userIpAddress.ToLower() == "unknown")
            {
                userIpAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARD_FOR"];
            }

            return userIpAddress;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ClientAgent()
        {
            return HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"].Replace("'", "");
        }

        /// <summary>
        /// get client server port
        /// </summary>
        /// <returns></returns>
        public string ClientServerPort()
        {
            return HttpContext.Current.Request.ServerVariables["SERVER_PORT"];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ClientRequestServerName()
        {
            return HttpContext.Current.Request.ServerVariables["SERVER_NAME"];
        }
    }
}
