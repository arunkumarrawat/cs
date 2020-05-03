using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace YieldReturnTest
{
    class Program
    {
        public static IEnumerable Power(int number, int exponent)
        {
            int counter = 0;
            int result = 1;
            while (counter++ < exponent)
            {
                result = result * number;
                yield return result;
            }
        }

        //@example: List<string>.Where, string list filter using IEnumerable.
        public static void IEnumberableTest()
        {
            List<string> fruits =
            new List<string> { "apple", "passionfruit", "banana", "mango", 
                                "orange", "blueberry", "grape", "strawberry" };

            IEnumerable<string> query = fruits.Where(fruit => fruit.Length < 6);

            foreach (string fruit in query)
            {
                Console.WriteLine(fruit);
            }
        }

        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("yield return test");
            foreach (int i in Power(2, 8))
            {
                Console.WriteLine("{0} ", i);
            }
            Console.ResetColor();

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("IEnumerable return test");

            Console.ResetColor();
        }
    }
}
