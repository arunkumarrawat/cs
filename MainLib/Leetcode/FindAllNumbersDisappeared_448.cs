using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 448. Find All Numbers Disappeared in an Array - https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/ - AC
    public class FindAllNumbersDisappeared_448
    {
        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            IList<int> result = new List<int>();
            for (int i = 0;i<nums.Length;i++)
            {
                nums[(nums[i] - 1)%nums.Length] += nums.Length;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if(nums[i]<=nums.Length)
                {
                    result.Add(i + 1);
                }
            }

            return result;
        }

        public static void main()
        {
            FindAllNumbersDisappeared_448 s = new FindAllNumbersDisappeared_448();
            int[] test = new int[] { 4, 3, 2, 7, 8, 2, 3, 1 };

            foreach(int i in s.FindDisappearedNumbers(test))
            {
                Console.WriteLine(i);
            }
        }
    }
}
