using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using DataStructLibrary;

namespace _24__501._Find_Mode_in_Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            /*501. 二叉搜索树中的众数
                   给定一个有相同值的二叉搜索树（BST），找出 BST 中的所有众数（出现频率最高的元素）。
                   
                   假定 BST 有如下定义：
                   
                   结点左子树中所含结点的值小于等于当前结点的值
                   结点右子树中所含结点的值大于等于当前结点的值
                   左子树和右子树都是二叉搜索树
                   例如：
                   给定 BST [1,null,2,2],
                      1
                       \
                        2
                       /
                      2
                   返回[2].
                   
                   提示：如果众数超过1个，不需考虑输出顺序
                   
                   进阶：你可以不使用额外的空间吗？（假设由递归产生的隐式调用栈的开销不被计算在内）*/
            TreeNode root=new TreeNode(1)
            {
                right = new TreeNode(2)
                {
                    left = new TreeNode(2)
                }
            };

            int[] res = FindMode(root);
            Console.WriteLine(string.Join(",", res));
        }

        private static Dictionary<int, int> dic;
        public static int[] FindMode(TreeNode root)
        {
            dic = new Dictionary<int, int>();
            Recursion(root);
            List<int> res = new List<int>();
            int max = 0;
            foreach (var number in dic)
            {
                if (number.Value>max)
                {
                    max = number.Value;
                    res.Clear();
                    res.Add(number.Key);
                }

                else if (number.Value==max)
                {
                    res.Add(number.Key);
                }

            }

            return res.ToArray();
        }

        public static void Recursion(TreeNode root)
        {
            if (root==null)
            {
                return;
            }

            if (!dic.ContainsKey(root.val))
            {
                dic.Add(root.val, 1);
            }
            else
            {
                dic[root.val]++;
            }

            Recursion(root.left);
            Recursion(root.right);
        }
    }
}
