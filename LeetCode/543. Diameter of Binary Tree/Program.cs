using System;
using System.Collections.Generic;
using DataStructLibrary;
namespace _543._Diameter_of_Binary_Tree
{
    class Program
    {
        /*
         * 543. 二叉树的直径
           给定一棵二叉树，你需要计算它的直径长度。一棵二叉树的直径长度是任意两个结点路径长度中的最大值。这条路径可能穿过也可能不穿过根结点。

           示例 :
           给定二叉树
            1
           / \
          2   3
         / \     
        4   5    
           返回 3, 它的长度是路径 [4,2,1,3] 或者 [5,2,1,3]。
           
           
           
           注意：两结点之间的路径长度是以它们之间边的数目表示。
         */
        static void Main(string[] args)
        {
            //测试用例
            TreeNode x=new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                },
                right = new TreeNode(5)
            };
            int res = DiameterOfBinaryTree(x);
            Console.WriteLine(res);

        }
        /*
         * 思路1： 广度优先搜索，寻找最左端与最右端的节点
         * 结论： 可能存在较深的节点但并不是最左端或最右端的节点
         * 思路2： 借助赫夫曼编码
         * 结论： 还是需要两两计算距离，ON2
         * 思路3： 计算每个节点的左右子树的深度
         */
        public static int max = 0;
        public static int DiameterOfBinaryTree(TreeNode root)
        {
            GetDepth(root);
            return max;
        }

        
        public static int GetDepth(TreeNode root)
        {
            if (root == null) return 0;
            int left = GetDepth(root.left);
            int right = GetDepth(root.right);
            max = Math.Max(left + right, max);
            return Math.Max(left, right) + 1;
        }
    }
}
