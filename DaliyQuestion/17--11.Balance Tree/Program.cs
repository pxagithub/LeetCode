using System;
using System.Reflection.Metadata.Ecma335;
using DataStructLibrary;

namespace _17__11.Balance_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode x=new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };

            TreeNode y=new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(3)
                    {
                        left = new TreeNode(4),
                        right = new TreeNode(4)
                    },
                    right = new TreeNode(3)
                },
                right = new TreeNode(2)
            };

            Console.WriteLine(IsBalanced(x));
            Console.WriteLine(IsBalanced(y));
        }

        public static bool IsBalanced(TreeNode root)
        {
            return Dfs(root) >= 0;
        }

        public static int Dfs(TreeNode root)
        {
            if (root==null)
            {
                return 0;
            }

            int left = Dfs(root.left);
            int right = Dfs(root.right);

            if (left == -1 || right == -1 || Math.Abs(left - right) > 1)
            {
                return -1;
            }
            else
            {
                return Math.Max(left, right) + 1;
            }
        }
    }
}
