using System;
using System.Collections.Generic;

namespace _17__52.N_Queens_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(TotalNQueens(1));//1
            Console.WriteLine(TotalNQueens(2));//0
            Console.WriteLine(TotalNQueens(3));//0
            Console.WriteLine(TotalNQueens(4));//2
            Console.WriteLine(TotalNQueens(5));//10
            Console.WriteLine(TotalNQueens(6));//4

        }

        public static int TotalNQueens(int n)
        {
            return Dfs(n, 0, 0, 0, 0);
        }

        public static int Dfs(int n, int row, int columns, int diagonalsPositives, int diagonalsNegatives)
        {
            if (row==n)
            {
                return 1;
            }

            int count = 0;
            int availablePositions = ((1 << n) - 1) & (~(columns | diagonalsPositives | diagonalsNegatives));
            while (availablePositions != 0)
            {
                int position = availablePositions & (-availablePositions);
                availablePositions = availablePositions & (availablePositions - 1);
                count += Dfs(n, row + 1, columns | position, (diagonalsPositives | position) << 1, (diagonalsNegatives | position) >> 1);
            }

            return count;
        }
    }
}
