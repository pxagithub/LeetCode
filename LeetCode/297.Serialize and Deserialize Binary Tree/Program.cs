using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using DataStructLibrary;
using Microsoft.VisualBasic.CompilerServices;

namespace _297.Serialize_and_Deserialize_Binary_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeNode root = new TreeNode(4)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },
                right = new TreeNode(5)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(7)
                }

            };
            TreeNode root1 = new TreeNode(2)
            {
                left = new TreeNode(1),
                right = new TreeNode(3)
            };

            Codec codec = new Codec();
            string res1 = codec.serialize(root);
            TreeNode treeRoot = codec.deserialize(res1);
            string res2 = codec.serialize(root1);
            TreeNode treeRoot2 = codec.deserialize(res2);

            Console.WriteLine();
        }
    }
    //LeetCode中C#执行时间最短的答案
    public class Codec
    {
        private char[] IntToChars(int value)
        {
            char[] cs = new char[2];
            cs[0] = (char)value;
            cs[1] = (char)(value >> 16);
            return cs;
        }

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

