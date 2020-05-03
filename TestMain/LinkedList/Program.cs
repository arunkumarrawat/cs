using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10];

            for (int i = 0; i < 10; i++)
            {
                a[i] = i+1;
            }

            LinkedList p;
            LinkedList start = new LinkedList(a[0]);
            p = start;

            for (int i = 1; i < 10; i++)
            {
                LinkedList p1 = new LinkedList(a[i]);
                p.Next = p1;
                p = p1;
            }

            LinkedList q;
            q = start;

            while (q != null)
            {
                Console.WriteLine(q.First.ToString());
                q = q.Next;
            }
        }
    }
}
