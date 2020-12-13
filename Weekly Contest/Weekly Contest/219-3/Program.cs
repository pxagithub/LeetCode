using System;
using System.Collections.Generic;

namespace _219_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(StoneGameVII(new[]
            {
                721, 979, 690, 84, 742, 873, 31, 323, 819, 22, 928, 866, 118, 843, 169, 818, 908, 832, 852, 480, 763,
                715, 875, 629
            }));//7948
            Console.WriteLine(StoneGameVII(new[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}));
            Console.WriteLine(StoneGameVII(new[] {5, 3, 1, 4, 2}));
            Console.WriteLine(StoneGameVII(new[] {7, 90, 5, 1, 100, 10, 10, 2}));
        }
        public static int StoneGameVII(int[] stones)
        {
            int n = stones.Length;
            int[] s=new int[n+1];
            for (int i = 1; i <= n; i++)
            {
                s[i] = s[i - 1] + stones[i - 1];
            }

            int[,] f = new int[n + 1, n + 1];
            for (int len = 2; len <= n; len++)
            {
                for (int i = 1; i + len - 1 <= n; i++)
                {
                    int j = i + len - 1;
                    f[i, j] = Math.Max(s[j] - s[i] - f[i + 1, j], s[j - 1] - s[i - 1] - f[i, j - 1]);
                }
            }

            return f[1, n];
        }
    }
}
