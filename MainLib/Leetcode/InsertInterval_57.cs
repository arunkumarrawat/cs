using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 57. Insert Interval - https://leetcode.com/problems/insert-interval/
    public class InsertInterval_57
    {
        public class Interval
        {
            public int start;
            public int end;
            public Interval() { start = 0; end = 0; }
            public Interval(int s, int e) { start = s; end = e; }
        }

        public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
        {
            IList<Interval> result = new List<Interval>();

            foreach (Interval interval in intervals)
            {
                if (newInterval == null)
                {
                    result.Add(interval);
                }
                else if (interval.end < newInterval.start)
                {
                    result.Add(interval);
                }
                else if (interval.start > newInterval.end)
                {
                    result.Add(newInterval);
                    result.Add(interval);
                    newInterval = null;
                }
                else
                {
                    newInterval.start = Math.Min(interval.start, newInterval.start);
                    newInterval.end = Math.Max(interval.end, newInterval.end);
                }
            }

            if (newInterval != null)
                result.Add(newInterval);

            return result;
        }

        public static void main()
        {
            InsertInterval_57 s = new InsertInterval_57();
            //Console.WriteLine(s.Insert(3));


        }
    }


}
