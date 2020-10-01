using System;
using DataStructLibrary;

namespace _30__701.Insert_into_a_Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            /*701. 二叉搜索树中的插入操作
               给定二叉搜索树（BST）的根节点和要插入树中的值，将值插入二叉搜索树。 返回插入后二叉搜索树的根节点。 输入数据保证，新值和原始二叉搜索树中的任意节点值都不同。
               
               注意，可能存在多种有效的插入方式，只要树在插入后仍保持为二叉搜索树即可。 你可以返回任意有效的结果。
               
               例如, 
            
             提示：

                给定的树上的节点数介于 0 和 10^4 之间
                每个节点都有一个唯一整数值，取值范围从 0 到 10^8
                -10^8 <= val <= 10^8
                新值和原始二叉搜索树中的任意节点值都不同
            */
            TreeNode root=new TreeNode(4)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },
                right = new TreeNode(7)
            };

            TreeNode res = InsertIntoBST(root, 5);
            
            Console.WriteLine();
        }

        public static TreeNode InsertIntoBST(TreeNode root, int val)
        {
            if (root == null)
            {
                return new TreeNode(val);
            }
            if (root.val < val && root.right == null)
            {
                root.right = new TreeNode(val);
            }
            if (root.val > val && root.left == null)
            {
                root.left = new TreeNode(val);
            }
            if (root.val < val && root.right != null)
            {
                InsertIntoBST(root.right, val);
            }
            if (root.val > val && root.left != null)
            {
                InsertIntoBST(root.left, val);
            }
            return root;
        }
    }
}
