using System;

namespace First
{
    class Program
    {
        
        static void Main(string[] args)
        {
            int[] arr = { 3, 0, 1, 1, 9, 7 };
            Console.WriteLine(CountGoodTriplets(arr, 7, 2, 3));
        }
        public static int CountGoodTriplets(int[] arr, int a, int b, int c)
        {
            int n = arr.Length;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        if (Math.Abs(arr[i] - arr[j]) <= a && Math.Abs(arr[j] - arr[k]) <= b && Math.Abs(arr[i] - arr[k]) <= c)
                        {
                            count++;
                        }

                    }
                }
            }

            return count;
        }
    }
}
