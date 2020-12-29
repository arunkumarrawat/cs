using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 453. Minimum Moves to Equal Array Elements - https://leetcode.com/problems/minimum-moves-to-equal-array-elements/ - sum + m * (n-1) = x *n ; x = minNum+m; then m = sum - minNum * m;
    public class MinimumMovestoEqualArrayElements_453
    {
        public int MinMoves(int[] nums)
        {
            int sum = 0;
            int min = int.MaxValue;

            for(int i=0;i<nums.Length;i++)
            {
                sum += nums[i];

                if (nums[i] < min)
                    min = nums[i];
            }

            return sum - min * nums.Length;
        }

        public static void main()
        {

        }
    }
}
