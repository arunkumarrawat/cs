using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 389. Find the Difference - https://leetcode.com/problems/find-the-difference/ - AC
    public class FindDifference_389
    {
        public char FindTheDifference(string s, string t)
        {
            int result=0;

            for(int i=0;i<s.Length;i++)
            {
                result ^= (int)s[i];
            }

            for (int i = 0; i < t.Length; i++)
            {
                result ^= (int)t[i];
            }


            return (char)result;
        }

        public static void main()
        {
            FindDifference_389 d = new FindDifference_389();
            Console.WriteLine(d.FindTheDifference("abcd", "abcde"));
        }
    }
}
