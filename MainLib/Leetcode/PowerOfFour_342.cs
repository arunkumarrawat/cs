using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 342. Power of Four - https://leetcode.com/problems/power-of-four/ - AC
    public class PowerOfFour_342
    {
        public bool IsPowerOfFour(int num)
        {
            if (num <= 0) return false;

            if (num == 1) return true;

            if((num & (num-1)) == 0)
            {
                double temp = Math.Sqrt(num);

                if(temp == (int)temp)
                {
                    return true;
                }

            }

            return false;
        }

        public static void main()
        {
            PowerOfFour_342 s = new PowerOfFour_342();
            Console.WriteLine(s.IsPowerOfFour(16));
        }
    }
}
