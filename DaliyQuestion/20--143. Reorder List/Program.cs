using System;
using System.Collections.Generic;
using DataStructLibrary;

namespace _20__143._Reorder_List
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head=new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                    }
                }
            };
            ReorderList(head);
            Console.WriteLine();
        }

        public static void ReorderList(ListNode head)
        {
            if (head==null)
            {
                return;
            }
            List<ListNode> list = new List<ListNode>();
            while (head!=null)
            {
                list.Add(head);
                head = head.next;
            }

            int i = 0, j = list.Count - 1;
            while (i<=j)
            {
                list[i].next = list[j];
                list[j].next = list[i + 1];
                i++;
                j--;
            }

            list[i].next = null;
        }
    }
}
