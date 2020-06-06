using System;
using System.Collections.Generic;
using DataStructLibrary;

namespace IV26.Child_Structure_of_Tree
{
    class Program
    {
        /*
         * 面试题26. 树的子结构
           输入两棵二叉树A和B，判断B是不是A的子结构。(约定空树不是任意一个树的子结构)
           B是A的子结构， 即 A中有出现和B相同的结构和节点值。           
           例如:
           给定的树 A:           
            3
           / \
          4   5
         / \
        1   2
           给定的树 B：
             4 
            /
           1
           返回 true，因为 B 与 A 的一个子树拥有相同的结构和节点值。
           
           示例 1：
           
           输入：A = [1,2,3], B = [3,1]
           输出：false
           示例 2：
           
           输入：A = [3,4,5,1,2], B = [4,1]
           输出：true
           限制：
           
           0 <= 节点个数 <= 10000
         */
        static void Main(string[] args)
        {
            TreeNode a = new TreeNode(3)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(2)
                },
                right = new TreeNode(5)
            };
            TreeNode b=new TreeNode(4){left = new TreeNode(1)};

            TreeNode x=new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
            };
            TreeNode y=new TreeNode(3){left = new TreeNode(1)};
            

            Console.WriteLine(IsSubStructure(a,b));
            Console.WriteLine(IsSubStructure(x,y));
        }
        public static bool IsSubStructure(TreeNode A, TreeNode B)
        {
            return (A != null && B != null) && (Recur(A, B) || IsSubStructure(A.left, B) || IsSubStructure(A.right, B));

        }

        public static bool Recur(TreeNode A, TreeNode B)
        {
            if (B == null) return true;
            if (A == null || A.val != B.val) return false;
            return Recur(A.left, B.left) && Recur(A.right, B.right);
        }
        
    }
}
