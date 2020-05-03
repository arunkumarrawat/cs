using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionTest
{
    public class MyExeption : Exception
    {
        public MyExeption()
            : base("Devided by zero")
        {

        }
    }
    class Program
    {
        static double SafeDivision(double x, double y)
        {
            if (y == 0)
                throw new MyExeption();
            return x / y;
        }
        static void Main(string[] args)
        {
            // Input for test purposes. Change the values to see
            // exception handling behavior.
            double a = 98, b = 0;
            double result = 0;

            try
            {
                result = SafeDivision(a, b);
                Console.WriteLine("{0} divided by {1} = {2}", a, b, result);
            }
            catch (MyExeption e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
