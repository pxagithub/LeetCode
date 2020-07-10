using System;
using DataStructLibrary;

namespace IV55_I.The_depth_of_the_binary_tree
{
    class Program
    {
        /*面试题55 - I. 二叉树的深度
    输入一棵二叉树的根节点，求该树的深度。从根节点到叶节点依次经过的节点（含根、叶节点）形成树的一条路径，最长路径的长度为树的深度。        例如：           
           给定二叉树 [3,9,20,null,null,15,7]，           
             3
            / \
           9  20
             /  \
            15   7
           返回它的最大深度 3 。
          提示：           
           节点总数 <= 10000*/
        static void Main(string[] args)
        {
            TreeNode x=new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };
            Console.WriteLine(MaxDepth(x));
        }

        private int maxDepth = int.MinValue;
        public static int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            
            return Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;
        }
    }
}
