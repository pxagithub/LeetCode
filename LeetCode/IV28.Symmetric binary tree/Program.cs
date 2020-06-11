using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices.ComTypes;
using DataStructLibrary;

namespace IV28.Symmetric_binary_tree
{
    class Program
    {
        /*面试题28. 对称的二叉树
           请实现一个函数，用来判断一棵二叉树是不是对称的。如果一棵二叉树和它的镜像一样，那么它是对称的。
           例如，二叉树 [1,2,2,3,4,4,3] 是对称的。           
            1
           / \
          2   2
         / \ / \
        3  4 4  3
           但是下面这个 [1,2,2,null,3,null,3] 则不是镜像对称的:
           
             1
            / \
           2   2
            \   \
            3    3       
           示例 1：
           
           输入：root = [1,2,2,3,4,4,3]
           输出：true
           示例 2：
           
           输入：root = [1,2,2,null,3,null,3]
           输出：false
         限制：
           0 <= 节点个数 <= 1000
         */
        static void Main(string[] args)
        {
            /*
            1
           / \
          2   2
         / \ / \
        3  4 4  3
           */
            TreeNode x =new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(4)
                },
                right = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(3)
                }
            };



            /*           
              1
             / \
            2   2
             \   \
             2    2
              */
            TreeNode y = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    right = new TreeNode(2)
                },
                right = new TreeNode(2)
                {
                    right = new TreeNode(2)
                }
            };
            TreeNode z=new TreeNode(1)
            {
                left = new TreeNode(0)
            };
            

            Console.WriteLine(IsSymmetric(x));//true 
            Console.WriteLine(IsSymmetric(y));//false
            Console.WriteLine(IsSymmetric(z));//false

        }
        private static List<string> nodeVal=new List<string>();
        public static bool IsSymmetric(TreeNode root)
        {
            //中序遍历法无法通过特殊用例[5,4,1,null,1,null,4,2,null,2,null]
            //nodeVal.Clear();
            //InOrderTraversal(root);
            //if (nodeVal.Count == 1) return true;
            //if (nodeVal.Count % 2 == 0) return false;
            //int i = 0, j = nodeVal.Count - 1;
            //while (i!=j)
            //{
            //    if (nodeVal[i] != nodeVal[j]) return false;
            //    i++;
            //    j--;
            //}
            //return true;
            //若加入null值后的前序遍历与后序遍历正好相反，则该树是镜像的
            preOrder.Clear();
            postOrder.Clear();
            PreOrderTraversal(root);
            PostOrderTraversal(root);
            if (preOrder.Count == 1) return true;
            if (preOrder.Count % 2 == 0) return false;
            int i = 0, j = postOrder.Count - 1;
            while (j>0)
            {
                if (preOrder[i] != postOrder[j]) return false;
                i++;
                j--;
            }
            return true;
        }

        public static void InOrderTraversal(TreeNode root)
        {
            if (root == null)
            {
                nodeVal.Add("null");
                return;
            }
            if (root.left==null && root.right==null)
            {
                nodeVal.Add(root.val.ToString());
                return;
            }

            InOrderTraversal(root.left);
            nodeVal.Add(root.val.ToString());
            InOrderTraversal(root.right);
        }
        private static List<string> preOrder=new List<string>();
        public static void PreOrderTraversal(TreeNode root)
        {
            if (root == null)
            {
                preOrder.Add("null");
                return;
            }
            if (root.left == null && root.right == null)
            {
                preOrder.Add(root.val.ToString());
                return;
            }
            preOrder.Add(root.val.ToString());
            PreOrderTraversal(root.left);
            PreOrderTraversal(root.right);
        }
        private static List<string> postOrder=new List<string>();
        public static void PostOrderTraversal(TreeNode root)
        {
            if (root == null)
            {
                postOrder.Add("null");
                return;
            }
            if (root.left == null && root.right == null)
            {
                postOrder.Add(root.val.ToString());
                return;
            }
            PostOrderTraversal(root.left);
            PostOrderTraversal(root.right);
            postOrder.Add(root.val.ToString());
        }
        
    }
}
