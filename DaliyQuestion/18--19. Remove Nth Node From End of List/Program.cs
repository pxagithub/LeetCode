using System;
using DataStructLibrary;

namespace _18__19._Remove_Nth_Node_From_End_of_List
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode x=new ListNode(1)
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
            ListNode y=new ListNode(1)
            {
                next = new ListNode(2)
            };

            ListNode res1 = RemoveNthFromEnd(x, 2);
            ListNode res2 = RemoveNthFromEnd(y, 2);
            ListNode res3 = RemoveNthFromEnd(y, 1);

            while (res1!=null)
            {
                Console.Write(res1.val+",");
                res1 = res1.next;
            }
            Console.WriteLine();
            Console.WriteLine(res2.val);
            Console.WriteLine(res3.val);
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            if (head.next == null)
            {
                return null;
            }
            ListNode temp = head;
            ListNode pre = head;
            int count = 0;
            while (temp.next != null)
            {
                if (count == n)
                {
                    pre = pre.next;
                    temp = temp.next;
                }
                else
                {
                    temp = temp.next;
                    count++;
                }
            }
            if (count<n)
            {
                return head.next;
            }

            pre.next = pre.next.next;
            return head;
        }
    }
}
