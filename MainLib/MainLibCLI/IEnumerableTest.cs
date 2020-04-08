using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainLibUnitTest
{
    public class IEnumerableTest
    {
        public static void TMain(string[] args)
        {
            List<int> numbers = new List<int> { 1, 2 };
            bool hasElements = numbers.Any(e => e == 1);

            Console.WriteLine("how many element has {0}", hasElements);

        }
    }
}
