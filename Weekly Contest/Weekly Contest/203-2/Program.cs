using System;
using System.Collections.Generic;
using System.Linq;

namespace _203_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = {2, 4, 1, 2, 7, 8};
            int[] y = {2, 4, 5};
            int[] z = {9, 8, 7, 6, 5, 1, 2, 3, 4};
            Console.WriteLine(MaxCoins(x));//9
            Console.WriteLine(MaxCoins(y));//4
            Console.WriteLine(MaxCoins(z));//18

        }

        public static int MaxCoins(int[] piles)
        {
            int n = piles.Length / 3;

            Array.Sort(piles);

            int res = 0;

            for (int i = 1; i <= n; i++)
            {
                res += piles[3*n - 2 * i];
            }

            return res;
        }
    }
}
