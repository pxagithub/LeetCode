using System;
using DataStructLibrary;

namespace _13__328.OddEvenLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListNode head=new ListNode(1){
                next=new ListNode(2){
                    next=new ListNode(3){
                        next=new ListNode(4){
                            next=new ListNode(5)
                        }
                    }
                }
            };
            ListNode res=OddEvenList(head);

        }
        public static ListNode OddEvenList(ListNode head) 
        {
            if(head==null||head.next==null||head.next.next==null){
                return head;
            }
            ListNode odd=head,even=head.next,temp=head.next;
            while(odd!=null&&even!=null){
                odd.next=even.next;
                if (odd.next!=null)
                {
                    odd=odd.next;
                }
                even.next=odd.next;
                even=even.next;
            }
            odd.next=temp;
            return head;
            
        }   
    }
}
