using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class LargestPerimeterTriangle_976
    {
        public int LargestPerimeter(int[] A)
        {
            Array.Sort(A);
            for(int i=A.Length - 3;i>=0;i--)
            {
                int l1 = A[i];
                int l2 = A[i + 1];
                int l3 = A[i + 2];

                if((l1+l2)>l3 &&
                    (l1+l3)> l2 &&
                    (l2+l3) > l1
                    )
                {
                    return l1 + l2 + l3;
                }
            }
            return 0;
        }

        public static void main()
        {
            LargestPerimeterTriangle_976 s = new LargestPerimeterTriangle_976();
            int[] A = { 3, 6, 2, 3 };
            int result = s.LargestPerimeter(A);
            Console.WriteLine(result);
        }
    }
}
