using System;

namespace _64.Minimum_path_sum
{
    class Program
    {
        /*64. 最小路径和
           给定一个包含非负整数的 m x n 网格，请找出一条从左上角到右下角的路径，使得路径上的数字总和为最小。
           说明：每次只能向下或者向右移动一步。
           示例:
           输入:
           [
           [1,3,1],
           [1,5,1],
           [4,2,1]
           ]
           输出: 7
           解释: 因为路径 1→3→1→1→1 的总和最小。*/
        static void Main(string[] args)
        {
            int[][] x =
            {
                new []{1, 3, 1},
                new []{1, 5, 1},
                new []{4, 2, 1}
            };
            int[][] y =
            {
                new[] {1, 2, 5},
                new[] {3, 2, 1}
            };
            Console.WriteLine(MinPathSum(x));
            Console.WriteLine(MinPathSum(y));

        }
        public static int MinPathSum(int[][] grid)
        {
            if (grid.Length==0)
            {
                return 0;
            }
            int row = grid.Length;
            int column = grid[0].Length;
            int[,] dp=new int[row,column];
            dp[0, 0] = grid[0][0];
            for (int i = 1; i < row; i++)
            {
                dp[i, 0] = dp[i - 1, 0] + grid[i][0];
            }
            for (int i = 1; i < column; i++)
            {
                dp[0, i] = dp[0, i - 1] + grid[0][i];
            }

            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < column; j++)
                {
                    dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
                }
            }

            return dp[row-1,column-1];
        }
    }
}
