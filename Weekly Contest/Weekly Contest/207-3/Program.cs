using System;

namespace _207_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid =
            {

                new[] {-1, 4, 4, 0},
                new[] {-2, 0, 0, 1},
                new[] {1, -1, 1, 1}
            };
            Console.WriteLine(MaxProductPath(grid));
        }

        public static int MaxProductPath(int[][] grid)
        {
            int[][] dp=new int[grid.Length][];

            for (int i = 0; i < grid.Length; i++)
            {
                dp[i]=new int[grid[i].Length];
            }

            dp[0][0] = grid[0][0];

            for (int i = 1; i < dp.Length; i++)
            {
                dp[i][0] = grid[i][0] * dp[i - 1][0];
            }

            for (int i = 1; i < dp[0].Length; i++)
            {
                dp[0][i] = grid[0][i] * dp[0][i - 1];
            }

            for (int i = 0; i < dp.Length; i++)
            {
                for (int j = 0; j < dp.Length; j++)
                {
                    
                }
            }
        }
    }
}
