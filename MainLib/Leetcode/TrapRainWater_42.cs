using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 42. Trapping Rain Water - https://leetcode.com/problems/trapping-rain-water/ - AC
    public class TrapRainWater_42
    {
        public int Trap(int[] height)
        {
            int result = 0;
            
            // from left to right, find highest edge
            int[] leftToRight = new int[height.Length];
            // from right to left, find highest edge
            int[] rightToLeft = new int[height.Length];

            int max = 0;

            for(int i=0;i<height.Length;i++)
            {
                if (height[i] > max)
                {
                    max = height[i];
                }

                leftToRight[i] = max;
            }

            max = 0;

            for (int i = height.Length - 1; i >= 0; i--)
            {
                if (height[i] > max)
                {
                    max = height[i];
                }

                rightToLeft[i] = max;
            }

            for (int i = 0; i < height.Length; i++)
            {
                result += (Math.Min(leftToRight[i],rightToLeft[i]) - height[i]);
            }

            return result;
        }

        public static void main()
        {
            int[] height = new int[] { 5,1,2,5,3,4};
            TrapRainWater_42 t = new TrapRainWater_42();
            Console.WriteLine(t.Trap(height));
        }
    }
}
