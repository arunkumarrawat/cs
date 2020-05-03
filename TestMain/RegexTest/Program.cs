using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RegexTest
{
    //@example: C# regex expression
    class Program
    {
        static void Main(string[] args)
        {
            String ConnectionString = "FF,5,10,11,12,FF,FF,FF";
            Regex regex = new Regex("^([0-9a-fA-F]{1,2},){7}[0-9a-fA-F]{1,2}$");
            bool b = regex.IsMatch(ConnectionString);


            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 4, 8, 9, 44 });

            List<int> evenNumbers = list.FindAll((i) =>
            {
                Console.WriteLine("value of i is currently: {0}", i);
                bool isEven = ((i % 2) == 0);
                return isEven;
            });

            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();

        }
    }
}
