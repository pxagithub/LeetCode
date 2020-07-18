using System;

namespace _97.Interleaving_String
{
    class Program
    {
        /*97. 交错字符串
           给定三个字符串 s1, s2, s3, 验证 s3 是否是由 s1 和 s2 交错组成的。
           
           示例 1:
           
           输入: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
           输出: true
           示例 2:
           
           输入: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc"
           输出: false*/
        static void Main(string[] args)
        {
            Console.WriteLine(IsInterleave("aabcc", "dbbca", "aadbbcbcac"));//true
            Console.WriteLine(IsInterleave("aabcc", "dbbca", "aadbbbaccc"));//false
        }
        public static bool IsInterleave(string s1, string s2, string s3)
        {
            int l = s1.Length, m = s2.Length, n = s3.Length;
            if (l+m!=n)
            {
                return false;
            }

            bool[,] dp = new bool[l+1, m+1];

            dp[0, 0] = true;
            for (int i = 0; i <= l; i++)
            {
                for (int j = 0; j <= m; j++)
                {
                    int p = i + j - 1;
                    if (i>0)
                    {
                        dp[i, j] = dp[i, j] || (dp[i - 1,j] && s1[i - 1] == s3[p]);
                    }

                    if (j>0)
                    {
                        dp[i, j] = dp[i, j] || (dp[i,j - 1] && s2[j - 1] == s3[p]);
                    }
                }
            }
            return dp[l, m];
        }
    }
}
