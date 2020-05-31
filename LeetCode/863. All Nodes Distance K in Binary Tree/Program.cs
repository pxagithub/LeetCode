using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices.ComTypes;
using DataStructLibrary;

namespace _863._All_Nodes_Distance_K_in_Binary_Tree
{
    class Program
    {
        /*
         * 863. 二叉树中所有距离为 K 的结点
           给定一个二叉树（具有根结点 root）， 一个目标结点 target ，和一个整数值 K 。
           
           返回到目标结点 target 距离为 K 的所有结点的值的列表。 答案可以以任何顺序返回。
           
           
           
           示例 1：
           
           输入：root = [3,5,1,6,2,0,8,null,null,7,4], target = 5, K = 2
           
           输出：[7,4,1]
           
           解释：
           所求结点为与目标结点（值为 5）距离为 2 的结点，
           值分别为 7，4，以及 1
           
                     3
                   /   \
                  /     \
                 5       1
                / \     / \
               /   \   /   \
              6     2 0     8
                   / \
                  /   \
                 7     4

           注意，输入的 "root" 和 "target" 实际上是树上的结点。
           上面的输入仅仅是对这些对象进行了序列化描述。
           
           
           提示：
           
           给定的树是非空的，且最多有 K 个结点。
           树上的每个结点都具有唯一的值 0 <= node.val <= 500 。
           目标结点 target 是树上的结点。
           0 <= K <= 1000.
           通过次数5,205提交次数10,550
         */
        static void Main(string[] args)
        {
            TreeNode x=new TreeNode(3)
            {
                left = new TreeNode(5)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(2)
                    {
                        left = new TreeNode(7),
                        right = new TreeNode(4)
                    }
                },
                right = new TreeNode(1)
                {
                    left = new TreeNode(0),
                    right = new TreeNode( 8)
                }
            };

            IList<int> res = DistanceK(x, x.left, 2);
            Console.WriteLine();
        }

        public  static Dictionary<int,long> map=new Dictionary<int, long>();
        public static IList<int> DistanceK(TreeNode root, TreeNode target, int K)
        {
            List<int> list = new List<int>();
            GetHuffmanCode(root,1);
            long targetCode = 0;

            foreach (var key in map.Keys)
            {
                if (key==target.val)
                {
                    targetCode = map[key];
                    break;
                }
            }

            foreach (var key in map.Keys)
            {
                if(DistanceCode(map[key],targetCode)==K)
                    list.Add(key);
            }

            return list;
        }
        //获得该树的赫夫曼编码
        public static void GetHuffmanCode(TreeNode root, long huffmanValue)
        {
            if(root==null) return;
            map.Add(root.val,huffmanValue);
            GetHuffmanCode(root.right, huffmanValue * 10 + 1);
            GetHuffmanCode(root.left, huffmanValue * 10 + 3);
        }
        //根据赫夫曼编码求距离
        //距离=节点1的赫夫曼编码的位数+节点2的赫夫曼编码的位数-节点1、2的赫夫曼编码重复的位数*2
        public static int DistanceCode(long val, long target)
        {
            long sameL = 0;
            long more = Math.Max(val, target);
            long less = Math.Min(val, target);

            long l1 = (long) Math.Log10(more) + 1;
            long l2 = (long) Math.Log10(less) + 1;

            double temp = Math.Abs(less * (Math.Pow(10, l1 - l2)) - more);

            sameL = (temp == 0) ? l1 : l1 - (long) (Math.Log10(temp + 1)) - 1;

            return (int) (l1 + l2 - 2 * sameL);
        }
        
    }
}
