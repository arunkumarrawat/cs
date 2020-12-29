using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{

    //@example: HackRank - algorithm - Sort using Binary tree, root node > left node, root node < right node
    class IsPresent
    {
        class Node {
            public Node left, right;
            public int data;

            public Node(int newData)
            {
                left = right = null;
                data = newData;
            }
        }

        Node insert(Node node, int data)
        {
            if (node == null)
            {
                node = new Node(data);
            }
            else
            {
                if (data <= node.data)
                {
                    node.left = insert(node.left, data);
                }
                else
                {
                    node.right = insert(node.right, data);
                }
            }
            return (node);
        }

        int isPresent(Node root, int val)
        {
            if (root == null) return 0;

            if (root.data == val)
                return 1;

            if (root.data < val)
            {
                return isPresent(root.right, val);
            }

            return isPresent(root.left, val);
        }


        public void main()
        {
            int[] arr = new int[] { 10,30,8,12,25,40 };

            Node root = new Node(20);

            for(int i=0;i<arr.Length;i++)
            {
                insert(root, arr[i]);
            }

            Console.WriteLine(isPresent(root, 30));
            Console.WriteLine(isPresent(root, 10));
            Console.WriteLine(isPresent(root, 12));
            Console.WriteLine(isPresent(root, 15));
        }

    }
}
