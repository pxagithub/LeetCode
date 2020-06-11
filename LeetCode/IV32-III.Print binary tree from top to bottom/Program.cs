using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataStructLibrary;

namespace IV32_III.Print_binary_tree_from_top_to_bottom
{
    class Program
    {
        /*面试题32 - III. 从上到下打印二叉树 III
           请实现一个函数按照之字形顺序打印二叉树，即第一行按照从左到右的顺序打印，第二层按照从右到左的顺序打印，第三行再按照从左到右的顺序打印，其他行以此类推。

           例如:
           给定二叉树: [3,9,20,null,null,15,7],
            3
           / \
          9  20
            /  \
           15   7
           返回其层次遍历结果：           
           [
           [3],
           [20,9],
           [15,7]
           ]           
           提示：
           节点总数 <= 1000  */
        static void Main(string[] args)
        {
            TreeNode x = new TreeNode(3)
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
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
            };
            IList<IList<int>> res = LevelOrder(x);
            IList<IList<int>> res2 = LevelOrder(y);
            Console.WriteLine();
        }
        
        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            var nodeQueue = new Queue<TreeNode>();
            var levelQueue = new Queue<int>();

            var totalResult = new List<IList<int>>();
            var levelResult = new List<int>();
            if (root == null)
            {
                return totalResult;
            }
            nodeQueue.Enqueue(root);
            levelQueue.Enqueue(1);
            while (nodeQueue.Count != 0)
            {
                var node = nodeQueue.Dequeue();
                var level = levelQueue.Dequeue();

                levelResult.Add(node.val);
                if (levelQueue.Count == 0 || levelQueue.Peek() != level)
                {
                    totalResult.Add(levelResult);
                    levelResult = new List<int>();
                }

                var children = new List<TreeNode>();
                if (node.left != null)
                {
                    children.Add(node.left);
                }
                if (node.right != null)
                {
                    children.Add(node.right);
                }
                foreach (var child in children)
                {
                    nodeQueue.Enqueue(child);
                    levelQueue.Enqueue(level + 1);
                }

            }

            for (int level = 0; level < totalResult.Count; level++)
            {
                if ((level % 2) == 1)
                {
                    totalResult[level] = new List<int>(totalResult[level].Reverse());
                }
            }
            return totalResult;
        }
    }
}
