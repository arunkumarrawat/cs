using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class MaximumNumberofBalloons_1189
    {
        public int MaxNumberOfBalloons(string text)
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();

            foreach(char c in text) {
                if(dict.ContainsKey(c))
                {
                    dict[c] += 1;
                }
                else
                {
                    dict[c] = 1;
                }
            }

            string b = "balloon";

            int result = 0;

            while(true)
            {
                foreach(char c in b)
                {
                    if (dict.ContainsKey(c) && dict[c] > 0)
                    {
                        dict[c] -= 1;
                    }
                    else
                    {
                        return result;
                    }
                }
                result++;
            }
        }

        public static void main()
        {
            MaximumNumberofBalloons_1189 d = new MaximumNumberofBalloons_1189();
            string text = "leetcode";
            Console.WriteLine(d.MaxNumberOfBalloons(text));
        }
    }
}
