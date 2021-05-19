using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _19_1738.Find_Kth_Largest_XOR_Coordinate_Value
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = {new[] {5, 2}, new[] {1, 6}};
            Console.WriteLine(KthLargestValue(matrix, 1));
            Console.WriteLine(KthLargestValue(matrix, 2));
            Console.WriteLine(KthLargestValue(matrix, 3));
            Console.WriteLine(KthLargestValue(matrix, 4));

        }
        public static int KthLargestValue(int[][] matrix, int k)
        {
            int m = matrix.Length, n = matrix[0].Length;
            int[,] xOr=new int[m,n];
            List<int> list = new List<int>();
            xOr[0, 0] = matrix[0][0];
            list.Add(xOr[0,0]);
            for (int i = 1; i < m; i++)
            {
                xOr[i, 0] = xOr[i - 1, 0] ^ matrix[i][0];
                list.Add(xOr[i,0]);
            }

            for (int i = 1; i < n; i++)
            {
                xOr[0, i] = xOr[0, i - 1] ^ matrix[0][i];
                list.Add(xOr[0, i]);
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    xOr[i, j] = xOr[i - 1, j] ^ xOr[i, j - 1] ^ xOr[i - 1, j - 1] ^ matrix[i][j];
                    list.Add(xOr[i,j]);
                }
            }

            list.Sort();

            return list[^k];
        }
    }
}
