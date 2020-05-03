using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace whose
{
    class Helper
    {
        /// <summary>
        /// Print Help
        /// </summary>
        public static void PrintHelp()
        {
            Console.WriteLine("Whose CommandName...");
            Console.WriteLine("For example, Whose notepad mspaint");
            Console.WriteLine("or whose notepad.exe");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentPath"></param>
        public static void TestCurrentPath(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                Console.WriteLine(filePath);
            }
        }
    }
}
