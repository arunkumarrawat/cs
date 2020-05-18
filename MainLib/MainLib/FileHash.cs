using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace MainLib
{
    /// <summary>
    /// Get File Hash value
    /// </summary>
    public class FileHash
    {
        /// <summary>
        /// string of md5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string md5str(string input)
        {
            using(var md5 = MD5.Create())
            {
                byte[] result = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                string hex = BitConverter.ToString(result).Replace("-", string.Empty);
                return hex.ToLower();
            }
        }
        /// <summary>
        /// file hash value for md5
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string md5file(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    byte[] result = md5.ComputeHash(stream);
                    string hex = BitConverter.ToString(result).Replace("-", string.Empty);
                    return hex;
                }
            }
        }

        /// <summary>
        /// Example for SHA1 
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static byte[] sha1helper(byte[] bytes)
        {
            const int DATA_SIZE = 10;
            byte[] data = new byte[DATA_SIZE];

            byte[] result;

            SHA1 sha = new SHA1CryptoServiceProvider();
            // This is one implementation of the abstract class SHA1.

            result = sha.ComputeHash(data);
            return result;
        }

        /// <summary>
        /// Compare two Arrays
        /// </summary>
        /// <param name="first">the first array</param>
        /// <param name="two">the second array</param>
        /// <returns></returns>
        public static bool IsEqualTo(byte[] first, byte[] two)
        {
            if (first == two) return true;

            if (first == null && two != null) return false;
            if (first != null && two == null) return false;

            if (first.Length != two.Length) return false;

            for(int i=0;i<first.Length;i++)
            {
                if (first[i] != two[i])
                    return false;
            }

            return true;
        }
        /// <summary>
        /// SHA Get Hash
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static byte[] GetHash(string inputString)
        {
            //HashAlgorithm algorithm = SHA1.Create();  // SHA1.Create()
            using (SHA1 sha = new SHA1CryptoServiceProvider())
            {
                return sha.ComputeHash(Encoding.UTF8.GetBytes(inputString));
            }
        }

        /// <summary>
        /// Get Hash String
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }

        /// <summary>
        /// Hex byte to string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string ByteToString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
