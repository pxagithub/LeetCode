using System;
using System.Collections.Generic;
using DataStructLibrary;

namespace _26__113._Path_Sum_II
{
    class Program
    {
        static void Main(string[] args)
        {
            /*113. 路径总和 II
                   给定一个二叉树和一个目标和，找到所有从根节点到叶子节点路径总和等于给定目标和的路径。
                   
                   说明: 叶子节点是指没有子节点的节点。
                   
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
                   ]*/

            TreeNode root=new TreeNode(5)
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

            TreeNode x=new TreeNode(1)
            {
                left = new TreeNode(-2)
                {
                    left = new TreeNode(1)
                    {
                        left = new TreeNode(-1)
                    },
                    right = new TreeNode(3)
                },
                right = new TreeNode(-3)
                {
                    left = new TreeNode(-2)
                }
            };

            foreach (var path in PathSum(x, 2))
            {
                Console.WriteLine("[" + string.Join(",", path) + "]");
                //1,-2,3
            }


            foreach (var path in PathSum(root,22))
            {
                Console.WriteLine("["+string.Join(",",path)+"]");
                //5,4,11,2
                //5,8,4,5
            }
        }

        public static IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Dfs(root, new List<int>(), 0, sum, res);
            return res;
        }

        public static void Dfs(TreeNode root, List<int> path, int sum, int target, IList<IList<int>> res)
        {
            if (root==null)
            {
                return;
            }

            int temp = root.val;
            path.Add(temp);
            sum += temp;
            if (root.left == null && root.right == null && sum == target)
            {
                res.Add(new List<int>(path));
                path.RemoveAt(path.Count-1);
                return;
            }
            Dfs(root.left, path, sum, target, res);
            Dfs(root.right, path, sum, target, res);
            sum -= temp;
            path.RemoveAt(path.Count - 1);
        }
    }
}
