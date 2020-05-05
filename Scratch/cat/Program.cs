using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace cat
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * ToDo
             * */
            if (args.Length == 0)
            {
                Console.WriteLine("Cat [file1] [file2] ... [fileN]");
            }


            StringBuilder sb = new StringBuilder();
            foreach (string fileName in args)
            {
                if (File.Exists(fileName))
                {
                    Console.WriteLine(fileName + ":" + Environment.NewLine);
                    Console.WriteLine(File.ReadAllText(fileName));
                }
                else
                {
                    sb.Append(fileName + " doesn't exists." + Environment.NewLine);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
