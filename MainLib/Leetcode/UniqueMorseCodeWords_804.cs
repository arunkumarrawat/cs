using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class UniqueMorseCodeWords_804
    {
        public int UniqueMorseRepresentations(string[] words)
        {
            string[] mapping = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach (string s in words)
            {
                StringBuilder sb = new StringBuilder();
                foreach(char c in s)
                {
                    string morseCode = mapping[c - 'a'];
                    sb.Append(morseCode);
                }

                if (dict.ContainsKey(sb.ToString()))
                {
                    dict[sb.ToString()] += 1;
                }
                else
                {
                    dict[sb.ToString()] = 1;
                }
            }

            return dict.Keys.Count;
        }
        public static void main()
        {
            UniqueMorseCodeWords_804 d = new UniqueMorseCodeWords_804();
            string[] words = { "gin", "zen", "gig", "msg" };
            Console.WriteLine(d.UniqueMorseRepresentations(words));
        }
    }
}
