using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class MultiplyString_43
    {
        public string revert(string num)
        {
            string final = string.Empty;

            for (int i = num.Length - 1; i >= 0; i--)
            {
                final += num[i];
            }

            return final;

        }

        public string Multiply(string num1, string num2)
        {
            string num3 = revert(num1);
            string num4 = revert(num2);

            string minLenStr = num3.Length < num4.Length ? num3 : num4;
            string maxLenStr = num3.Length < num4.Length ? num4 : num3;

            if (num3.Length == num4.Length)
            {
                minLenStr = num3;
                maxLenStr = num4;
            }

            char[] str = new char[minLenStr.Length + maxLenStr.Length + 1];

            int carry = 0;


            for (int i = 0; i < maxLenStr.Length; i++)
            {
                carry = 0;

                for (int j = 0; j < minLenStr.Length; j++)
                {

                }
            }

            return string.Empty;
        }

        public static void main()
        {
            MultiplyString_43 s = new MultiplyString_43();
            string num1 = "123";
            string num2 = "456";
            Console.WriteLine(s.Multiply(num1,num2));
        }
    }
}
