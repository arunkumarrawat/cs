using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Grouping
{
    class Program
    {
        //@example: Linq Group by condition
        static void Main(string[] args)
        {
            DataTable dt = new DataTable("Numbers");
            dt.Columns.Add("number", typeof(int));
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            foreach (int n in numbers)
            {
                dt.Rows.Add(n);
            }

            var EnumerableNumbers = dt.AsEnumerable();

            var numberGroups =
                from n in EnumerableNumbers
                group n by n.Field<int>("number") % 5 into g
                select new { Remainder = g.Key, gNumbers = g };

            foreach (var g in numberGroups)
            {
                Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", g.Remainder);
                foreach (var n in g.gNumbers)
                {
                    Console.WriteLine(n.Field<int>("number"));
                }
            }
        }
    }
}
