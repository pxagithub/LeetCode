using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace _148_SortList
{
    /*
     * 148. 排序链表
       在 O(n log n) 时间复杂度和常数级空间复杂度下，对链表进行排序。
       
       示例 1:
       
       输入: 4->2->1->3
       输出: 1->2->3->4
       示例 2:
       
       输入: -1->5->3->4->0
       输出: -1->0->3->4->5
     */

    class Program
    {
        static void Main(string[] args)
        {
            ListNode x=new ListNode(4)
            {
                next = new ListNode(2)
                {
                    next =new ListNode(1)
                    {
                        next = new ListNode(3)
                    }
                }
            };
            ListNode y = new ListNode(-1)
            {
                next = new ListNode(5)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(0)
                        }
                    }
                }
            };

            ListNode res1 = SortList(x);
            ListNode res2 = SortList(y);
            Console.Write("[");
            while (res1 != null)
            {
                Console.Write(res1.val);
                res1 = res1.next;
                if (res1!=null)
                {
                    Console.Write(",");
                }
            } 
            Console.WriteLine("]");

            Console.Write("[");
            while (res2 != null)
            {
                Console.Write(res2.val);
                res2 = res2.next;
                if (res2 != null)
                {
                    Console.Write(",");
                }
            }
            Console.WriteLine("]");


        }
        public static ListNode SortList(ListNode head)
        {
            if (head==null||head.next==null)
            {
                return head;
            }

            int len = GetListNodeLength(head);
            ListNode current = head;

            ListNode[] nodes=new ListNode[len];

            for (int i = 0; i < len; i++)
            {
                nodes[i] = current;
                current = current.next;
            }

            //排序
            for (int i = (len-1)/2; i >=0; i--)
            {
                DownElement(nodes,i,len);
            }

            current = DeleteMin(nodes,len);
            ListNode first = current;
            while (current!=null)
            {
                len--;
                ListNode tmp = DeleteMin(nodes, len);
                current.next = tmp;
                current = tmp;
            }

            return first;
        }

        public static ListNode DeleteMin(ListNode[] arr, int length)
        {
            if (length<1)
            {
                return null;
            }

            ListNode node = arr[0];
            arr[0] = arr[length - 1];
            DownElement(arr, 0, length);
            return node;
        }

        public static void DownElement(ListNode[] arr, int hole, int length)
        {
            ListNode node = arr[hole];
            int child = hole;
            for (; (hole==0?1:hole*2)<length; hole=child)
            {
                child = hole == 0 ? 1 : hole * 2;
                if (child!=length-1&&arr[child+1].val<arr[child].val)
                {
                    child++;
                }

                if (arr[child].val<node.val)
                {
                    arr[hole] = arr[child];
                }
                else
                    break;
            }

            arr[hole] = node;
        }


        

        public static int GetListNodeLength(ListNode head)
        {
            int length = 0;
            ListNode curr = head;
            while (curr!=null)
            {
                length++;
                curr = curr.next;
            }

            return length;
        }

        
    }

    public class ListNode:IEnumerable
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public IEnumerator GetEnumerator()
        {
            yield return next;
        }
    }
}
