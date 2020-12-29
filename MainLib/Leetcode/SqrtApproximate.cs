using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: algorithm - Sqrt using x1 = (x0 + value/x0)/2 to calculate;
    public class SqrtApproximate
    {
        public float SqrtWithApproximateValue(int value)
        {
            float x0, x1;

            if (value < 0) return -1;

            if (value == 0) return 0;

            x1 = value / 2;

            do
            {
                x0 = x1;
                x1 = (x0 + value / x0) / 2;
            } while (Math.Abs(x1 - x0) >= 1e-5);

            return x1;
        }

        public static void main()
        {
            SqrtApproximate s = new SqrtApproximate();
            Console.WriteLine(s.SqrtWithApproximateValue(10));
        }
    }
}
