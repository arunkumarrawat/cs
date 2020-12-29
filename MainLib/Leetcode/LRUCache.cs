using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 146. LRU Cache - https://leetcode.com/problems/lru-cache/ - AC
    public class LRUCache
    {
        private int capacity = 0;

        public class keyValue
        {
            public int key;
            public int value;

            public keyValue(int key,int value)
            {
                this.key = key;
                this.value = value;
            }
        }

        public class ListNode
        {
            public keyValue val;
            public ListNode next;
            public ListNode prev;
            public ListNode(keyValue x) { val = x; next = null; prev = null; }
        }

        ListNode header = new ListNode(null);
        ListNode tail = new ListNode(null);
        ListNode current;
        int counter = 0;


        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            current = header;
            header.next = tail;
            tail.prev = header;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Get(int key)
        {
            Console.WriteLine("get(" +key+")" );

            ListNode p = header.next;
            // loop though header to tail, if one of list node is hit, move it to header.next 
            while (p != tail)
            {
                if (p.val.key == key)
                {
                    

                    p.prev.next = p.next;

                    p.next.prev = p.prev;

                    ListNode p1 = header.next;

                    header.next = p;
                    p.prev = header;

                    p.next = p1;
                    p1.prev = p;

                    return p.val.value;
                }

                p = p.next;
            }

            return -1;
        }
        /// <summary>
        /// Set, the latest one one the top.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Set(int key, int value)
        {
            Console.WriteLine("set(" + key + " " + value +")");

            ListNode p = header.next;

            // once key is hit, move key up to top
            while (p != tail)
            {
                if (p.val.key == key)
                {
                    p.val.value = value;

                    p.prev.next = p.next;
                    p.next.prev = p.prev;

                    ListNode p1 = header.next;

                    header.next = p;
                    p.prev = header;

                    p.next = p1;
                    p1.prev = p;

                    return;
                }
                p = p.next;
            }

            current = null;

            // delete last item when counter is same as capacity
            if (counter >= capacity)
            {
                ListNode p2 = tail.prev.prev;

                p2.next = tail;
                tail.prev = p2;
                counter--;
            }
            
            keyValue kv = new keyValue(key, value);

            ListNode listNode = new ListNode(kv);

            current = header;

            ListNode p3 = header.next;

            current.next = listNode;
            listNode.prev = current;

            p3.prev = listNode;
            listNode.next = p3;

            counter++;
        }

        public static void main()
        {
            LRUCache lruCache = new LRUCache(2);

            lruCache.Set(2, 1);
            lruCache.Set(2, 2);
            Console.WriteLine(lruCache.Get(2));
            lruCache.Set(1, 1);
            lruCache.Set(4, 1);
            Console.WriteLine(lruCache.Get(2));

        }
    }
}
