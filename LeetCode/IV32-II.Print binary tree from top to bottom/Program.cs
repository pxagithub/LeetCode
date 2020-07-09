using System;
using System.Collections.Generic;
using DataStructLibrary;

namespace IV32_II.Print_binary_tree_from_top_to_bottom
{
    class Program
    {
        /*面试题32 - II. 从上到下打印二叉树 II
           从上到下按层打印二叉树，同一层的节点按从左到右的顺序打印，每一层打印到一行。
      
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
           [9,20],
           [15,7]
           ]       
           提示：
           
           节点总数 <= 1000*/
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

            TreeNode y = new TreeNode(1)
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
            var resultList = new List<IList<int>>();
            if (root == null) return resultList;
            var levelList = new List<int>();

            var nodeQueue = new Queue<TreeNode>();
            var levelQueue = new Queue<int>();
            nodeQueue.Enqueue(root);
            levelQueue.Enqueue(1);
            while (nodeQueue.Count != 0)
            {
                var node = nodeQueue.Dequeue();
                var level = levelQueue.Dequeue();

                levelList.Add(node.val);
                if (levelQueue.Count == 0 || levelQueue.Peek() != level)
                {
                    resultList.Add(levelList);
                    levelList = new List<int>();
                }

                if (node.left != null)
                {
                    nodeQueue.Enqueue(node.left);
                    levelQueue.Enqueue(level + 1);
                }

                if (node.right != null)
                {
                    nodeQueue.Enqueue(node.right);
                    levelQueue.Enqueue(level + 1);
                }
            }
            return resultList;
        }
        /// <summary>
        /// 利用Lambda表达式递归
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> levelOrder(TreeNode root)
        {
            var res = new List<IList<int>>();
            Action<TreeNode, int> pre = null;
            pre = (node, layer) =>
            {
                if (node == null) return;
                if (res.Count == layer)
                {
                    res.Add(new List<int>());
                }
                res[layer].Add(node.val);
                pre(node.left, layer + 1);
                pre(node.right, layer + 1);
            };
            pre(root, 0);
            return res;
        }
    }
}
