using System;
using System.Collections.Generic;

namespace DataStructLibrary
{
    public class BinaryTreeNode
    {
        public int val;
        public BinaryTreeNode left;
        public BinaryTreeNode right;
        public BinaryTreeNode(int x) { val = x; }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }
    }

    public class TreeNode
    {
        public int val;
        
        public List<TreeNode> children;

        public TreeNode(int x)
        {
            val = x;
        }
    }
}
