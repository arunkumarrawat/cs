using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class CalculateMoneyinLeetcodeBank_1716
    {
        public int TotalMoney(int n)
        {
            int result = 0;

            int i = 0;
            int b = 1;
            while(i<n)
            {
                result += (b + i % 7);
                i++;
                if(i%7 == 0)
                {
                    b++;
                }
            }

            return result;
        }

        public static void main()
        {
            CalculateMoneyinLeetcodeBank_1716 s = new CalculateMoneyinLeetcodeBank_1716();
            int result = s.TotalMoney(20);
            Console.WriteLine(result);
        }
    }
}
