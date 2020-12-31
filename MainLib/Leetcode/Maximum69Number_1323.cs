using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class Maximum69Number_1323
    {
        public int Maximum69Number(int num)
        {
            string s = num.ToString();
            StringBuilder sb = new StringBuilder();
            bool isGet = true;
            for(int i=0;i<s.Length;i++)
            {
                if(s[i] == '6' && isGet)
                {
                    sb.Append('9');
                    isGet = false;
                }
                else
                {
                    sb.Append(s[i]);
                }
            }
            

            return int.Parse(sb.ToString());
        }

        public static void main()
        {
            Maximum69Number_1323 s = new Maximum69Number_1323();
            int num = 9669;
            Console.WriteLine(s.Maximum69Number(num));
        }
    }
}
