using System;
using System.Collections.Generic;
using System.Linq;
using DataStructLibrary;

namespace IV54.The_k_th_largest_node_of_the_binary_search_tree
{
    class Program
    {
        /*面试题54. 二叉搜索树的第k大节点
           给定一棵二叉搜索树，请找出其中第k大的节点。 
           示例 1:
           输入: root = [3,1,4,null,2], k = 1
             3
            / \
           1   4
            \
             2
           输出: 4
           示例 2:           
           输入: root = [5,3,6,2,4,null,null,1], k = 3
                 5
                / \
               3   6
              / \
             2   4
            /
           1
           输出: 4
           限制：
           1 ≤ k ≤ 二叉搜索树元素个数*/
        static void Main(string[] args)
        {
            TreeNode x=new TreeNode(3)
            {
                left = new TreeNode(1)
                {
                    right = new TreeNode(2)
                },
                right = new TreeNode(4)
            };
            TreeNode y=new TreeNode(5)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(2)
                    {
                        left = new TreeNode(1)
                    },
                    right = new TreeNode(4)
                },
                right = new TreeNode(6)
            };
            Console.WriteLine(KthLargest(x,1));//4
            Console.WriteLine(KthLargest(y,3));//4
        }

        static List<int> val;

        public static int KthLargest(TreeNode root, int k)
        {

            val = new List<int>();
            Traversal(root);
            return val[^k];
        }
        //二叉搜索树的中序遍历按从小到大排序
        public static void Traversal(TreeNode root)
        {
            if(root==null) return;
            Traversal(root.left);
            val.Add(root.val);
            Traversal(root.right);
        }
    }
}
