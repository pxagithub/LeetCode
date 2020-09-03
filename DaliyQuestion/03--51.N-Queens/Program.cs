using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.VisualBasic;

namespace _03__51.N_Queens
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            51. N 皇后
               n 皇后问题研究的是如何将 n 个皇后放置在 n×n 的棋盘上，并且使皇后彼此之间不能相互攻击。
               给定一个整数 n，返回所有不同的 n 皇后问题的解决方案。
               每一种解法包含一个明确的 n 皇后问题的棋子放置方案，该方案中 'Q' 和 '.' 分别代表了皇后和空位。
               
               示例：
               输入：4
               输出：[
               [".Q..",  // 解法 1
               "...Q",
               "Q...",
               "..Q."],
               
               ["..Q.",  // 解法 2
               "Q...",
               "...Q",
               ".Q.."]
               ]
               解释: 4 皇后问题存在两个不同的解法。

               提示：
               皇后彼此不能相互攻击，也就是说：任何两个皇后都不能处于同一条横行、纵行或斜线上。
             */
            IList<IList<string>> a = SolveNQueens(2);//[]
            IList<IList<string>> b = SolveNQueens(3);//[]
            IList<IList<string>> c = SolveNQueens(4);//[[".Q..","...Q","Q...","..Q."],["..Q.","Q...","...Q",".Q.."]]
            Console.WriteLine();
        }

        public static IList<IList<string>> SolveNQueens(int n)
        {
            var res = new List<IList<string>>();

            int[] queens = new int[n];

            Array.Fill(queens, -1);
            HashSet<int> columns = new HashSet<int>();
            HashSet<int> diagonals1 = new HashSet<int>();
            HashSet<int> diagonals2 = new HashSet<int>();
            Backtrack(res, queens, n, 0, columns, diagonals1, diagonals2);

            return res;



        }

        public static void Backtrack(List<IList<string>> res, int[] queens, int n, int row, HashSet<int> column,
            HashSet<int> diagonals1, HashSet<int> diagonals2)
        {
            if (row==n)
            {
                List<string> board = GenerateBoard(queens, n);
                res.Add(board);
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (column.Contains(i))
                    {
                        continue;
                    }

                    int diagonal1 = row - i;
                    if (diagonals1.Contains(diagonal1))
                    {
                        continue;
                    }

                    int diagonal2 = row + i;
                    if (diagonals2.Contains(diagonal2))
                    {
                        continue;
                    }

                    queens[row] = i;
                    column.Add(i);
                    diagonals1.Add(diagonal1);
                    diagonals2.Add(diagonal2);
                    Backtrack(res, queens, n, row + 1, column, diagonals1, diagonals2);
                    queens[row] = -1;
                    column.Remove(i);
                    diagonals1.Remove(diagonal1);
                    diagonals2.Remove(diagonal2);
                }
            }
        }

        public static List<string> GenerateBoard(int[] queens, int n)
        {
            List<string> board = new List<string>();
            for (int i = 0; i < n; i++)
            {
                char[] row = new char[n];
                Array.Fill(row, '.');
                row[queens[i]] = 'Q';
                board.Add(new string(row));
            }
            return board;
        }
    }
}
