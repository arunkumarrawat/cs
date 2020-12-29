using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 101. Symmetric Tree - https://leetcode.com/problems/symmetric-tree/
    public class SymmetricTree_101
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;

            return IsMirror(root.left,root.right);
        }

        public bool IsMirror(TreeNode left, TreeNode right)
        {
            if (left == null && right == null) return true;
            if (left == null || right == null) return false;

            return (left.val == right.val) && IsMirror(left.left,right.right) && IsMirror(left.right,right.left);
        }

        public static void main()
        {
            SymmetricTree_101 s = new SymmetricTree_101();


        }
    }
}
