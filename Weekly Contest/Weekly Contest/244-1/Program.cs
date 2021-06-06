using System;

namespace _244_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool FindRotation(int[][] mat, int[][] target)
        {
            int n = mat.Length;
            int mark = 0, flag = 0;
            for (int k = 0; k < 4; k++)
            {
                mark = 1;


                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (mat[i][j] != target[i][j])
                        {
                            mark = 0;
                        }
                    }
                    if (mark == 0) break;
                }
                if (mark == 1) { flag = 1; break; }
                Spin(mat, n, n);
            }
            return flag == 1;
        }
        public static void Spin(int[][] a, int n, int m)
        {
            int temp = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    temp = a[i][j];
                    a[i][j] = a[j][i];
                    a[j][i] = temp;
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    temp = a[i][j];
                    a[i][j] = a[i][n - 1 - j];
                    a[i][n - 1 - j] = temp;
                }
            }
        }
    }
}
