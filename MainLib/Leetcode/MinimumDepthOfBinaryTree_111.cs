using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 111. Minimum Depth of Binary Tree https://leetcode.com/problems/minimum-depth-of-binary-tree/
    public class MinimumDepthOfBinaryTree_111
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        static int result = int.MaxValue;

        public static int MinDepth(TreeNode root)
        {
            if (root == null) return 0;

            MinDepth(root, 0);

            return result;
        }

        public static void MinDepth(TreeNode root, int min)
        {
            if (root == null) return;

            if (root.left == null && root.right == null)
            {
                min++;

                if (result > min)
                    result = min;

                return;
            }

            min++;

            MinDepth(root.left, min);
            MinDepth(root.right, min);

        }

        public static void Main123(string[] args)
        {
            TreeNode root = new TreeNode(1);
            TreeNode n1 = new TreeNode(2);
            TreeNode n2 = new TreeNode(3);
            TreeNode n3 = new TreeNode(4);
            TreeNode n4 = new TreeNode(4);

            root.left = n1;
            root.right = n2;

            n1.left = n3;
            n2.right = n4;
            //n1.left = n3;

            MinDepth(root);

            Console.WriteLine("result = " + result);

        }

    }
}
