using System;
using System.Collections.Generic;
using System.Threading;
using DataStructLibrary;

namespace _12__637.Average_of_Levels_in_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 637. 二叉树的层平均值
               给定一个非空二叉树, 返回一个由每层节点平均值组成的数组。
               
               示例 1：
               输入：
                  3
                 / \
                9  20
                  /  \
                 15   7
               输出：[3, 14.5, 11]
               解释：
               第 0 层的平均值是 3 ,  第1层是 14.5 , 第2层是 11 。因此返回 [3, 14.5, 11] 。
               
               提示：
               节点值的范围在32位有符号整数范围内。
             */

            TreeNode root=new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };

            Console.WriteLine(string.Join(",",AverageOfLevels(root)));
        }

        public static IList<double> AverageOfLevels(TreeNode root)
        {
            List<double> res = new List<double>();

            List<TreeNode> tree = new List<TreeNode>();

            tree.Add(root);

            while (tree.Count>0)
            {
                double sum = 0;
                int temp = tree.Count;
                for (int i=0; i < temp; i++)
                {
                    sum += tree[i].val;
                    if (tree[i].left!=null)
                    {
                        tree.Add(tree[i].left);
                    }

                    if (tree[i].right!=null)
                    {
                        tree.Add(tree[i].right);
                    }
                }
                tree.RemoveRange(0,temp);
                res.Add(sum / temp);
            }

            return res;

        }

    }
}
