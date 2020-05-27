using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DataStructLibrary;

namespace _199.BinaryTreeRightSideView
{
    class Program
    {
        /*
         * 199. 二叉树的右视图
           给定一棵二叉树，想象自己站在它的右侧，按照从顶部到底部的顺序，返回从右侧所能看到的节点值。
           
           示例:
           
           输入: [1,2,3,null,5,null,4]
           输出: [1, 3, 4]
           解释:
           
             1            <---
           /   \
          2     3         <---
           \     \
            5     4       <---
         */
        static void Main(string[] args)
        {
            BinaryTreeNode x = new BinaryTreeNode(1)
            {
                left = new BinaryTreeNode(2)
                {
                    left = null,
                    right = new BinaryTreeNode(5)
                },
                right = new BinaryTreeNode(3)
                {
                    left = null,
                    right = new BinaryTreeNode(4)
                }
            };
            IList<int> res1 = DepthFirstRightSideView(x);
            IList<int> res2 = WidththFirstRightSideView(x);
            Console.WriteLine();

        }
        //深度优先搜索
        public static IList<int> DepthFirstRightSideView(BinaryTreeNode root)
        {
            Dictionary<int ,int> rightmostValueAtDepth=new Dictionary<int, int>();
            int maxDepth = -1;

            Stack<BinaryTreeNode> nodeStack=new Stack<BinaryTreeNode>();
            Stack<int> depthStack=new Stack<int>();
            nodeStack.Push(root);
            depthStack.Push(0);

            while (nodeStack.Count!=0)
            {
                BinaryTreeNode node = nodeStack.Pop();
                int depth = depthStack.Pop();

                if (node!=null)
                {
                    //维护二叉树的最大深度
                    maxDepth = Math.Max(maxDepth, depth);

                    //如果不存在对应深度的节点才插入
                    if (!rightmostValueAtDepth.ContainsKey(depth))
                    {
                        rightmostValueAtDepth.Add(depth,node.val);
                    }

                    nodeStack.Push(node.left);
                    nodeStack.Push(node.right);
                    depthStack.Push(depth + 1);
                    depthStack.Push(depth + 1);
                }
            }

            IList<int> res=new List<int>();
            for (int i = 0; i <= maxDepth; i++)
            {
                res.Add(rightmostValueAtDepth[i]);
            }

            return res;
        }
        //广度优先搜索
        public static IList<int> WidththFirstRightSideView(BinaryTreeNode root)
        {
            Dictionary<int, int> rightmostValueAtDepth = new Dictionary<int, int>();
            int maxDepth = -1;

            Queue<BinaryTreeNode> nodeQueue=new Queue<BinaryTreeNode>();
            Queue<int> depthQueue=new Queue<int>();
            nodeQueue.Enqueue(root);
            depthQueue.Enqueue(0);

            while (nodeQueue.Count!=0)
            {
                BinaryTreeNode node = nodeQueue.Dequeue();
                int depth = depthQueue.Dequeue();
                if (node!=null)
                {
                    //维护二叉树的最大深度
                    maxDepth = Math.Max(maxDepth, depth);

                    //由于每一层最后一个访问到的节点才是我们要的答案，因此不断更新对应深度的信息即可


                    if (!rightmostValueAtDepth.ContainsKey(depth))
                    {
                        rightmostValueAtDepth.Add(depth,node.val);
                    }
                    else
                    {
                        rightmostValueAtDepth[depth] = node.val;
                    }

                    nodeQueue.Enqueue(node.left);
                    nodeQueue.Enqueue(node.right);
                    depthQueue.Enqueue(depth + 1);
                    depthQueue.Enqueue(depth + 1);

                }
            }

            IList<int> res = new List<int>();

            for (int i = 0; i <= maxDepth; i++)
            {
                res.Add(rightmostValueAtDepth[i]);
            }

            return res;
        }

        
    }
}
