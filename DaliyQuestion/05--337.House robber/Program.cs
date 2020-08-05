using System;
using System.Collections.Generic;
using System.Reflection;
using DataStructLibrary;

namespace _05__337.House_robber
{
    class Program
    {
        /*337. 打家劫舍 III
                在上次打劫完一条街道之后和一圈房屋后，小偷又发现了一个新的可行窃的地区。这个地区只有一个入口，我们称之为“根”。 除了“根”之外，每栋房子有且只有一
                个“父“房子与   之相 连。一  番侦察之后，聪明的小偷意识到“这个地方的所有房屋的排列类似于一棵二叉树”。 如果两个直接相连的房子在同一天晚上被劫，房屋
                将自动报警。
                计算在不触动警报的情况下，小偷一晚能够盗取的最高金额。
                
                示例 1:
                输入: [3,2,3,null,3,null,1]
                
                     3
                    / \
                   2   3
                    \   \ 
                     3   1
                输出: 7 
                解释: 小偷一晚能够盗取的最高金额 = 3 + 3 + 1 = 7.

                示例 2:
                输入: [3,4,5,1,3,null,3]
                
                     3
                    / \
                   4   5
                  / \   \ 
                 1   3   3
                输出: 9
                解释: 小偷一晚能够盗取的最高金额 = 3+1+3+3 = 10.*/
        static void Main(string[] args)
        {
            TreeNode x=new TreeNode(3)
            {
                left = new TreeNode(4)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(3)
                },
                right = new TreeNode(5)
                {
                    right = new TreeNode(3)
                }
            };

            Console.WriteLine(Rob(x));
        }

        

        public static int Rob(TreeNode root)
        {

            int[] result=RobRecur(root);

            return Math.Max(result[0],result[1]);
        }

        public static int[] RobRecur(TreeNode root)
        {
            if (root == null) return new int[2];
            int[] result = new int[2];

            int[] left = RobRecur(root.left);
            int[] right = RobRecur(root.right);

            result[0] = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
            result[1] = left[0] + right[0] + root.val;

            return result;
        }

        
    }
}
