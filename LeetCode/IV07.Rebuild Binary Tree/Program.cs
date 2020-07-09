using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataStructLibrary;
namespace IV07.Rebuild_Binary_Tree
{
    class Program
    {
        /*
         * 面试题07. 重建二叉树
           输入某二叉树的前序遍历和中序遍历的结果，请重建该二叉树。假设输入的前序遍历和中序遍历的结果中都不含重复的数字。
           
           例如，给出
           
           前序遍历 preorder = [3,9,20,15,7]
           中序遍历 inorder = [9,3,15,20,7]
           返回如下的二叉树：
            
            3
           / \
          9  20
            /  \
           15   7           
           
            限制：
           0 <= 节点个数 <= 5000
         */
        static void Main(string[] args)
        {
            int[] preOrder = {3, 9, 20, 15, 7};
            int[] inOrder = {9, 3, 15, 20, 7};
            TreeNode x=BuildTree(preOrder, inOrder);
            Console.WriteLine();
        }
        
        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0) return null;
            TreeNode root = new TreeNode(preorder[0]);
            for (int i = 0; i < inorder.Length; i++)
            {
                if (inorder[i]==preorder[0])
                {
                    int[] preOrderLeft = GetSubArray(preorder, 1, i);
                    int[] preOrderRight = GetSubArray(preorder, i+1, preorder.Length-i-1);
                    int[] inOrderLeft = GetSubArray(inorder, 0, i);
                    int[] inOrderRight = GetSubArray(inorder, i + 1, inorder.Length - i - 1);
                    root.left = BuildTree(preOrderLeft, inOrderLeft);
                    root.right = BuildTree(preOrderRight, inOrderRight);
                    break;
                }
            }
            return root;
        }

        public static int[] GetSubArray(int[] array,int index, int length)
        {
            return array.ToList().GetRange(index, length).ToArray();
        }
    }
}
