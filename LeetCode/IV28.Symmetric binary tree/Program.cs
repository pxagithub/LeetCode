using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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
        3  4 4  3*/
            TreeNode x=new TreeNode(1)
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
             3    3
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

            

            Console.WriteLine($"{IsSymmetric(x)}, {IsSymmetric(y)}");//true false

        }
        private static List<string> nodeVal=new List<string>();
        public static bool IsSymmetric(TreeNode root)
        {
            nodeVal.Clear();
            InOrderTraversal(root);
            if (nodeVal.Count == 1) return true;
            if (nodeVal.Count % 2 == 0) return false;
            int i = 0, j = nodeVal.Count - 1;
            while (i!=j)
            {
                if (nodeVal[i] != nodeVal[j]) return false;
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
            if (root.left==null && root.right==null) return;
            
            InOrderTraversal(root.left);
            nodeVal.Add(root.val.ToString());
            InOrderTraversal(root.right);
        }
    }
}
