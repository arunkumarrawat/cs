using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class PathCrossing_1496
    {
        public bool IsPathCrossing(string path)
        {
            int x = 0;
            int y = 0;
            Dictionary<int, List<int>> d = new Dictionary<int, List<int>>();
            d.Add(x, new List<int>() { y });
            for(int i=0;i<path.Length;i++)
            {
                char t = path[i];
                switch (t) {
                    case 'N':
                        y += 1;
                        break;
                    case 'S':
                        y -= 1;
                        break;

                    case 'E':
                        x += 1;
                        break;
                    case 'W':
                        x -= 1;
                        break;
                }

                if(d.ContainsKey(x))
                {
                    List<int> y1 = d[x];
                    if(y1.Contains(y))
                    {
                        return true;
                    }
                    else
                    {
                        y1.Add(y);
                        d[x] = y1;
                    }
                }
                else
                {
                    d.Add(x, new List<int>() { y });
                }

            }

            return false;
        }
        public static void main()
        {
            PathCrossing_1496 s = new PathCrossing_1496();
            bool result = s.IsPathCrossing("NES");
            Console.WriteLine(result);
        }
    }
}
