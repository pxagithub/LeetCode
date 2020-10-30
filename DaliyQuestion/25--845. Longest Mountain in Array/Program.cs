using System;

namespace _25__845._Longest_Mountain_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(LongestMountain(new []{ 2, 1, 4, 7, 3, 2, 5 }));
            Console.WriteLine(LongestMountain(new[] {2, 2, 2}));

        }

        public static int LongestMountain(int[] A)
        {
            int max = 0;
            for (int i = 1; i < A.Length - 1; i++)
            {

                int left = i, right = i;
                while (true)
                {
                    if (left >= 1 && A[left] > A[left - 1])
                    {
                        left--;
                    }
                    if (right <= A.Length - 1 && A[right] > A[right + 1])
                    {
                        right--;
                    }
                    if (left == 0 && right == A.Length - 1) break;
                    if (A[left] <= A[left - 1] && A[right] <= A[right + 1]) break;
                }
                int temp = right - left + 1;
                max = max > temp ? max : temp;

            }
            return max > 2 ? max : 0;
        }
    }
}
