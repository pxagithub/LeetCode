using System;
using DataStructLibrary;

namespace _19__404._Sum_of_Left_Leaves
{
    class Program
    {
        static void Main(string[] args)
        {
            /*404. 左叶子之和
               计算给定二叉树的所有左叶子之和。
               
               示例：
               
                3
               / \
              9  20
                /  \
               15   7
               
               在这个二叉树中，有两个左叶子，分别是 9 和 15，所以返回 24*/

            TreeNode x = new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right=new TreeNode(7)
                }
            };

            Console.WriteLine(SumOfLeftLeaves(x));
        }

        public static int SumOfLeftLeaves(TreeNode root)
        {
            return Recursion(root, false);
        }

        public static int Recursion(TreeNode root, bool isLeft)
        {
            if (root==null)
            {
                return 0;
            }

            if (isLeft && root.left == null && root.right == null)
            {
                return root.val;
            }

            return Recursion(root.left, true) + Recursion(root.right, false);

        }
    }
}
