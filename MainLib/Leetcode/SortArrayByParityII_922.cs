using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class SortArrayByParityII_922
    {

        public int[] SortArrayByParityII(int[] A)
        {
            int[] result = new int[A.Length];
            List<int> odd = new List<int>();
            List<int> even = new List<int>();

            foreach(int x in A)
            {
                if(x%2 == 0)
                {
                    even.Add(x);
                } 
                else
                {
                    odd.Add(x);
                }
            }

            for(int i=0;i<A.Length;i++)
            {
                if(i%2 == 0)
                {
                    result[i] = even[i/2];
                } else
                {
                    result[i] = odd[(i - 1) / 2];
                }
            }
            return result;
        }

        public static void main()
        {
            SortArrayByParityII_922 s = new SortArrayByParityII_922();
            int[] A = { 4, 2, 5, 7 };
            int[] a = s.SortArrayByParityII(A);
            foreach(int x in a)
            {
                Console.WriteLine(x);
            }

        }
    }
}
