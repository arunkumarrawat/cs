using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class HammingDistance_461
    {
        public int HammingDistance(int x, int y)
        {
            int result = x ^ y;
            int counter = 0;
            for(int i=0;i<=31;i++)
            {
                if (result % 2 == 1) counter++;
                result >>= 1;
            }
            return counter;
        }

        public static void main()
        {
            HammingDistance_461 s = new HammingDistance_461();

            Console.WriteLine(s.HammingDistance(1,4));
        }
    }
}
