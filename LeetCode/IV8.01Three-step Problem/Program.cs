using System;
using Microsoft.VisualBasic.CompilerServices;

namespace IV08._01Three_step_Problem
{
    class Program
    {
        /*面试题 08.01. 三步问题
           三步问题。有个小孩正在上楼梯，楼梯有n阶台阶，小孩一次可以上1阶、2阶或3阶。实现一种方法，计算小孩有多少种上楼梯的方式。结果可能很大，你需要对结果模1000000007。
           
           示例1:
           输入：n = 3 
           输出：4
           说明: 有四种走法
           示例2:
           输入：n = 5
           输出：13
           提示:
           n范围在[1, 1000000]之间*/
        static void Main(string[] args)
        {
            Console.WriteLine(WaysToStep(2));//2
            Console.WriteLine(WaysToStep(42));//641778114
            Console.WriteLine(WaysToStep(1000));//509672692
        }

        static int WaysToStep(int n)
        {
            if (n <= 3)
            {
                //n等于1，2，3时分别返回 1，2，4
                return n == 3 ? 4 : n;
            }
            long[] dp=new long[n+1];
            dp[1] = 1;
            dp[2] = 2;
            dp[3] = 4;
            for (int i = 4; i < n+1; i++)
            {
                dp[i] = (dp[i - 1] + dp[i - 2] + dp[i - 3]) % 1000000007;
            }

            return (int)dp[n];
        }
    }
}
