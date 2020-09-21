using System;
using DataStructLibrary;

namespace _21__538._Convert_BST_to_Greater_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            /*538. 把二叉搜索树转换为累加树
                   给定一个二叉搜索树（Binary Search Tree），把它转换成为累加树（Greater Tree)，使得每个节点的值是原来的节点值加上所有大于它的节点值之和。
                   
                   例如：
                   
                   输入: 原始二叉搜索树:
                                 5
                               /   \
                              2     13
                   
                   输出: 转换为累加树:
                                18
                               /   \
                             20     13*/

            TreeNode root=new TreeNode(5)
            {
                left = new TreeNode(2),
                right = new TreeNode(13)
            };
            TreeNode res = ConvertBST(root);
            Console.WriteLine();
        }

        private static int value;
        public static TreeNode ConvertBST(TreeNode root)
        {
            value = 0;
            OppositInOrderTranversal(root);
            return root;
        }

        public static void OppositInOrderTranversal(TreeNode root)
        {
            if (root==null)
            {
                return;
            }

            OppositInOrderTranversal(root.right);
            value += root.val;
            root.val = value;
            OppositInOrderTranversal(root.left);
        }
    }
}
