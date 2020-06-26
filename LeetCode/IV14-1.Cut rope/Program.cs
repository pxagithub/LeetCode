using System;
using System.Collections.Generic;
using System.Numerics;

namespace IV14_1.Cut_rope
{
    class Program
    {
        /*剑指 Offer 14- I. 剪绳子
           给你一根长度为 n 的绳子，请把绳子剪成整数长度的 m 段（m、n都是整数，n>1并且m>1），每段绳子的长度记为 k[0],k[1]...k[m-1] 。请问 k[0]*k[1]*...*k[m-1] 可能的最大乘积是多少？例如，当绳子的长度是8时，我们把它剪成长度分别为2、3、3的三段，此时得到的最大乘积是18。
           示例 1：
           输入: 2
           输出: 1
           解释: 2 = 1 + 1, 1 × 1 = 1
           示例 2:
           输入: 10
           输出: 36
           解释: 10 = 3 + 3 + 4, 3 × 3 × 4 = 36
           提示：
           2 <= n <= 58*/
        static void Main(string[] args)
        {
            Console.WriteLine(CuttingRopeDP(120));
            Console.WriteLine(CuttingRopeDP(10));
        }
        //数学推理
        public static int CuttingRope(int n)
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
        //动态规划 dp[i]=max(dp[i-j]*j)
        public static int CuttingRopeDP(int n)
        {
            if (n == 2)
                return 1;
            BigInteger[] dp=new BigInteger[n+1];
            dp[2] = 1;
            for (int i = 3; i <= n; i++)
            {
                BigInteger q = int.MinValue;
                for (int j = 1; j < i; j++)
                {
                    q = Max(q, Max(dp[i - j] * j,(i-j)*j));
                }
                dp[i] = q;
            }
            BigInteger res = dp[n] % 1000000007;
            return (int)res;
        }
        public static BigInteger Max(BigInteger x, BigInteger y)
        {
            return x > y ? x : y;
        }

    }
}
