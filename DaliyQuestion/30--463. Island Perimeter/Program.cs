using System;

namespace _30__463._Island_Perimeter
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid =
            {
                new[] {0, 1, 0, 0},
                new[] {1, 1, 1, 0},
                new[] {0, 1, 0, 0},
                new[] {1, 1, 0, 0}
            };
            Console.WriteLine(IslandPerimeter(grid));
        }
        public static int IslandPerimeter(int[][] grid)
        {
            int res = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[0].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        if (i == 0) res++;
                        else
                        {
                            if (grid[i - 1][j] == 0) res++;
                        }
                        if (i == grid.Length - 1) res++;
                        else
                        {
                            if (grid[i + 1][j] == 0) res++;
                        }
                        if (j == 0) res++;
                        else
                        {
                            if (grid[i][j - 1] == 0) res++;
                        }
                        if (j == grid[0].Length - 1) res++;
                        else
                        {
                            if (grid[i][j + 1] == 0) res++;
                        }
                    }
                }
            }
            return res;

        }
    }
}
