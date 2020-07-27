using System;
using System.Collections;
using System.Collections.Generic;

namespace _329._Longest_Increasing_Path_in_a_Matrix
{
    class Program
    {
        /*329. 矩阵中的最长递增路径
           给定一个整数矩阵，找出最长递增路径的长度。
           对于每个单元格，你可以往上，下，左，右四个方向移动。 你不能在对角线方向上移动或移动到边界外（即不允许环绕）。
           示例 1:
           输入: nums = 
           [
           [9,9,4],
           [6,6,8],
           [2,1,1]
           ] 
           输出: 4 
           解释: 最长递增路径为 [1, 2, 6, 9]。
           示例 2:
           输入: nums = 
           [
           [3,4,5],
           [3,2,6],
           [2,2,1]
           ] 
           输出: 4 
           解释: 最长递增路径是 [3, 4, 5, 6]。注意不允许在对角线方向上移动。*/
        static void Main(string[] args)
        {
            int[][] x =
            {
                new[] {9, 9, 4},
                new[] {6, 6, 8},
                new[] {2, 1, 1}
            };
            Console.WriteLine(LongestIncreasingPath(x));
        }

        public static int[][] dirs =
        {
            new[] {-1, 0},
            new[] {1, 0},
            new[] {0, -1},
            new[] {0, 1},

        };

        public static int rows, columns;
        public static int LongestIncreasingPath(int[][] matrix)
        {
            if (matrix==null||matrix.Length==0||matrix[0].Length==0)
            {
                return 0;
            }

            rows = matrix.Length;
            columns = matrix[0].Length;
            int[,] outdegrees = new int[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    foreach (var dir in dirs)
                    {
                        int newRow = i + dir[0], newColumn = j + dir[1];
                        if (newRow>=0&&
                            newRow<rows&&
                            newColumn>=0&&
                            newColumn<columns&&
                            matrix[newRow][newColumn]>matrix[i][j])
                        {
                            ++outdegrees[i, j];
                        }
                    }
                }
            }

            Queue<int[]> queue=new Queue<int[]>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if(outdegrees[i,j]==0)
                        queue.Enqueue(new []{i,j});
                }
            }

            int ans = 0;
            while (queue.Count != 0)
            {
                ++ans;
                int size = queue.Count;
                for (int i = 0; i < size; i++)
                {
                    int[] cell = queue.Dequeue();
                    int row = cell[0], column = cell[1];
                    foreach (var dir in dirs)
                    {
                        int newRow = row + dir[0], newColumn = column + dir[1];
                        if (newRow >= 0 &&
                            newRow < rows &&
                            newColumn >= 0 &&
                            newColumn < columns &&
                            matrix[newRow][newColumn] < matrix[row][column])
                        {
                            --outdegrees[newRow, newColumn];
                            if (outdegrees[newRow, newColumn] == 0)
                            {
                                queue.Enqueue(new []{newRow,newColumn});
                            }
                        }
                    }
                }
            }

            return ans;
        }
    }
}
