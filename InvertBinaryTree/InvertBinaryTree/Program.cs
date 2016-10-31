using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvertBinaryTree
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
        public TreeNode InvertTree(TreeNode root)
        {
            TreeNode t;
            if (root == null)
            {
                return root;
            }
            if ((root.left == null)&&(root.right == null))
            {
                return root;
            }
            else if (root.left == null)
            {
                root.left = root.right;
                root.right = null;
            }
            else if (root.right == null)
            {
                root.right = root.left;
                root.left = null;
            }
            else
            {
                t = root.left;
                root.left = root.right;
                root.right = t;
            }

            root.left = InvertTree(root.left);
            root.right = InvertTree(root.right);

            return root;
        }
    }
}
