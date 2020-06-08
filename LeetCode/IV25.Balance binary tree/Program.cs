using System;
using System.ComponentModel;
using DataStructLibrary;

namespace IV55.Balance_binary_tree
{
    class Program
    {
        /*
         * 面试题55 - II. 平衡二叉树
           输入一棵二叉树的根节点，判断该树是不是平衡二叉树。
           如果某二叉树中任意节点的左右子树的深度相差不超过1，那么它就是一棵平衡二叉树。

           示例 1:
           
           给定二叉树 [3,9,20,null,null,15,7]
           
             3
            / \
           9  20
             /  \
            15   7
           返回 true 。
           
           示例 2:
           
           给定二叉树 [1,2,2,3,3,null,null,4,4]
           
             1
            / \
           2   2
          / \
         3   3
        / \
       4   4
           返回 false 。
           
           
           
           限制：
           
           1 <= 树的结点个数 <= 10000
         */
        static void Main(string[] args)
        {
            /*
             3
            / \
           9  20
             /  \
            15   7
             */
            TreeNode x =new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };

            /*
             1
            / \
           2   2
          / \
         3   3
        / \
       4   4
             */
            TreeNode y =new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(3)
                    {
                        left = new TreeNode(4),
                        right = new TreeNode(4)
                    },
                    right = new TreeNode(3)
                },
                right = new TreeNode(2)
            };

            Console.WriteLine($"Tree x is {(IsBalanced(x)?"":"not") } balance tree, " +
                              $"y is {(IsBalanced(y) ? "" : "not")} balance tree.");
        }
        public static bool IsBalanced(TreeNode root)
        {
            return Recur(root) != -1;
        }

        public static int Recur(TreeNode root)
        {
            if (root == null) return 0;
            int left = Recur(root.left);
            if (left == -1) return -1;
            int right = Recur(root.right);
            if (right == -1) return -1;
            return Math.Abs(left - right) < 2 ? Math.Max(left, right) + 1 : -1;
        }
    }
}
