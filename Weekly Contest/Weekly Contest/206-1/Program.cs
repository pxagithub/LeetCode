using System;

namespace _206_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] x =
            {
                new[] {1,0,0},
                new[]{0,0,1},
                new[]{1,0,0}
            };
            Console.WriteLine(NumSpecial(x));
            
        }

        public static int NumSpecial(int[][] mat)
        {
            int res = 0;
            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[0].Length; j++)
                {

                    if (mat[i][j] == 1 && IsSpecial(mat, i, j)) 
                    {
                        res++;
                    }
                }
            }

            return res;
        }

        public static bool IsSpecial(int[][] mat, int row, int column)
        {
            for (int i = 0; i < mat.Length; i++)
            {
                if (i != row && mat[i][column] == 1) 
                {
                    return false;
                }
            }

            for (int i = 0; i < mat[0].Length; i++)
            {
                if (i != column && mat[row][i] == 1) 
                {
                    return false;
                }
            }

            return true;
        }
    }
}
