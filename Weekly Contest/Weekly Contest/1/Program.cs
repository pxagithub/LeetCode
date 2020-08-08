using System;

namespace _1
{
    class Program
    {
        private static void Main(string[] args)
        {
            int[] x = { 2, 3, 4, 7, 11 };
            Console.WriteLine((int) FindKthPositive(x, 5));
        }

        public static int FindKthPositive(int[] arr, int k)
        {
            if (arr.Length == 0)
            {
                return k;
            }

            int count = 0;

            int i = 0, j = 1;
            while (i < arr.Length)
            {
                if (arr[i] == j)
                {
                    i++;
                    j++;
                }
                else
                {
                    j++;
                    count++;
                }

                if (count == k)
                {
                    return j - 1;
                }
            }

            return k - count + j;
        }
    }
}
