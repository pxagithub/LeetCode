using System;

namespace _221_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a1 = new[] {9, 10, 1, 7, 0, 2, 1, 4, 1, 7, 0, 11, 0, 11, 0, 0, 9, 11, 11, 2, 0, 5, 5};
            int[] d1 = new[] {3, 19, 1, 14, 0, 4, 1, 8, 2, 7, 0, 13, 0, 13, 0, 0, 2, 2, 13, 1, 0, 3, 7};
            int[] a2 = new[] {1, 2, 3, 5, 2};
            int[] d2 = new[] {3, 2, 1, 4, 2};
            int[] a3 = {3, 0, 0, 0, 0, 2};
            Console.WriteLine(EatenApples(a2, d2));
            Console.WriteLine(EatenApples(a3, a3));
            Console.WriteLine(EatenApples(a1, d1));
        }

        public static int EatenApples(int[] a, int[] d)
        {
            int maxN = 0;
            for (int i = 0; i < d.Length; i++)
            {
                maxN = Math.Max(maxN, i + d[i]);
            }

            int[] badDay = new int[maxN+1];

            int n = a.Length;

            for (int i = 0; i < n; i++)
            {
                badDay[i + d[i]] += a[i];
            }
            int countZero = 0;
            for (int i = 0; i < badDay.Length; i++)
            {
                
                if (badDay[i] == 0) countZero++;
                else
                {
                    int min = Math.Min(badDay[i], i);
                    countZero = countZero > min ? countZero - min - 1 : 0;
                }
            }

            return badDay.Length - countZero;

        }
    }
}
