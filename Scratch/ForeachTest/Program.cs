using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
 * problems: Try to delete an item in the foreach. 
 * It will make Enumerator fail to work
 */

namespace ForeachTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> abc = new List<string>();
            List<string> Temp = new List<string>();
            abc.Add("abc");
            abc.Add("def");

            //This is wrong 
            //foreach (string n in abc)
            //{
            //    if (n == "abc")
            //        abc.Remove(n);
            //}

            for (int i = 0; i < abc.Count; i++)
            {                
               if (abc[i] == "abc")
               {
                   abc.RemoveAt(i);
                   i--;
               }
            }


            foreach (string n in abc)
            {
                Console.WriteLine(n);
            }

        }
    }
}
