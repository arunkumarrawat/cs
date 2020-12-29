using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: algorithm - PI aproximate value using arctan(x) = 1 - (x^3/3) + (x^5/5) - (x^7/7) ...
    public class PIApproximate
    {
        public float PICalculate()
        {
            float result = 1;
            float x1;
            int counter = 0;
            int x = 3;

            do
            {
                x1 =  ((float)1 / (float)(x + 2 * counter));

                x1 *= counter % 2 == 0 ? -1 : 1;

                result += x1;

                counter++;
            } while (Math.Abs(x1) > 1e-7);

            return result*4;
        }

        public static void main()
        {
            PIApproximate s = new PIApproximate();
            Console.WriteLine(s.PICalculate());
        }
    }
}
