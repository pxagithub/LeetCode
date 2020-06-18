﻿using System;
using DataStructLibrary;

namespace IV68_I.The_nearest_common_ancestor_of_the_binary_search_tree
{
    class Program
    {
        /*面试题68 - I. 二叉搜索树的最近公共祖先
           给定一个二叉搜索树, 找到该树中两个指定节点的最近公共祖先。
           
           百度百科中最近公共祖先的定义为：“对于有根树 T 的两个结点 p、q，最近公共祖先表示为一个结点 x，满足 x 是 p、q 的祖先且 x 的深度尽可能大（一个节点也可以是它自己的祖先）。”
           
           例如，给定如下二叉搜索树:  root = [6,2,8,0,4,7,9,null,null,3,5]
                    6
                  /   \
                 2     8
                / \   / \
               0   4 7   9
                  / \
                 3   5
           示例 1:           
           输入: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 8
           输出: 6 
           解释: 节点 2 和节点 8 的最近公共祖先是 6。
           示例 2:           
           输入: root = [6,2,8,0,4,7,9,null,null,3,5], p = 2, q = 4
           输出: 2
           解释: 节点 2 和节点 4 的最近公共祖先是 2, 因为根据定义最近公共祖先节点可以为节点本身。
           说明:       
           所有节点的值都是唯一的。
           p、q 为不同节点且均存在于给定的二叉搜索树中。
           */
        static void Main(string[] args)
        {
            TreeNode x=new TreeNode(6)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(0),
                    right = new TreeNode(4)
                    {
                        left = new TreeNode(3),
                        right = new TreeNode(5)
                    }
                },
                right = new TreeNode(8)
                {
                    left = new TreeNode(7),
                    right = new TreeNode(9)
                }
            };
            Console.WriteLine(LowestCommonAncestor(x,x.left,x.right).val);
            Console.WriteLine(LowestCommonAncestor(x,x.left,x.left.right).val);
        }

        static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if ((p.val < root.val && q.val > root.val) || (p.val > root.val && q.val < root.val) || root == p || root == q)
                return root;
            if (p.val < root.val && q.val < root.val)
                return LowestCommonAncestor(root.left, p, q);
            if (q.val > root.val && p.val > root.val)
                return LowestCommonAncestor(root.right, p, q);
            return root;
        }
    }
}
