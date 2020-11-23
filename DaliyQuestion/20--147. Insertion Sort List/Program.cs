using System;

namespace _20__147._Insertion_Sort_List
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ListNode head = new ListNode(-3)
            {
                next = new ListNode(4)
                {
                    next = new ListNode(5)
                    {
                        next = new ListNode(1)
                    }
                }
            };
            ListNode res = InsertionSortList(head);
        }
        public static ListNode InsertionSortList(ListNode head)
        {
            ListNode pre = head;
            ListNode node = pre.next;
            while (node != null)
            {
                ListNode target = head;
                while (target!=node&&node.val >= target.val)
                {
                    if (target.next == null || node.val < target.next.val) break;
                    target = target.next;

                }

                if (target==node)
                {
                    pre = node;
                    node = node.next;
                    continue;
                }
                if (target == head)
                {
                    ListNode temp = head;
                    pre.next = node.next;
                    head = node;
                    node = temp;
                    head.next = node;
                }
                else
                {
                    ListNode temp = target.next;
                    target.next = node;
                    pre.next = node.next;
                    node.next = temp;
                }
                pre = node;
                node = node.next;

            }
            return head;


        }
    }
}
