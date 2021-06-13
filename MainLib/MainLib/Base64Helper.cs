using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainLib
{
    /// <summary>
    /// Base64 Encode and Decode
    /// </summary>
    public class Base64Helper
    {
        /// <summary>
        /// base64 encode
        /// </summary>
        /// <param name="plainText">input string</param>
        /// <returns></returns>
        public string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// base64 decode
        /// </summary>
        /// <param name="base64EncodedData">input base64 string</param>
        /// <returns></returns>
        public string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}
