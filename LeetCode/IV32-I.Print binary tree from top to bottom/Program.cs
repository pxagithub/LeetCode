using System;
using System.Collections;
using System.Collections.Generic;
using DataStructLibrary;

namespace IV32_I.Print_binary_tree_from_top_to_bottom
{
    class Program
    {
        /*面试题32 - I. 从上到下打印二叉树
           从上到下打印出二叉树的每个节点，同一层的节点按照从左到右的顺序打印。
          
           例如:
           给定二叉树: [3,9,20,null,null,15,7],
           
            3
           / \
          9  20
            /  \
           15   7
           返回：
           
           [3,9,20,15,7]
           
           
           提示：
           
           节点总数 <= 1000
         
         */
        static void Main(string[] args)
        {
            TreeNode x=new TreeNode(3)
            {
                left = new TreeNode(9),
                right = new TreeNode(20)
                {
                    left = new TreeNode(15),
                    right = new TreeNode(7)
                }
            };
            int[] res = LevelOrder(x);
            Console.WriteLine();
        }
        //层次遍历
        public static int[] LevelOrder(TreeNode root)
        {
            if (root == null) return new int[] { };
            List<int> val=new List<int>();
            Queue<TreeNode> nodeQueue=new Queue<TreeNode>();
            nodeQueue.Enqueue(root);
            while (nodeQueue.Count!=0)
            {
                TreeNode temp = nodeQueue.Dequeue();
                if(temp.left!=null)
                    nodeQueue.Enqueue(temp.left);
                if(temp.right!=null)
                    nodeQueue.Enqueue(temp.right);
                val.Add(temp.val);
            }
            
            return val.ToArray();
        }
    }
}
