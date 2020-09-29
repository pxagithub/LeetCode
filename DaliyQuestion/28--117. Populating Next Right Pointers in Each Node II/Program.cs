using System;

namespace _28__117._Populating_Next_Right_Pointers_in_Each_Node_II
{
    class Program
    {
        static void Main(string[] args)
        {
            /*117. 填充每个节点的下一个右侧节点指针 II
               给定一个二叉树
               struct Node {
               int val;
               Node *left;
               Node *right;
               Node *next;
               }
               填充它的每个 next 指针，让这个指针指向其下一个右侧节点。如果找不到下一个右侧节点，则将 next 指针设置为 NULL。
               初始状态下，所有 next 指针都被设置为 NUL

               进阶：
               你只能使用常量级额外空间。
               使用递归解题也符合要求，本题中递归程序占用的栈空间不算做额外的空间复杂度。

               示例：
               输入：root = [1,2,3,4,5,null,7]
               输出：[1,#,2,3,#,4,5,7,#]
               解释：给定二叉树如图 A 所示，你的函数应该填充它的每个 next 指针，以指向其下一个右侧节点，如图 B 所示。
               提示：
               树中的节点数小于 6000
               -100 <= node.val <= 100*/
            Console.WriteLine();

        }

        public static Node Connect(Node root)
        {
            for (Node first = root, node = first; first != null;)
            {
                var last = new Node(-1); // 哨兵

                for (node = first, first = null; node != null; node = node.next)
                {
                    if (node.left is null && node.right is null) continue;

                    if (node.left != null)
                    {
                        last.next = node.left;
                        if (first is null) first = last;
                        last = last.next;
                    }

                    if (node.right != null)
                    {
                        last.next = node.right;
                        if (first is null) first = last;
                        last = last.next;
                    }
                }
            }
            return root;
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
