using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: LeetCode - 204 Count Primes - https://leetcode.com/problems/count-primes/
    class CountPrimes_204
    {
        public int CountPrimes(int n)
        {
            //if (n <= 1) return 0;
            //if (n == 2) return 0;
            //if (n == 3) return 1;

            //Stack<int> s = new Stack<int>();

            //s.Push(2);
            //s.Push(3);

            //for(int j=4;j<n;j++)
            //{
            //    int[] array = s.ToArray();

            //    bool flag = true;
            //    for(int i=0;i<array.Length;i++)
            //    {
            //        if (j % array[i] == 0)
            //        {
            //            flag = false;
            //            break;
            //        }
            //    }

            //    if (flag)
            //        s.Push(j);
            //}

            //return s.Count;

            bool[] result = new bool[n];

            int counter = 0;

            for(int i=2;i<n;i++)
            {
                if(result[i]==false)
                {
                    counter++;

                    for(int j=2;i*j<n;j++)
                    {
                        result[i * j] = true;
                    }
                }
            }

            return counter;

        }
        public static void main()
        {
            CountPrimes_204 s = new CountPrimes_204();
            Console.WriteLine(s.CountPrimes(6));
        }
    }
}
