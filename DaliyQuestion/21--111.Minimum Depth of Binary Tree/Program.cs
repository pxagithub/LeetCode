using System;
using DataStructLibrary;

namespace _21__111.Minimum_Depth_of_Binary_Tree
{
    class Program
    {
        /*111. 二叉树的最小深度
            给定一个二叉树，找出其最小深度。
            
            最小深度是从根节点到最近叶子节点的最短路径上的节点数量。
            
            说明: 叶子节点是指没有子节点的节点。
            
            示例:
            
            给定二叉树 [3,9,20,null,null,15,7],
            
                3
               / \
              9  20
                /  \
               15   7
            返回它的最小深度  2.*/
        static void Main(string[] args)
        {
            TreeNode root=new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };

            TreeNode x=new TreeNode(1)
            {
                left = new TreeNode(2)
            };

            Console.WriteLine(MinDepth(x));
        }

        private int minDepth=Int32.MaxValue;

        public static int MinDepth(TreeNode root)
        {
            if (root==null)
            {
                return 0;
            }

            if (root.left==null && root.right==null)
            {
                return 1;
            }

            int left = MinDepth(root.left);
            int right = MinDepth(root.right);

            if (root.left!=null&&root.right==null)
            {
                return left + 1;
            }

            if(root.left == null && root.right != null)
            {
                return right + 1;
            }

            return Math.Min(left,right) + 1;
        }
    }
}
