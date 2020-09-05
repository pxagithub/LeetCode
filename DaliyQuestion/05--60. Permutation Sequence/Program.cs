using System;
using System.Collections.Generic;

namespace _05__60._Permutation_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            /*60. 第k个排列
               给出集合 [1,2,3,…,n]，其所有元素共有 n! 种排列。
               按大小顺序列出所有排列情况，并一一标记，当 n = 3 时, 所有排列如下：
               "123"
               "132"
               "213"
               "231"
               "312"
               "321"
               给定 n 和 k，返回第 k 个排列。
               说明：
               给定 n 的范围是 [1, 9]。
               给定 k 的范围是[1,  n!]。

               示例 1:
               输入: n = 3, k = 3
               输出: "213"

               示例 2:
               输入: n = 4, k = 9
               输出: "2314"*/
            Console.WriteLine(GetPermutation(3, 3));
            Console.WriteLine(GetPermutation(4, 4));

        }

        public static string GetPermutation(int n, int k)
        {
            string res = "";
            if (n == 1) 
            {
                return res+"1";
            }

            int[] factorial = new int[n];
            factorial[1] = 1;
            List<string> nums = new List<string>();

            nums.Add("");

            for (int i = 1; i <= n; i++)
            {
                nums.Add(i.ToString());
            }

            for (int i = 2; i < n; i++)
            {
                factorial[i] = factorial[i - 1] * (i);
            }

            for (int i = 1; i < n; i++)
            {
                int temp = 1;
                while (k > factorial[n - i])
                {
                    k -= factorial[n - i];
                    temp++;
                }

                res += nums[temp];
                nums.RemoveAt(temp);
            }

            res += nums[1];

            return res;
        }
    }
}
