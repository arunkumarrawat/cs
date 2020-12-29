using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 344. Reverse String - https://leetcode.com/problems/reverse-string/ - AC
    class ReverseString_344
    {

        public string ReverseString(string s)
        {
            char temp;
            //@example: C# - string to char array
            char[] ch = s.ToCharArray();
            for(int i=0;i<s.Length/2;i++)
            {
                temp = ch[i];
                ch[i] = ch[s.Length - 1 - i];
                ch[s.Length - 1 - i] = temp;
            }

            //@example: C# - char array to string
            return new string(ch);
        }

        public static void main()
        {
            string s = "hello";
            ReverseString_344 d = new ReverseString_344();
            Console.WriteLine(d.ReverseString(s));
        }

    }
}
