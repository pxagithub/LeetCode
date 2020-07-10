﻿using System;

namespace IV16._17.Continuous_sequence
{
    class Program
    {
        /*面试题 16.17. 连续数列
           给定一个整数数组，找出总和最大的连续数列，并返回总和。
           示例：
           输入： [-2,1,-3,4,-1,2,1,-5,4]
           输出： 6
           解释： 连续子数组 [4,-1,2,1] 的和最大，为 6。*/
        static void Main(string[] args)
        {
            int[] x = {-2, 1, -3, 4, -1, 2, 1, -5, 4};
            Console.WriteLine(x[^1]+x[^2]);
            Console.WriteLine(MaxSubArray(x));//6
        }

        static int MaxSubArray(int[] nums)
        {
            int[] dp=new int[nums.Length];
            dp[0] = nums[0];
            int max = dp[0];
            for (int i = 1; i < nums.Length-1; i++)
            {
                dp[i] = Math.Max(dp[i - 1] + nums[i], nums[i - 1] + nums[i]);
                max = Math.Max(dp[i], max);
            }

            return max;
        }
    }
}
