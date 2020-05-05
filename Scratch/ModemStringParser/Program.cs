using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ModemStringParser
{
    class Program
    {
        static void Main(string[] args)
        {
            TextWriter tw = new StreamWriter(@"D:\\workspace\\output.sql", false, Encoding.GetEncoding("UTF-8"));
            using (TextReader reader = new StreamReader("C:\\GMS\\MODEMSTR.CONFIG"))
            {
                String line;
                String typeId;
                String modemName;
                String connectionString;
                String initializationString;
                String pollString;
                String responseString;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("--"))
                    {
                        
                    }
                    Console.WriteLine(line);
                }
                reader.Close();
            }
            tw.Close();

            /*
             * --3 name
             * 0
             * 0,0,0,0,0,0,0,0
             * asdf
             * asdf
             * ;
             * asdf
             * ;
             * asdf
             * */
            

        }
    }
}
