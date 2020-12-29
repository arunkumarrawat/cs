using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class LonelyInteger
    {
        //@example: HackRank - algorithm - 1,1,2,2,3 find a single number from pair
        int lonelyInteger(int[] arr)
        {
            if (arr.Length == 1) return arr[0];

            int result = arr[0];

            for(int i=1;i<arr.Length;i++)
            {
                // 1^1 = 0, same number ^ same number = 0
                result ^= arr[i]; 
            }

            return result;
        }

        public void main()
        {
            int[] arr = new int[3] { 1, 1, 2 };

            Console.WriteLine(lonelyInteger(arr));
        }
    }
}
