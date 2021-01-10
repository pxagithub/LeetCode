using System;

namespace _223_2
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode a = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                        }
                    }
                }
            };
            Console.WriteLine(SwapNodes(a, 2));
        }

        public static ListNode SwapNodes(ListNode head, int k)
        {
            int count = 1;
            ListNode first = head, second = head.next;

            while (count < k)
            {
                second = second.next;
                count++;
            }
            ListNode temp = second;
            while (second.next != null)
            {
                first = first.next;
                second = second.next;
            }
            int t = temp.val;
            temp.val = first.val;
            first.val = t;
            return head;

        }
    }


    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}

