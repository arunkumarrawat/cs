using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MainLib;

namespace CSFtp_CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHelper fileHelper = new FileHelper("./data/user.txt");

            List<string> content = fileHelper.ToList();

            foreach (string s in content)
            {
                string[] split = s.Split(',');

                foreach(string x in split)
                    Console.WriteLine(x);
            }

        }
    }
}
