using System;
using DataStructLibrary;

namespace _889._Construct_Binary_Tree_from_Preorder_and_Postorder_Travers
{
    class Program
    {
        /*
         * 889. 根据前序和后序遍历构造二叉树
           返回与给定的前序和后序遍历匹配的任何二叉树。
           
           pre 和 post 遍历中的值是不同的正整数。           
           
           示例：
           
           输入：pre = [1,2,4,5,3,6,7], post = [4,5,2,6,7,3,1]
           输出：[1,2,3,4,5,6,7]
           
           提示：
           1 <= pre.length == post.length <= 30
           pre[] 和 post[] 都是 1, 2, ..., pre.length 的排列
           每个输入保证至少有一个答案。如果有多个答案，可以返回其中一个。
         */
        static void Main(string[] args)
        {
            int[] pre = {1, 2, 4, 5, 3, 6, 7};
            int[] pos = {4, 5, 2, 6, 7, 3, 1};
            TreeNode x = ConstructFromPrePostTranversal(pre, pos);
            preIndex = 0;
            posIndex = 0;
            ConstructFromPrePostTranversal(pre:pre,pos:pos);
            Console.WriteLine();
        }

        public static int preIndex = 0, posIndex = 0;
        /// <summary>
        /// 构建符合先序遍历和后序遍历的二叉树
        /// </summary>
        /// <param name="pre">先序遍历数组</param>
        /// <param name="pos">后序遍历数组</param>
        /// <returns>构建二叉树的根节点</returns>
        public static TreeNode ConstructFromPrePostTranversal(int[] pre, int[] pos)
        {
            TreeNode root = new TreeNode(pre[preIndex++]);
            //通过后序遍历检验当前树是否完成构建
            if (root.val != pos[posIndex]) 
                root.left = ConstructFromPrePostTranversal(pre, pos);
            if (root.val != pos[posIndex]) 
                root.right = ConstructFromPrePostTranversal(pre, pos);
            posIndex++;
            return root;

        }
    }
}
