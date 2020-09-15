using System;
using System.Collections.Generic;
using System.Reflection;
using DataStructLibrary;

namespace _14__94._Binary_Tree_Inorder_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            /*94. 二叉树的中序遍历
                  给定一个二叉树，返回它的中序 遍历。
                  
                  示例:
                  
                  输入: [1,null,2,3]
                     1
                      \
                       2
                      /
                     3
                  
                  输出: [1,3,2]
                  进阶: 递归算法很简单，你可以通过迭代算法完成吗？*/
            TreeNode root=new TreeNode(1)
            {
                right = new TreeNode(2)
                {
                    left = new TreeNode(3)
                }
            };
            Console.WriteLine(string.Join(",", InorderTraversal(root)));
            
        }

        static IList<int> res;
        public static IList<int> InorderTraversal(TreeNode root)
        {
            //迭代
            res = new List<int>();

            Stack<TreeNode> node = new Stack<TreeNode>();

            if (root==null)
            {
                return res;
            }

            do
            {
                while (root!=null)
                {
                    node.Push(root);
                    root = root.left;
                }

                if (node.Count!=0)
                {
                    TreeNode tempNode = node.Pop();
                    res.Add(tempNode.val);
                    root = tempNode.right;
                }
            } while (node.Count!=0||root!=null);


            return res;


            //递归
            //res = new List<int>();
            //Inorder(root);
            //return res;

        }
        public static void Inorder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            Inorder(root.left);
            res.Add(root.val);
            Inorder(root.right);
        }
    }
}
