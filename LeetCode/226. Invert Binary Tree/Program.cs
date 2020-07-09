using System;
using System.Xml.Schema;
using DataStructLibrary;

namespace _226._Invert_Binary_Tree
{
    class Program
    {
        /*
         * 翻转一棵二叉树。
         * 示例：
         * 
         * 输入：
         * 
         *      4
         *    /   \
         *   2     7
         *  / \   / \
         * 1   3 6   9
         * 输出：
         * 
         *      4
         *    /   \
         *   7     2
         *  / \   / \
         * 9   6 3   1
         * 备注:
         * 这个问题是受到 Max Howell 的 原问题 启发的 ：
         * 
         * 谷歌：我们90％的工程师使用您编写的软件(Homebrew)，但是您却无法在面试时在白板上写出翻转二叉树这道题，这太糟糕了。
         */
        static void Main(string[] args)
        {
            TreeNode x=new TreeNode(4)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },
                right = new TreeNode(7)
                {
                    left=new TreeNode(6),
                    right = new TreeNode(9)
                }
            };
            TreeNode res = InvertTree(x);
            Console.WriteLine();
        }

        public static TreeNode InvertTree(TreeNode root)
        {
            if (root == null) return root;
            TreeNode t = root.left;
            root.left = root.right;
            root.right = t;
            root.left = InvertTree(root.left);
            root.right = InvertTree(root.right);
            return root;

        }

        
        
    }
}
