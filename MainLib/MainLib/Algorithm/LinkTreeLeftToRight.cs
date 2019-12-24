using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainLib.Algorithm
{
    /// <summary>
    /// 
    /// </summary>
    public class TreeLinkNode
    {
        int val;
        public TreeLinkNode left, right, next;
        TreeLinkNode(int x) { val = x; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class LinkTreeLeftToRgith
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        public void connect(TreeLinkNode root)
        {
            if (root == null) return;
            connect(root.left);
            connect(root.right);
            TreeLinkNode left = root.left;
            TreeLinkNode right = root.right;
            while (left != null && right != null)
            {
                left.next = right;
                left = left.right;
                right = right.left;
            }
        }
    }
}
