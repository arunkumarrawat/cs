using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLib;

namespace MainLibCLI
{
    public class ArrayHelperTest
    {
        public static void TMain(string[] args)
        {
            int[] a = { 1, 2, 3 };
            int[] b = { 4, 5, 6 };
            int[] c = (int[]) ArrayHelper.Concat(a, b);

            foreach(int x in c)
            {
                Console.WriteLine(x);
            }
        }
    }
}
