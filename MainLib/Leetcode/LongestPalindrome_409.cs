using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 409. Longest Palindrome - https://leetcode.com/problems/longest-palindrome/ - AC
    public class LongestPalindrome_409
    {
        public int LongestPalindrome(string s)
        {
            int result = 0;
            bool hasMiddle = false;

            int[] counter = new int[128];

            for (int i = 0; i < s.Length; i++)
            {
                char a = s[i];

                counter[a - 'A']++;
            }

            for (int i = 0; i < counter.Length; i++)
            {
                // @note: main idea is to check how many pair of number should be display on 
                if(counter[i] > 0)
                {
                    if (counter[i] % 2 == 0)
                        result += counter[i];

                    if(counter[i] % 2 == 1)
                    {
                        hasMiddle = true;
                        result += counter[i] - 1;
                    }
                }
            }

            if (hasMiddle)
                result += 1;

            return result;
        }

        public static void main()
        {
            LongestPalindrome_409 s = new LongestPalindrome_409();
            Console.WriteLine(s.LongestPalindrome("AAAAAA"));
        }
    }
}
