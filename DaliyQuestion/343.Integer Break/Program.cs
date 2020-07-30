﻿using System;
using System.Collections;

namespace _343.Integer_Break
{
    class Program
    {
        /*343. 整数拆分
           给定一个正整数 n，将其拆分为至少两个正整数的和，并使这些整数的乘积最大化。 返回你可以获得的最大乘积。
           示例 1:
           输入: 2
           输出: 1
           解释: 2 = 1 + 1, 1 × 1 = 1。
           示例 2:
           输入: 10
           输出: 36
           解释: 10 = 3 + 3 + 4, 3 × 3 × 4 = 36。
           说明: 你可以假设 n 不小于 2 且不大于 58。*/
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",",IntegerBreak(50),Check(50)));
            Console.WriteLine(string.Join(",", IntegerBreak(40), Check(40)));
            Console.WriteLine(string.Join(",", IntegerBreak(30), Check(30)));
            Console.WriteLine(string.Join(",", IntegerBreak(4), Check(4)));



        }

        public static int IntegerBreak(int n)
        {
            if (n <= 3)
            {
                return n - 1;
            }
            int[] dp = new int[n + 1];
            dp[2] = 1;
            dp[3] = 3;
            for (int i = 4; i < n + 1; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    dp[i] = Math.Max(dp[i], Math.Max(dp[i - j] * j, (i - j) * j));
                }
            }

            return dp[n];
        }

        public static int Check(int n)
        {
            return n <= 3 ? n - 1 : (Pow(3, n / 3)) * 4 / (4 - n % 3);

        }
        public static int Pow(int x, int y)
        {
            int res = 1;
            for (int i = 0; i < y; i++)
            {
                res *= x;
            }

            return res;
        }
    }
}
