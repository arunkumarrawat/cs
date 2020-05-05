using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CacheTest
{
    class Program
    {

        public class FooEqualityComparer : IEqualityComparer<ObjectTest>
        {
            public int GetHashCode(ObjectTest foo) { return foo.Num.GetHashCode() ^ foo.Num2.GetHashCode(); }
            public bool Equals(ObjectTest foo1, ObjectTest foo2) { return (foo1.Num == foo2.Num) && (foo1.Num2 == foo2.Num2); }
        }


        public class ObjectTest
        {
            private int num;
            private int num2;
            public ObjectTest(int a, int b)
            {
                num = a;
                num2 = b;
            }

            public int Num
            {
                get { return num; }
                set { num = value; }
            }

            public int Num2
            {
                get { return num2; }
                set { num2 = value; }
            }

        }
        static void Main(string[] args)
        {
            Dictionary<ObjectTest, DateTime> dt = new Dictionary<ObjectTest, DateTime>(new FooEqualityComparer());
            ObjectTest obt1 = new ObjectTest(1, 2);
            dt.Add(obt1, DateTime.Now);
            ObjectTest obt2 = new ObjectTest(1, 2);

            if (obt1.GetHashCode() == obt2.GetHashCode())
            {

            }
            if (dt.ContainsKey(obt2))
            {
                Console.WriteLine("Two Objects are Same Now");
            }
        }
    }
}
