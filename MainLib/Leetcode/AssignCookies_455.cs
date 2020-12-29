using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: 455. Assign Cookies - https://leetcode.com/problems/assign-cookies/
    public class AssignCookies_455
    {
        public int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);

            int gCounter = 0;
            int sCounter = 0;

            while (gCounter < g.Length&&sCounter<s.Length)
            {
                if (g[gCounter] <= s[sCounter])
                {
                    gCounter++;
                    sCounter++;
                }
                else
                    sCounter++;
            }

            return gCounter;

        }


        public static void main()
        {
            int[] g = new int[] { 1, 2, 3 };
            int[] s = new int[] { 1, 1 };

            AssignCookies_455 x = new AssignCookies_455();
            Console.WriteLine(x.FindContentChildren(g, s));

        }

    }
}
