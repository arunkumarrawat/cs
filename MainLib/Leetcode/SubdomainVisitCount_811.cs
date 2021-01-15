using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class SubdomainVisitCount_811
    {
        public IList<string> SubdomainVisits(string[] cpdomains)
        {
            List<string> result = new List<string>();

            Dictionary<string, int> dict = new Dictionary<string, int>();

            foreach(string x in cpdomains)
            {
                string[] r = x.Split(' ');
                int count = int.Parse(r[0]);
                string domain = r[1];
                string[] domains = domain.Split('.');
                string output = domains[domains.Length - 1];
                if(dict.ContainsKey(output))
                {
                    dict[output] += count;
                }
                else
                {
                    dict[output] = count;
                }

                for(int i=domains.Length - 2;i>=0;i--)
                {
                    output = domains[i] + "." + output;
                    if (dict.ContainsKey(output))
                    {
                        dict[output] += count;
                    }
                    else
                    {
                        dict[output] = count;
                    }
                }

            }

            foreach (string key in dict.Keys)
            {
                result.Add(dict[key] + " " + key);
            }


            return result;
        }

        public static void main()
        {
            SubdomainVisitCount_811 s = new SubdomainVisitCount_811();
            string[] cpdomains = { "900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org" };
            IList<string> result = s.SubdomainVisits(cpdomains);

            foreach(string x in result)
            {
                Console.WriteLine(x);
            }

        }
    }
}
