using System;
using DataStructLibrary;

namespace _07_100._Same_tree
{
    /*100.  相同的树
            给定两个二叉树，编写一个函数来检验它们是否相同。
            如果两个树在结构上相同，并且节点具有相同的值，则认为它们是相同的。
            
            示例 1:
            输入:       1         1
                      / \       / \
                     2   3     2   3
            
                    [1,2,3],   [1,2,3]
            输出: true

            示例 2:
            输入:      1          1
                      /           \
                     2             2
            
                    [1,2],     [1,null,2]
            
            输出: false

            示例 3:
            输入:       1         1
                      / \       / \
                     2   1     1   2
            
                    [1,2,1],   [1,1,2]
            
            输出: false*/
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode x1 = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
            };
            TreeNode x2 = new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
            };

            TreeNode y1 = new TreeNode(1)
            {
                left = new TreeNode(2)
            };
            TreeNode y2 = new TreeNode(1)
            {
                right = new TreeNode(2)
            };

            Console.WriteLine(IsSameTree(x1,x2));
            Console.WriteLine(IsSameTree(y1,y2));
        }

        public static bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null)
                return true;
            if (p==null||q==null)
            {
                return false;
            }
            if (p.val == q.val)
                return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
            else
                return false;
        }
    }
}
