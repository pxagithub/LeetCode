using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using DataStructLibrary;

namespace IV34.Binary_tree_path_with_a_certain_value
{
    class Program
    {
        /*面试题34. 二叉树中和为某一值的路径
           输入一棵二叉树和一个整数，打印出二叉树中节点值的和为输入整数的所有路径。从树的根节点开始往下一直到叶节点所经过的节点形成一条路径。      
           示例:
           给定如下二叉树，以及目标和 sum = 22，           
                 5
                / \
               4   8
              /   / \
             11  13  4
            /  \    / \
           7    2  5   1
           返回:           
           [
           [5,4,11,2],
           [5,8,4,5]
           ]           
           提示：           
           节点总数 <= 10000*/
        static void Main(string[] args)
        {
            TreeNode x=new TreeNode(5)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(11)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(2)
                    }
                },
                right = new TreeNode(8)
                {
                    left = new TreeNode(13),
                    right = new TreeNode(4)
                    {
                        left = new TreeNode(5),
                        right = new TreeNode(1)
                    }
                }
            };
            var res = PathSum(x, 22);
            //[5,4,11,2],[5,8,4,5]
            Console.WriteLine();
        }
        static IList<IList<int>> resultList ;
        static List<int> path=new List<int>();
        static IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            resultList = new List<IList<int>>();
            Recursive(root,sum);
            return resultList;
        }

        static void Recursive(TreeNode root, int target)
        {
            if (root == null) return;
            target -= root.val;
            path.Add(root.val);
            if(target==0&&root.left==null&&root.right==null)
                resultList.Add(new List<int>(path));
            Recursive(root.left,target);
            Recursive(root.right,target);
            path.RemoveAt(path.Count-1);
        }
    }
}
