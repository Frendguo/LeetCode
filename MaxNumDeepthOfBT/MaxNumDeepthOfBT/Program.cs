using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 问题描述：
 * 
    Given a binary tree, find its maximum depth.

    The maximum depth is the number of nodes along the longest path from 
    the root node down to the farthest leaf node.
     
 */

namespace MaxNumDeepthOfBT
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Solution
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            
            int depth_l = MaxDepth(root.left) + 1;
            int depth_r = MaxDepth(root.right) + 1;

            return Math.Max(depth_l, depth_r);

            //if (root.left != null)
            //{
            //    depth_l = MaxDepth(root.left);
            //}
            //if (root.right != null)
            //{
            //    depth_r = MaxDepth(root.right);
            //}

            //return Math.Max(depth_l, depth_r) + 1;
        }
    }
}
