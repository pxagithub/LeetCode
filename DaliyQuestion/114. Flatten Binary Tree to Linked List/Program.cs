using System;
using DataStructLibrary;

namespace _114._Flatten_Binary_Tree_to_Linked_List
{
    class Program
    {
        /*114. 二叉树展开为链表
               给定一个二叉树，原地将它展开为一个单链表。
               例如，给定二叉树
                   1
                  / \
                 2   5
                / \   \
               3   4   6
               将其展开为：
               1
                \
                 2
                  \
                   3
                    \
                     4
                      \
                       5
                        \
                         6*/
        static void Main(string[] args)
        {
            TreeNode root=new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(4)
                },
                right = new TreeNode(5)
                {
                    left = null,
                    right = new TreeNode(6)
                }
            };
            Flatten(root);
        }

        public static void Flatten(TreeNode root)
        {
            while (root!=null)
            {

                if (root.left==null)
                {
                    root = root.right;
                }
                else
                {
                    TreeNode pre = root.left;
                    while (pre.right!=null)
                    {
                        pre = pre.right;
                    }

                    pre.right = root.right;
                    root.right = root.left;
                    root.left = null;
                    root = root.right;
                }
            }
            


        }

        public static void PreOrder(TreeNode root)
        {

        }
    }
}
