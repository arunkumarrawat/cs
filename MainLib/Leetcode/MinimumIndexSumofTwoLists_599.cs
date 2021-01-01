using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class MinimumIndexSumofTwoLists_599
    {
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();

            for(int i=0;i<list1.Length;i++)
            {
                dict[list1[i]] = i;
            }
            List<string> common = new List<string>();
            for (int i = 0; i < list2.Length; i++)
            {
                if (dict.ContainsKey(list2[i]))
                {
                    dict[list2[i]] += i;
                    common.Add(list2[i]);
                } else
                {
                    dict[list2[i]] = int.MaxValue;
                }
            }
            int min = int.MaxValue;

            foreach(string key in common)
            {
                if(min > dict[key])
                {
                    min = dict[key];
                }
            }

            List<string> result = new List<string>();
            foreach(string key in common)
            {
                if(dict[key] == min)
                {
                    result.Add(key);
                }
            }

            return result.ToArray();
        }

        public static void main()
        {
            string[] list1 = {
                "KFC"
            };
            string[] list2 = {
                "KFC"
            };
            MinimumIndexSumofTwoLists_599 d = new MinimumIndexSumofTwoLists_599();
            string[] result = d.FindRestaurant(list1, list2);
            foreach(string x in result)
            {
                Console.WriteLine(x);
            }
        }
    }
}
