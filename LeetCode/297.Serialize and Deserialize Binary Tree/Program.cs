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
        /*
         * 297. 二叉树的序列化与反序列化
           序列化是将一个数据结构或者对象转换为连续的比特位的操作，进而可以将转换后的数据存储在一个文件或者内存中，同时也可以通过网络传输到另一个计算机环境，采取相反方式重构得到原数据。
           
           请设计一个算法来实现二叉树的序列化与反序列化。这里不限定你的序列 / 反序列化算法执行逻辑，你只需要保证一个二叉树可以被序列化为一个字符串并且将这个字符串反序列化为原始的树结构。
           
           示例: 
           
           你可以将以下二叉树：
           
           1
           / \
           2   3
           / \
           4   5
           
           序列化为 "[1,2,3,null,null,4,5]"
           提示: 这与 LeetCode 目前使用的方式一致，详情请参阅 LeetCode 序列化二叉树的格式。你并非必须采取这种方式，你也可以采用其他的方法解决这个问题。
           
           说明: 不要使用类的成员 / 全局 / 静态变量来存储状态，你的序列化和反序列化算法应该是无状态的。
         */
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

