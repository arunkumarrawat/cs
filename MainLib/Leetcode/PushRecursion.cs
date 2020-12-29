using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class PushRecursion
    {
        public int[] revert(int[] array)
        {
            foo(array[0], array, 0);
            return array;
        }

        public void foo(int c, int[] array,int index)
        {
            if(index == array.Length - 1)
            {
                array[array.Length - 1 - index] = c;
                return;
            }

            foo(array[index + 1], array, index + 1);
            array[array.Length - 1 - index] = c;
        }

        public void main()
        {
            int[] array = { 1, 2, 3, 4, 5 };
            int[] result = revert(array);
            for(int i=0;i<result.Length;i++)
            {
                Console.Write(result[i] + "\t");
            }
        }
    }
}
