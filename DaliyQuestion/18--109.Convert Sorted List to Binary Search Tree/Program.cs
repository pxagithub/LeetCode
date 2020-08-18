using System;
using System.Collections.Generic;
using DataStructLibrary;

namespace _18__109.Convert_Sorted_List_to_Binary_Search_Tree
{
    class Program
    {
        /*109. 有序链表转换二叉搜索树
            给定一个单链表，其中的元素按升序排序，将其转换为高度平衡的二叉搜索树。
            示例:
            给定的有序链表： [-10, -3, 0, 5, 9],
            一个可能的答案是：[0, -3, 9, -10, null, 5], 它可以表示下面这个高度平衡二叉搜索树：
            
                  0
                 / \
               -3   9
               /   /
             -10  5*/
        static void Main(string[] args)
        {
            ListNode x=new ListNode(-10)
            {
                next = new ListNode(-3)
                {
                    next = new ListNode(0)
                    {
                        next = new ListNode(5)
                        {
                            next = new ListNode(9)
                        }
                    }
                }
            };

            TreeNode root = SortedListToBST(x);
            Console.WriteLine();
        }


        private static ListNode globalHead;
        public static TreeNode SortedListToBST(ListNode head)
        {
            globalHead = head;
            int len = GetLength(head);
            return BuildTree(0, len - 1);
        }

        private static TreeNode BuildTree(int left, int right)
        {
            if (left>right)
            {
                return null;
            }

            int mid = (left + right + 1) / 2;
            TreeNode root = new TreeNode(globalHead.val);
            root.left = BuildTree(left, mid - 1);
            globalHead = globalHead.next;
            root.right = BuildTree(mid + 1, right);
            return root;

        }

        private static int GetLength(ListNode head)
        {
            int res = 0;
            while (head!=null)
            {
                res++;
                head = head.next;
            }

            return res;
        }
    }
}
