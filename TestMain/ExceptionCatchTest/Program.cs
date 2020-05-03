using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionCatchTest
{
    class Program
    {
        static void GenerateOneException()
        {
            try
            {
                throw new Exception("Generate One Exception");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void Main(string[] args)
        {
            int i = 0;
            GenerateOneException();
            i = 1;
            Console.WriteLine(i);
        }
    }
}
