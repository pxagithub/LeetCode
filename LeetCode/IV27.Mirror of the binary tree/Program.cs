using System;
using System.Runtime.InteropServices.ComTypes;
using DataStructLibrary;

namespace IV27.Mirror_of_the_binary_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            /*面试题27. 二叉树的镜像
               请完成一个函数，输入一个二叉树，该函数输出它的镜像。
               例如输入：
                    4
                  /   \
                 2     7
                / \   / \
               1   3 6   9
               镜像输出：
                    4
                  /   \
                 7     2
                / \   / \
               9   6 3   1

               示例 1：
               输入：root = [4,2,7,1,3,6,9]
               输出：[4,7,2,9,6,3,1]
               限制：    
               0 <= 节点个数 <= 1000*/
            TreeNode x=new TreeNode(4)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },
                right = new TreeNode(7)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(9)
                }
            };
            TreeNode res = MirrorTree(x);
            Console.WriteLine();

        }

        public static TreeNode MirrorTree(TreeNode root)
        {
            if (root == null) return null;
            TreeNode temp = root.left;
            root.left = root.right;
            root.right = temp;
            MirrorTree(root.left);
            MirrorTree(root.right);
            return root;
        }

    }
}
