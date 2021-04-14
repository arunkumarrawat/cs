using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class TruncateSentence_1816
    {
        public string TruncateSentence(string s, int k)
        {
            string[] sp = s.Split(' ');
            if (k >= sp.Length) return s;

            StringBuilder sb = new StringBuilder();
            for(int i=0;i<k;i++)
            {
                sb.Append(sp[i]);
                sb.Append(" ");
            }

            return sb.ToString().Substring(0, sb.Length - 1);
        }

        public static void main()
        {
            TruncateSentence_1816 s = new TruncateSentence_1816();
            string str = "Hello how are you Contestant";
            int k = 4;
            string result = s.TruncateSentence(str, k);
            Console.WriteLine(result);
        }
    }
}
