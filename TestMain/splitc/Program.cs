using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace splitc
{
    class Program
    {
        static void Help()
        {
            Console.WriteLine("split fileName [No of files]");
        }
        static void Main(string[] args)
        {
            //
            if (args.Length != 2)
            {
                Help();
                return;
            }

            string filePath = args[0];

            FileInfo f = new FileInfo(filePath);

            long size = f.Length;

            

        }
    }
}
