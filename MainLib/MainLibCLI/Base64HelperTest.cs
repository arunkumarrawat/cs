using MainLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLibCLI
{
    public class Base64HelperTest
    {
        public static void TMain(string[] args)
        {
            Base64Helper helper = new Base64Helper();
            string url = "http://www.google.com";
            string base64Encode = helper.Base64Encode(url);
            Console.WriteLine(base64Encode);

            string base64Decode = helper.Base64Decode(base64Encode);
            Console.WriteLine(base64Decode);
        }
    }
}
