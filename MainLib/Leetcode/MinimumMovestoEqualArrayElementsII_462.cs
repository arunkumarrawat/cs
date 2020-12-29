using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 462. Minimum Moves to Equal Array Elements II - https://leetcode.com/problems/minimum-moves-to-equal-array-elements-ii/
    public class MinimumMovestoEqualArrayElementsII_462
    {
        public int MinMoves2(int[] nums)
        {
            Array.Sort(nums);
            int sum = 0;

            for(int i=0;i<nums.Length/2;i++)
            {
                sum += nums[nums.Length - 1 - i] - nums[i];
            }
            return sum;
        }

        public static void main()
        {
            int[] nums = new int[] { 1, 2, 3 };

            MinimumMovestoEqualArrayElementsII_462 s = new MinimumMovestoEqualArrayElementsII_462();

            Console.WriteLine(s.MinMoves2(nums));
        }
    }
}
