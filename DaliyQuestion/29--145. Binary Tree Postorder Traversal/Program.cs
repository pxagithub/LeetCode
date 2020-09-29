using System;
using System.Collections.Generic;
using DataStructLibrary;

namespace _29__145._Binary_Tree_Postorder_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            /*145. 二叉树的后序遍历
                给定一个二叉树，返回它的 后序 遍历。
                
                示例:
                
                输入: [1,null,2,3]  
                   1
                    \
                     2
                    /
                   3 
                
                输出: [3,2,1]
                进阶: 递归算法很简单，你可以通过迭代算法完成吗？*/
            TreeNode root=new TreeNode(1)
            {
                right = new TreeNode(2)
                {
                    left = new TreeNode(3)
                }
            };
            Console.WriteLine(string.Join(",",PostorderTraversal(root)));
        }

        public static IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> res = new List<int>();
            if (root==null)
            {
                return res;
            }
            Stack<TreeNode> stack = new Stack<TreeNode>();

            TreeNode temp = null;
            while (stack.Count != 0 || root != null)
            {
                while (root!=null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();
                if (root.right==null||root.right==temp)
                {
                    res.Add(root.val);
                    temp = root;
                    root = null;
                }
                else
                {
                    stack.Push(root);
                    root = root.right;
                }

            } 
            return res;
        }
    }
}
