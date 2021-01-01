using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    public class DesignanOrderedStream_1656
    {
        public class OrderedStream
        {
            string[] orders;
            int ptr;
            public OrderedStream(int n)
            {
                orders = new string[n+2];
                ptr = 1;
            }

            public IList<string> Insert(int id, string value)
            {
                orders[id] = value;
                IList<string> list = new List<string>();

                while(true)
                {
                    if(string.IsNullOrEmpty(orders[ptr]))
                    {
                        return list;
                    } else
                    {
                        list.Add(orders[ptr++]);
                    }
                }
            }
        }

        public static void dumpList(IList<string> list)
        {
            foreach(string x in list)
            {
                Console.Write(x + "\t");
            }
            Console.WriteLine();
        }

        public static void main()
        {
            OrderedStream os = new OrderedStream(5);
            IList<string> list = os.Insert(3, "ccccc"); // Inserts (3, "ccccc"), returns [].
            dumpList(list);
            list = os.Insert(1, "aaaaa"); // Inserts (1, "aaaaa"), returns ["aaaaa"].
            dumpList(list);
            list = os.Insert(2, "bbbbb"); // Inserts (2, "bbbbb"), returns ["bbbbb", "ccccc"].
            dumpList(list);
            list = os.Insert(5, "eeeee"); // Inserts (5, "eeeee"), returns [].
            dumpList(list);
            list = os.Insert(4, "ddddd"); // Inserts (4, "ddddd"), returns ["ddddd", "eeeee"].
            dumpList(list);
        }
    }
}
