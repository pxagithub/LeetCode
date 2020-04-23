using System;
using System.Collections.Generic;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] z = { 7, 6, 5, 4, 3, 2, 1 };
            QuickSortStrict(z);
            for (int i = 0; i < z.Length; i++)
            {
                Console.WriteLine(z[i]);
            }
        }
        public static void QuickSortStrict(int[] data)
         {
             QuickSortStrict(data, 0, data.Length - 1);
         }
 
         public static void QuickSortStrict(int[] data, int low, int high)
         {
             if (low >= high) return;
             int temp = data[low];
             int i = low + 1, j = high;
             while (true)
             {
                 while (data[j] > temp) j--;
                 while (data[i] < temp && i<j) i++;
                 if (i >= j) break;
                 Swap(data, i, j);
                 i++; j--;
             }
             if (j != low)
                 Swap(data, low, j);
             QuickSortStrict(data, j + 1, high);
             QuickSortStrict(data, low, j - 1);
         }
         public static void Swap(int[] nums, int i, int j)
         {
             int temp = nums[i];
             nums[i] = nums[j];
             nums[j] = temp;
         }
    }
}
