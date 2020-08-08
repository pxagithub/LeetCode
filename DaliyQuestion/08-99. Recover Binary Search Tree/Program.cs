using System;
using System.Collections.Generic;
using DataStructLibrary;

namespace _08_99._Recover_Binary_Search_Tree
{
            /*99. 恢复二叉搜索树
            二叉搜索树中的两个节点被错误地交换。
            请在不改变其结构的情况下，恢复这棵树。

            示例 1:
            输入: [1,3,null,null,2]
               1
              /
             3
              \
               2
            输出: [3,1,null,null,2]
               3
              /
             1
              \
               2

            示例 2:
            输入: [3,1,4,null,null,2]
              3
             / \
            1   4
               /
              2
            输出: [2,1,4,null,null,3]
              2
             / \
            1   4
               /
              3
            进阶:
            使用 O(n) 空间复杂度的解法很容易实现。
            你能想出一个只使用常数空间的解决方案吗？*/
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root=new TreeNode(1)
            {
                left = new TreeNode(3)
                {
                    right = new TreeNode(2)
                }
            };

            RecoverTree(root);
        }

        public static void  RecoverTree(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode x = null, y = null, pred = null;

            while (stack.Count!=0||root!=null)
            {
                while (root!=null)
                {
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();
                if (pred!=null&&root.val<pred.val)
                {
                    y = root;
                    if (x==null)
                    {
                        x = pred;
                    }
                    else
                    {
                        break;
                    }
                }

                pred = root;
                root = root.right;
            }

            int temp = x.val;
            x.val = y.val;
            y.val = temp;

        }

        
    }
}
