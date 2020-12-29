using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 477. Total Hamming Distance - https://leetcode.com/problems/total-hamming-distance/ - AC
    public class TotalHammingDistance_477
    {
        // @example:  Leetcode - Total HammingDistance
        //public int HammingDistance(int x, int y)
        //{
        //    int result = x ^ y;
        //    int counter = 0;
        //    for (int i = 0; i <= 31; i++)
        //    {
        //        if (result % 2 == 1) counter++;
        //        result >>= 1;
        //    }
        //    return counter;
        //}

        //public int TotalHammingDistance(int[] nums)
        //{
        //    int result = 0;

        //    if (nums == null || nums.Length == 0) return result;
        //    for (int i = 0; i < nums.Length; i++)
        //    {
        //        for (int j = i; j < nums.Length; j++)
        //        {
        //            result += HammingDistance(nums[i], nums[j]);
        //        }
        //    }

        //    return result;
        //}

        //@example: Leetcode - Total Hamming Distance -  key: if bits in same position has k zeros and (n-k) ones, then there are n*(n-k) distance for this position 
        public int TotalHammingDistance(int[] nums)
        {
            int total = 0;
            int mask = 1;
            for(int i=0;i<31;i++)
            {
                int zeros = 0, ones = 0;
                for(int j=0;j<nums.Length;j++)
                {
                    if ((nums[j] & mask) == 0)
                        zeros++;
                    else
                        ones++;

                }

                total += zeros * ones;
                mask <<= 1;
            }

            return total;
        }

        public static void main()
        {
            TotalHammingDistance_477 s = new TotalHammingDistance_477();
            int[] nums = new int[] { 4, 14, 2 };
            Console.WriteLine(s.TotalHammingDistance(nums));
        }
    }
}
