using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 149. Max Points on a Line - https://leetcode.com/problems/max-points-on-a-line/
    public class MaxPointsOnaLine
    {
        public class Point
        {
            public int x;
            public int y;
            public Point() { x = 0; y = 0; }
            public Point(int a, int b) { x = a; y = b; }
        }

        public int MaxPoints(Point[] points)
        {
            int result = 0;
            for (int i = 0; i < points.Length; i++)
            {
                int samePoint = 1;

                int sameX = 0;

                Dictionary<double, int> dict = new Dictionary<double, int>();

                for(int j=i+1;j<points.Length;j++)
                {
                    if(points[i].x == points[j].x && points[i].y == points[j].y)
                    {
                        samePoint++;
                    }
                    else if (points[i].x == points[j].x)
                    {
                        sameX++;
                    }
                    else
                    {
                        // @key: points here should be double, otherwise some of data will be fail to pass.
                        double scope = (double)(points[i].y - points[j].y) / (double)(points[i].x - points[j].x);
                        if (dict.ContainsKey(scope))
                            dict[scope]++;
                        else
                            dict.Add(scope, 1);
                    }

                }

                int localMax = 0;

                foreach(double key in dict.Keys)
                {
                    localMax = Math.Max(localMax, dict[key]);
                }

                localMax = Math.Max(localMax, sameX);

                localMax += samePoint;

                result = Math.Max(result, localMax);

            }

            return result;
        }

        public static void main()
        {
            MaxPointsOnaLine s = new MaxPointsOnaLine();
            //Console.WriteLine(s.MaxPoints(3));
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 1);

            Point[] p = new Point[2];

            p[0] = p1;
            p[1] = p2;

            s.MaxPoints(p);
        }
    }
}
