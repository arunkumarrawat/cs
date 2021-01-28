using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class LargestTriangleArea_812
    {
        public double LargestTriangleArea(int[][] points)
        {
            double max = 0;
            for(int i=0;i<points.Length;i++)
            {
                for(int j=i+1;j<points.Length;j++)
                {
                    for(int k = j+1;k<points.Length;k++)
                    {
                        double a = Math.Sqrt(Math.Pow(points[i][0] - points[j][0], 2) + Math.Pow(points[i][1] - points[j][1], 2));
                        double b = Math.Sqrt(Math.Pow(points[i][0] - points[k][0], 2) + Math.Pow(points[i][1] - points[k][1], 2));
                        double c = Math.Sqrt(Math.Pow(points[j][0] - points[k][0], 2) + Math.Pow(points[j][1] - points[k][1], 2));
                        double p = (a+b+c) / 2;
                        double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
                        if (max < s) max = s;
                    }
                }
            }
            return max;
        }

        public static void main()
        {
            LargestTriangleArea_812 s = new LargestTriangleArea_812();
            int[,] p = { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 0, 2 }, { 2, 0 } };
            int[][] points = new int[p.GetLength(0)][];
            for(int i=0;i<p.GetLength(0);i++)
            {
                int t = p.GetLength(1);
                points[i] = new int[t];
                for(int j=0;j<t;j++)
                {
                    points[i][j] = p[i, j];
                }
            }

            double result = s.LargestTriangleArea(points);
            Console.WriteLine(result);
        }
    }
}
