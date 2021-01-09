using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    class SquaresofaSortedArray_977
    {
        public int[] SortedSquares(int[] nums)
        {
            List<int> t = new List<int>();
            List<int> t1 = new List<int>();
            int i = 0;
            for (i=0;i<nums.Length;i++)
            {
                if(nums[i]<0)
                {
                    t.Add(nums[i]* nums[i]);
                } else
                {
                    t1.Add(nums[i] * nums[i]);
                }
            }

            t.Reverse();

            i = 0;
            int i1 = 0;

            List<int> result = new List<int>();

            while (i < t.Count && i1<t1.Count)
            {
                if(t[i] < t1[i1])
                {
                    result.Add(t[i]);
                    i++;
                } else
                {
                    result.Add(t1[i1]);
                    i1++;
                }
            }

            if(i < t.Count)
            {
                for(int m = i;m<t.Count;m++)
                {
                    result.Add(t[m]);
                }
            }

            if (i1 < t1.Count)
            {
                for (int m = i1; m < t1.Count; m++)
                {
                    result.Add(t1[m]);
                }
            }
            return result.ToArray();
        }

        public static void main()
        {
            int[] nums = { -1, 2, 2 };
            SquaresofaSortedArray_977 s = new SquaresofaSortedArray_977();

            int[] result = s.SortedSquares(nums);
            foreach(int x in result)
            {
                Console.WriteLine(x);
            }
        }
    }
}
