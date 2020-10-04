using System;
using System.Collections.Generic;
using DataStructLibrary;

namespace _209_2
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(1)
            {
                left = new TreeNode(10)
                {
                    left = new TreeNode(3)
                    {
                        left = new TreeNode(12),
                        right = new TreeNode(8)
                    }
                },
                right = new TreeNode(4)
                {
                    left = new TreeNode(7)
                    {
                        left = new TreeNode(6)
                    },
                    right = new TreeNode(9)
                    {
                        right = new TreeNode(2)
                    }
                }
            };
            TreeNode temp=new TreeNode(5)
            {
                left = new TreeNode(9)
                {
                    left = new TreeNode(3),
                    right = new TreeNode(5)
                },
                right = new TreeNode(1)
                {
                    left = new TreeNode(7)
                }
            };
            Console.WriteLine(IsEvenOddTree(temp));
            Console.WriteLine(IsEvenOddTree(new TreeNode(1)));
        }

        public static bool IsEvenOddTree(TreeNode root)
        {
            if (root.val%2==0)
            {
                return false;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            List<TreeNode> list = new List<TreeNode>();
            int level = -1;
            queue.Enqueue(root);
            while (queue.Count!=0)
            {
                while (queue.Count!=0)
                {
                    list.Add(queue.Dequeue());
                }

                level++;
                if (!IsOrder(list,level))
                {
                    return false;
                }

                foreach (var t in list)
                {
                    if (t.left!=null)
                    {
                        queue.Enqueue(t.left);
                    }
                    if (t.right!=null)
                    {
                        queue.Enqueue(t.right);
                    }
                }
                list.Clear();
            }

            return true;
        }

        public static bool IsOrder(List<TreeNode> list,int level)
        {
            if (level%2==1)
            {
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i - 1].val <= list[i].val||list[i].val%2==1||list[i-1].val%2==1)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i - 1].val >= list[i].val || list[i].val % 2 == 0 || list[i - 1].val % 2 == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        
    }
}
