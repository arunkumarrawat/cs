using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 412. Fizz Buzz - https://leetcode.com/problems/fizz-buzz/ - AC
    public class FizzBuzz_412
    {
        public IList<string> FizzBuzz(int n)
        {
            List<string> result = new List<string>();

            for(int i=1;i<=n;i++)
            {
                if(i%15 == 0)
                {
                    result.Add("FizzBuzz");
                }
                else if(i%3 == 0)
                {
                    result.Add("Fizz");
                }
                else if(i%5 == 0)
                {
                    result.Add("Buzz");
                }
                else
                {
                    result.Add(i.ToString());
                }
            }

            return result;
        }

        public static void main()
        {

        }
    }
}
