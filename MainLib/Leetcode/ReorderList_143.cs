using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 143. Reorder List - https://leetcode.com/problems/reorder-list/ - AC - idea: use stack to push the rest of array list, then pop and revert
    public class ReorderList_143
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public void ReorderList(ListNode head)
        {
            if (head == null) return;
            Stack<ListNode> stack = new Stack<ListNode>();

            ListNode t = head;

            for (; t != null;)
            {
                Console.Write(t.val + "\t");
                t = t.next;
            }

            t = head;

            int counter = 0;

            for(;t!=null;)
            {
                counter++;
                t = t.next;
            }

            if (counter <= 2)
                return;

            int index = counter %2 == 0?counter / 2 : counter/2+1;

            t = head;

            for (int i = 0; i < index - 1; i++)
            {
                t = t.next;
            }

            ListNode p1 = t;
            t = t.next;

            p1.next = null;

            for (; t != null;)
            {
                stack.Push(t);
                p1 = t;
                t = t.next;
                p1.next = null;
            }

            t = head;
            for (; t != null && stack.Count > 0;)
            {
                ListNode p = stack.Pop();

                p1 = t.next;
                t.next = p;
                p.next = p1;

                t = p1;
            }
        }

        //@example: Leetcode - algorithm - revert linked list by recursively
        public void revert(ListNode p, ListNode t, ListNode r)
        {
            if (r == null)
            {
                t.next = p;
                return;
            }

            t.next = p;
            revert(t, r, r.next);
        }


        public static void main()
        {
            ListNode listNode = new ListNode(1);
            ListNode n1 = new ListNode(2);
            ListNode n2 = new ListNode(3);
            //ListNode n3 = new ListNode(4);

            listNode.next = n1;
            //n1.next = n2;

            //n2.next = n3;

            //revert(null, listNode, listNode.next);

            ReorderList_143 s = new ReorderList_143();

            s.ReorderList(listNode);
        }
    }
}
