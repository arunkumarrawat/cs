using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - Sqrt(x) - https://leetcode.com/problems/sqrtx/ - AC using binary search
    public class MySqrt_69
    {
        public int MySqrt(int x)
        {
            if (x == 0) return 0;
            if (x == 1) return 1;

            int l = 1, w = x, res = 0;

            int mid;
            while(l<w)
            {
                mid = (l + w) / 2;

                if(mid > x/mid)
                {
                    w = mid - 1;
                }
                else
                {
                    //very important: mid * mid < x and x< (mid + 1) * (mide + 1), then mid is answer
                    if (mid + 1 > x / (mid + 1))
                        return mid;

                    l = mid + 1;

                    if (l == x / l)
                        return l;
                }
            }

            return w;
        }
        public static void main()
        {
            MySqrt_69 s = new MySqrt_69();
            Console.WriteLine(s.MySqrt(3));

        }

    }
}
