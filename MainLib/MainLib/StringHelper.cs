using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace MainLib
{
    /// <summary>
    /// String Helper
    /// </summary>
    public class StringHelper
    {
        #region Low and UP
        /// <summary>
        /// Upcase First Letter of str
        /// </summary>
        public string UpcaseFirstLetter(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            if (str.Length == 1)
                return char.ToUpper(str[0]).ToString();

            return char.ToUpper(str[0]) + str.Substring(1);
        }

        /// <summary>
        /// Lowcase First Letter of str
        /// </summary>
        public string LowcaseFirstLetter(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            if (str.Length == 1)
                return char.ToUpper(str[0]).ToString();

            return char.ToLower(str[0]) + str.Substring(1);
        }

        /// <summary>
        /// Low String
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string LowString(string str)
        {
            return str.ToLower(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Low String
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string UpcaseString(string str)
        {
            return str.ToUpper(CultureInfo.InvariantCulture);
        }
        #endregion Low and UP

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private string subString(string str, int startIndex, int length)
        {
            return str.Substring(startIndex, length);
        }

        /// <summary>
        /// Revert All Words by String
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string RevertString(string s)
        {
            string result = string.Empty;

            string[] array = s.Split(' ');

            StringBuilder builder = new StringBuilder();

            for (int i = array.Length - 1; i >= 0; i++)
            {
                builder.Append(array[i]);
                if (i > 0)
                    builder.Append(' ');
            }

            return builder.ToString();
        }

        /// <summary>
        /// output with different format
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public string NumberWithFirstTwoAfterPoint(int d)
        {
            return d.ToString("#,##0.00");
        }

        /// <summary>
        /// add stringToByte
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public byte[] stringToByte(string s)
        {
            return Encoding.ASCII.GetBytes(s);
        }

        /// <summary>
        /// Convert a byte array to a string of hex characters.
        /// </summary>
        /// <param name="value">The byte array to convert.</param>
        /// <returns>The converted string.</returns>
        protected static string ToHexString(byte[] value)
        {
            string hexString = BitConverter.ToString(value, 0);
            return hexString.Replace("-", "");
        }
    }
}
