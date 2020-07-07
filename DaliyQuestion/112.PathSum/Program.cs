using System;
using DataStructLibrary;

namespace _112.PathSum
{
    class Program
    {
        /*112. 路径总和
           给定一个二叉树和一个目标和，判断该树中是否存在根节点到叶子节点的路径，这条路径上所有节点值相加等于目标和。
           说明: 叶子节点是指没有子节点的节点。
           示例: 
           给定如下二叉树，以及目标和 sum = 22，
                 5
                / \
               4   8
              /   / \
             11  13  4
            /  \      \
           7    2      1
           返回 true, 因为存在目标和为 22 的根节点到叶子节点的路径 5->4->11->2。*/
        static void Main(string[] args)
        {
            TreeNode x=new TreeNode(5)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(11)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(2)
                    }
                },
                right = new TreeNode(8)
                {
                    left = new TreeNode(13),
                    right = new TreeNode(4)
                    {
                        right = new TreeNode(1)
                    }
                }
            };
            Console.WriteLine(HasPathSum(x,22));//true
            Console.WriteLine(HasPathSum(x,29));//false
        }

        static bool res;
        public static bool HasPathSum(TreeNode root, int sum)
        {
            res = false;
            Dfs(root,sum);
            return res;
        }
        public static void Dfs(TreeNode root,int n)
        {
            n = n - root.val;
            if (n == 0) res=true;
            if(root.left!=null)
                Dfs(root.left, n);
            if(root.right!=null)
                Dfs(root.right, n);
        }
    }
}
