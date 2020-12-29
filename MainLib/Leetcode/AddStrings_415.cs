using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 415. Add Strings - https://leetcode.com/problems/add-strings/ - AC
    public class AddStrings_415
    {
        public string revert(string num)
        {
            string final = string.Empty;

            for(int i=num.Length - 1;i>=0;i--)
            {
                final += num[i];
            }

            return final;

        }

        public string AddStrings(string num1, string num2)
        {
            string num3 = revert(num1);
            string num4 = revert(num2);

            string minLenStr = num3.Length < num4.Length ? num3 : num4;
            string maxLenStr = num3.Length < num4.Length ? num4 : num3;

            if(num3.Length == num4.Length)
            {
                minLenStr = num3;
                maxLenStr = num4;
            }

            char[] str = new char[maxLenStr.Length+1];

            int carry = 0;

            for (int i = 0; i <= maxLenStr.Length; i++)
            {
                if(i>=minLenStr.Length)
                {
                    if(i==maxLenStr.Length)
                    {
                        if (carry > 0)
                            str[i] = (char)(carry + '0');
                        else
                            str[i] = '0';
                        continue;
                    }

                    int t3 = (maxLenStr[i] - '0');
                    str[i] = (char)((t3 + carry) % 10 + '0');
                    carry = (t3 + carry)/10;
                    continue;
                }
                
                int t1 = (minLenStr[i] - '0');
                int t2 = (maxLenStr[i] - '0');

                
                str[i] = (char)((t1 + t2 + carry) % 10 + '0');

                carry = (t1 + t2 + carry) / 10;
            }

            int startIndex = 0;
            if(str[maxLenStr.Length] == '0')
            {
                startIndex = maxLenStr.Length-1;
            }
            else
                startIndex = maxLenStr.Length;

            string finalResult = string.Empty;

            for(int i=startIndex;i>=0;i--)
            {
                finalResult += str[i];
            }

            return finalResult;
        }

        public static void main()
        {
            AddStrings_415 s = new AddStrings_415();
            string num1 = "99";
            string num2 = "99";
            Console.WriteLine(s.AddStrings(num1, num2));
        }
    }
}
