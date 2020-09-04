using System;
using System.Collections.Generic;
using System.ComponentModel;
using DataStructLibrary;

namespace _04__257.Binary_Tree_Paths
{
    class Program
    {
        static void Main(string[] args)
        {
            /*257. 二叉树的所有路径
             给定一个二叉树，返回所有从根节点到叶子节点的路径。
             说明: 叶子节点是指没有子节点的节点。
             
             示例:
             输入:
                1
              /   \
             2     3
              \
               5
             输出: ["1->2->5", "1->3"]
             解释: 所有根节点到叶子节点的路径为: 1->2->5, 1->3*/
            TreeNode x=new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
            };
            Console.WriteLine(string.Join(",", BinaryTreePaths(x)));

        }
        public static IList<string> BinaryTreePaths(TreeNode root)
        {
            IList<string> res = new List<string>();

            if (root==null)
            {
                return res;
            }

            string path = "";

            Dfs(root, res, path);

            return res;

        }

        public static void Dfs(TreeNode root, IList<string> res, string path)
        {
            if (root==null)
            {
                return;
            }
            path += root.val;
            if (root.left!=null||root.right!=null)
            {
                path += "->";
            }
            else
            {
                res.Add(path);
                path = "";
                return;
            }

            Dfs(root.left, res, path);

            Dfs(root.right, res, path);
            
        }
    }
}
