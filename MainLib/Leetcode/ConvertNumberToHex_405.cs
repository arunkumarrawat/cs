using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 405. Convert a Number to Hexadecimal - https://leetcode.com/problems/convert-a-number-to-hexadecimal/
    public class ConvertNumberToHex_405
    {
        public string ToHex(int num)
        {
            if (num == 0) return "0";

            string[] map = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };

            string result = string.Empty;
            //@example: C# - >> unsigned shift left, equal to java >>>
            ulong temp = (ulong)num & 0xFFFFFFFF;

            while(temp != 0)
            {
                result = map[(temp & 15)] + result;

                temp = temp >> 4;
            }

            return result;
        }

        public static void main()
        {
            ConvertNumberToHex_405 s = new ConvertNumberToHex_405();

            Console.WriteLine(s.ToHex(26));
            Console.WriteLine(s.ToHex(-1));
        }

    }
}
