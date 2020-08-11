using System;
using System.Collections.Generic;

namespace _11_130.Surrounded_Regions
{
    class Program
    {
        /*130. 被围绕的区域
           给定一个二维的矩阵，包含 'X' 和 'O'（字母 O）。
           
           找到所有被 'X' 围绕的区域，并将这些区域里所有的 'O' 用 'X' 填充。
           
           示例:
           
           X X X X
           X O O X
           X X O X
           X O X X
           运行你的函数后，矩阵变为：
           
           X X X X
           X X X X
           X X X X
           X O X X
           解释:
           
           被围绕的区间不会存在于边界上，换句话说，任何边界上的 'O' 都不会被填充为 'X'。 任何不在边界上，或不与边界上的 'O' 相连的 'O' 最终都会被填充为 'X'。如果两个元素在水平或垂直方向相邻，则称它们是“相连”的。*/
        static void Main(string[] args)
        {
            char[][] x =
            {
                new[] {'X', 'X', 'X', 'X'},
                new[] {'X', 'O', 'O', 'X'},
                new[] {'X', 'X', 'O', 'X'},
                new[] {'X', 'O', 'X', 'X'}
            };
            Solve(x);
        }

        public static void Solve(char[][] board)
        {
            int m = board.Length, n = board[0].Length;

            for (int i = 0; i < m; i++)
            {
                Dfs(board, i, 0);
                Dfs(board, i, n - 1);
            }

            for (int i = 1; i < n-1; i++)
            {
                Dfs(board, 0, i);
                Dfs(board, m - 1, i);
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    board[i][j] = board[i][j] == 'A' ? 'O' : 'X';
                }
            }
        }

        public static void Dfs(char[][] board, int x, int y)
        {
            if (x < 0 || x >= board.Length || y < 0 || y >= board[0].Length || board[x][y] != 'O')
                return;
            board[x][y] = 'A';
            Dfs(board, x + 1, y);
            Dfs(board, x - 1, y);
            Dfs(board, x, y + 1);
            Dfs(board, x, y - 1);

        }
    }
}
