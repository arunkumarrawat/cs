using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 404. Sum of Left Leaves - https://leetcode.com/problems/sum-of-left-leaves/ - AC
    public class SumofLeftLeaves_404
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }
        public int SumOfLeftLeaves(TreeNode root)
        {
            int result = 0;
            //@todo: leetcode- sum of left leaves
            //@todo: 382. Linked List Random Node - https://leetcode.com/problems/linked-list-random-node/ - Java Only

            if (root == null) return 0;

            return gotoLeaf(root.left,true) + gotoLeaf(root.right,false);
        }

        public int gotoLeaf(TreeNode node,bool isLeft)
        {
            if (node == null) return 0;

            if(node.left == null && node.right == null)
            {
                return isLeft?node.val:0;
            }

            return gotoLeaf(node.left,true) + gotoLeaf(node.right,false);

        }

        public static void main()
        {
            TreeNode root = new TreeNode(3);
            TreeNode n1 = new TreeNode(9);
            TreeNode n2 = new TreeNode(20);
            TreeNode n3 = new TreeNode(15);
            TreeNode n4 = new TreeNode(7);

            root.left = n1;
            root.right = n2;

            n2.left = n3;
            n2.right = n4;
            SumofLeftLeaves_404 s = new SumofLeftLeaves_404();
            Console.WriteLine(s.SumOfLeftLeaves(root));
        }
    }
}
