using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    /// <summary>
    /// @example: Leetcode - 102. Binary Tree Level Order Traversal - https://leetcode.com/problems/binary-tree-level-order-traversal/
    /// @example: Leetcode - 107. Binary Tree Level Order Traversal II - https://leetcode.com/problems/binary-tree-level-order-traversal-ii/
    /// </summary>
    public class BinaryTreeLevelOrderTraversal_102
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();

            Stack<IList<int>> result2 = new Stack<IList<int>>();

            if (root == null) return result;

            Queue<TreeNode> q = new Queue<TreeNode>();

            Queue<TreeNode> child = new Queue<TreeNode>();
            q.Enqueue(root);

            List<int> r = new List<int>();

            while (q.Count > 0)
            {
                TreeNode n = q.Dequeue();

                r.Add(n.val);

                if (n.left != null)
                    child.Enqueue(n.left);

                if (n.right != null)
                    child.Enqueue(n.right);

                if (q.Count == 0)
                {
                    result2.Push(r);

                    while(child.Count > 0)
                    {
                        q.Enqueue(child.Dequeue());
                    }

                    r = new List<int>();
                }

            }

            while(result2.Count > 0 )
            {
                result.Add(result2.Pop());
            }

            return result;
        }

        public static void main()
        {
            TreeNode root = new TreeNode(3);

            TreeNode t1 = new TreeNode(9);
            TreeNode t2 = new TreeNode(20);
            TreeNode t3 = new TreeNode(15);
            TreeNode t4 = new TreeNode(7);

            root.left = t1;
            root.right = t2;

            t2.left = t3;
            t2.right = t4;
            BinaryTreeLevelOrderTraversal_102 s = new BinaryTreeLevelOrderTraversal_102();
            IList<IList<int>>  result = s.LevelOrder(root);

        }
    }
}
