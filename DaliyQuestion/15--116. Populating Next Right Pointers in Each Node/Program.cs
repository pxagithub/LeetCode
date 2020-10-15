using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace _15__116._Populating_Next_Right_Pointers_in_Each_Node
{
    class Program
    {
        static void Main(string[] args)
        {
            Node root=new Node(1)
            {
                left = new Node(2)
                {
                    left = new Node(4),
                    right = new Node(5)
                },
                right = new Node(3)
                {
                    left = new Node(6),
                    right = new Node(7)
                }
            };
            Node res = Connect(root);
            Console.WriteLine();
        }

        public static Node Connect(Node root)
        {
            Dfs(root);
            return root;
        }

        public static void Dfs(Node root)
        {
            if (root==null)
            {
                return;
            }
            if (root.left!=null)
            {
                root.left.next = root.right;
                if (root.next==null)
                {
                    root.right.next = null;
                }
                else
                {
                    root.right.next = root.next.left;
                }

                Dfs(root.left);
                Dfs(root.right);
            }
        }
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}
