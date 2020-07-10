using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using DataStructLibrary;

namespace IV68_II.The_nearest_public_ancestor_of_the_binary_tree
{
    class Program
    {
        /*面试题68 - II. 二叉树的最近公共祖先
           给定一个二叉树, 找到该树中两个指定节点的最近公共祖先。 
           百度百科中最近公共祖先的定义为：“对于有根树 T 的两个结点 p、q，最近公共祖先表示为一个结点 x，满足 x 是 p、q 的祖先且 x 的深度尽可能大（一个节点也可以是它自己的祖先）。” 
           
           例如，给定如下二叉树:  root = [3,5,1,6,2,0,8,null,null,7,4]
     
           示例 1:
           
           输入: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 1
           输出: 3
           解释: 节点 5 和节点 1 的最近公共祖先是节点 3。
           示例 2:
           
           输入: root = [3,5,1,6,2,0,8,null,null,7,4], p = 5, q = 4
           输出: 5
           解释: 节点 5 和节点 4 的最近公共祖先是节点 5。因为根据定义最近公共祖先节点可以为节点本身。

           说明:           
           所有节点的值都是唯一的。
           p、q 为不同节点且均存在于给定的二叉树中。*/
        static void Main(string[] args)
        {
            TreeNode x = new TreeNode(3)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(2)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(4)
                    }
                },
                right = new TreeNode(1)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(8)
                }
            };
            TreeNode y = null;
            Console.WriteLine(LowestCommonAncestor(y, y, y).val);
            Console.WriteLine(LowestCommonAncestor(x, x.left, x.right).val);//3
            Console.WriteLine(LowestCommonAncestor(x, x.left, x.left.right.right).val);//5
        }
        static Dictionary<TreeNode, string> HuffmanCode;
        //LeetCode无C#环境，自测通过；
        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;
            HuffmanCode = new Dictionary<TreeNode, string>();
            GetHuffmanCode(root, "1");
            string pCode = HuffmanCode[p];
            string qCode = HuffmanCode[q];
            string ans = "";
            for (int i = 0; i < Math.Min(pCode.Length, qCode.Length); i++)
            {
                if (pCode[i] == qCode[i])
                    ans += pCode[i];
            }

            return HuffmanCode.FirstOrDefault( a=> a.Value == ans).Key;

        }

        public static void GetHuffmanCode(TreeNode root, string value)
        {
            if (root == null) return;
            HuffmanCode.Add(root, value);
            GetHuffmanCode(root.left, value + "0");
            GetHuffmanCode(root.right, value + "1");
        }
    }
}
