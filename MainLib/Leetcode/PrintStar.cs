using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class PrintStar
    {
        //@example: HackRank - algorithm - print out #  ##    ###
        static void StairCase(int n)
        {
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    if (n - i <= (k+1))
                    {
                            Console.Write('#');
                    }
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        public void main()
        {
            StairCase(6);
        }
    }
}
