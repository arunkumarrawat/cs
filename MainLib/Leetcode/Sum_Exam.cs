using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    class Sum_Exam
    {

        static int sum(int[] numbers)
        {
            int result = 0;

            for(int i=0;i<numbers.Length;i++)
            {
                result += numbers[i];
            }

            return result;
        }

        public static void main()
        {
            int[] a = new int[5] { 1, 2, 3, 4, 5 };
            Console.WriteLine(sum(a));
        }
    }
}
