using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLib;

namespace MainLibCLI
{
    public class RandomHelperTest
    {
        public static void TMain(string[] args)
        {
            for(int i=0;i<100;i++)
                Console.WriteLine(RandomHelper.GetRandomInt(1, 100+i));
            
        }
    }
}
