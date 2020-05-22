using System;
using System.Runtime.InteropServices;

namespace _493.ReversePairs
{
    class Program
    {
        /*
         *493. 翻转对
           给定一个数组 nums ，如果 i < j 且 nums[i] > 2*nums[j] 我们就将 (i, j) 称作一个重要翻转对。
           
           你需要返回给定数组中的重要翻转对的数量。
           
           示例 1:
           
           输入: [1,3,2,3,1]
           输出: 2
           示例 2:
           
           输入: [2,4,3,5,1]
           输出: 3
           注意:
           
           给定数组的长度不会超过50000。
           输入数组中的所有数字都在32位整数的表示范围内。
         */
        static void Main(string[] args)
        {
            int[] x = {1, 3, 2, 3, 1};
            int[] y = {2, 4, 3, 5, 1};
            Console.WriteLine(ReversePairs(x));
            Console.WriteLine(ReversePairs(y));

        }
        public static int ReversePairs(int[] nums)
        {
            return MergeSortedAndCount(nums, 0, nums.Length - 1);
        }

        public static int MergeSortedAndCount(int[] nums, int startIndex, int endIndex)
        {
            if (startIndex < endIndex)
            {
                int count = 0;
                int midIndex = (startIndex + endIndex) >> 1;
                count += MergeSortedAndCount(nums, startIndex, midIndex) +
                         MergeSortedAndCount(nums, midIndex + 1, endIndex);
                int leftIndex = startIndex;
                int rightIndex = midIndex + 1;
                while (leftIndex <= midIndex && rightIndex <= endIndex)
                {
                    if ((long) nums[leftIndex] > (2 * (long) nums[rightIndex]))
                    {
                        count += midIndex - leftIndex + 1;
                        rightIndex++;
                    }
                    else
                    {
                        leftIndex++;
                    }
                }

                Merge(nums, startIndex, midIndex, endIndex);
                return count;
            }
            else return 0;
        }

        public static void Merge(int[] nums, int startIndex, int midIndex, int endIndex)
        {
            int leftIndex = startIndex;
            int rightIndex = midIndex + 1;
            int i = 0;
            int[] array=new int[endIndex-startIndex+1];

            while (leftIndex<=midIndex&&rightIndex<=endIndex)
            {
                if (nums[leftIndex]<nums[rightIndex])
                {
                    array[i++] = nums[leftIndex++];
                }
                else
                {
                    array[i++] = nums[rightIndex++];
                }
            }

            while (leftIndex<=midIndex)
            {
                array[i++] = nums[leftIndex++];
            }

            while (rightIndex<=endIndex)
            {
                array[i++] = nums[rightIndex++];
            }

            for (int j = 0; j < endIndex-startIndex+1; j++)
            {
                nums[startIndex + j] = array[j];
            }
        }
    }
}
