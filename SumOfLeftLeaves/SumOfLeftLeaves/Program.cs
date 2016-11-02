using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumOfLeftLeaves
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class Solution
    {
        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null) return 0;
            int sum = 0;
            // left leaves
            if ((root.left != null) &&
                (root.left.left == null) &&
                (root.left.right == null))
            {
                sum += root.left.val;
            }

            sum += SumOfLeftLeaves(root.left);
            sum += SumOfLeftLeaves(root.right);

            return sum;
        }
    }
}
