using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class EncodeandDecodeTinyURL_535
    {
        // Encodes a URL to a shortened URL
        public string encode(string longUrl)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(longUrl);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        // Decodes a shortened URL to its original URL.
        public string decode(string shortUrl)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(shortUrl);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static void main()
        {
            EncodeandDecodeTinyURL_535 helper = new EncodeandDecodeTinyURL_535();
            string url = "https://www.google.com";
            string base64Encode = helper.encode(url);
            Console.WriteLine(base64Encode);

            string base64Decode = helper.decode(base64Encode);
            Console.WriteLine(base64Decode);
        }
    }
}
