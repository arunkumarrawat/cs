using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 383. Ransom Note - https://leetcode.com/problems/ransom-note/ - AC
    public class RansomNote_383
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            int length = 128;

            int[] counter_ransomeNote = new int[length];
            int[] counter_magazine = new int[length];


            for(int i=0;i<ransomNote.Length;i++)
            {
                counter_ransomeNote[ransomNote[i] - 'a']++;
            }

            for (int i = 0; i < magazine.Length; i++)
            {
                counter_magazine[magazine[i] - 'a']++;
            }

            for (int i = 0; i < length; i++)
            {
                if(counter_ransomeNote[i] > counter_magazine[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static void main()
        {
            RansomNote_383 s = new RansomNote_383();
            Console.WriteLine(s.CanConstruct("a", "b"));
            Console.WriteLine(s.CanConstruct("aa", "ab"));
            Console.WriteLine(s.CanConstruct("aa", "aab"));
        }
    }
}
