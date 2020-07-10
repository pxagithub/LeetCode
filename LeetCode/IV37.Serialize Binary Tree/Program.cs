using System;
using System.Collections.Generic;
using System.Text;
using DataStructLibrary;

namespace IV37.Serialize_Binary_Tree
{
    class Program
    {
        /*
         *面试题37. 序列化二叉树
           请实现两个函数，分别用来序列化和反序列化二叉树。
           
           示例: 
           
           你可以将以下二叉树：
           
            1
           / \
          2   3
             / \
            4   5
           
           序列化为 "[1,2,3,null,null,4,5]"
         */
        static void Main(string[] args)
        {
            TreeNode x=new TreeNode(1)
            {
                left = new TreeNode(2),
                right = new TreeNode(3)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                }
            };
            Codec c=new Codec();
            string resStr = c.serialize(x);
            TreeNode resRoot = c.deserialize(resStr);
            Console.WriteLine();

        }

    }
    public class Codec
    {
        //整型转换为字符
        private char[] IntToChars(int value)
        {
            char[] cs = new char[2];
            cs[0] = (char)value;
            cs[1] = (char)(value >> 16);
            return cs;
        }
        //字符转换位整型
        private int CharsToInt(string data, int index)
        {
            int value = data[index + 1];
            value <<= 16;
            value |= data[index];
            return value;
        }

        // Encodes a tree to a single string.
        public string serialize(TreeNode root)
        {
            if (root == null)
            {
                return string.Empty;
            }
            StringBuilder builder = new StringBuilder();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            while (root != null || stack.Count > 0)
            {
                while (root != null)
                {
                    builder.Append(IntToChars(root.val));
                    int flag = 0;
                    if (root.left != null)
                    {
                        flag |= 1;
                    }
                    if (root.right != null)
                    {
                        flag |= 2;
                    }
                    builder.Append((char)flag);
                    stack.Push(root);
                    root = root.left;
                }

                root = stack.Pop();
                root = root.right;
            }
            return builder.ToString();
        }

        // Decodes your encoded data to tree.
        public TreeNode deserialize(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }
            int index = 0;
            TreeNode root = new TreeNode(CharsToInt(data, index));
            index += 2;
            int flag = data[index++];
            Tuple<TreeNode, int> p = new Tuple<TreeNode, int>(root, flag);
            Stack<Tuple<TreeNode, int>> stack = new Stack<Tuple<TreeNode, int>>();
            while (p != null || stack.Count > 0)
            {
                while (p != null)
                {
                    stack.Push(p);
                    if ((p.Item2 & 1) == 1)
                    {
                        p.Item1.left = new TreeNode(CharsToInt(data, index));
                        index += 2;
                        flag = data[index++];
                        p = new Tuple<TreeNode, int>(p.Item1.left, flag);
                    }
                    else
                    {
                        p = null;
                    }
                }

                p = stack.Pop();
                if ((p.Item2 & 2) == 2)
                {
                    p.Item1.right = new TreeNode(CharsToInt(data, index));
                    index += 2;
                    p = new Tuple<TreeNode, int>(p.Item1.right, data[index++]);
                }
                else
                {
                    p = null;
                }
            }
            return root;
        }
    }
}
