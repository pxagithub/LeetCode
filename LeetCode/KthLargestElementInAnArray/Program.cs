using System;
using System.Collections.Immutable;
using System.Security.Cryptography;

namespace KthLargestElementInAnArray
{

    /*
        215. 数组中的第K个最大元素
       在未排序的数组中找到第 k 个最大的元素。请注意，你需要找的是数组排序后的第 k 个最大的元素，而不是第 k 个不同的元素。
       
       示例 1:
       
       输入: [3,2,1,5,6,4] 和 k = 2
       输出: 5
       示例 2:
       
       输入: [3,2,3,1,2,4,5,5,6] 和 k = 4
       输出: 4
       说明:
       
       你可以假设 k 总是有效的，且 1 ≤ k ≤ 数组的长度。
       
       通过次数105,115提交次数169,655
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = {3, 2, 1, 5, 6, 4};
            int kx = 2;
            int[] y = {3, 2, 3, 1, 2, 4, 5, 5, 6};
            int ky = 4;
            int[] z = {7, 6, 5, 4, 3, 2, 1};
            int kz = 2;
            int[] a = {0};
            
            Console.WriteLine(FindKthLargest(x,kx));//输出5
            Console.WriteLine(FindKthLargest(y,ky));//输出4
            Console.WriteLine(FindKthLargest(z,kz));//输出6
            Console.WriteLine(FindKthLargest(a, 1));//输出0


            int[] b = { 2, 1 };
            Console.WriteLine(FindKthLargest(b,2));//输出1
        }

        public static int FindKthLargest(int[] nums, int k)
        {
            //排序
            //Array.Sort(nums);
            //return nums[nums.Length-k];

            //分治，快排
            int len = nums.Length;
            int low = 0;
            int high = len - 1;

            // 转换一下，第 k 大元素的索引是 len - k
            int target = len - k;

            while (true)
            {
                int index = QuickSort(nums, low, high);
                if (index == target)
                {
                    return nums[index];
                }
                else if (index < target)
                {
                    low = index + 1;
                }
                else
                {
                    high = index - 1;
                }
            }
        }

        public static int QuickSort(int[] nums, int low, int high)
        {
            Random r = new Random();
            int randomIndex;
            if (low < high)
            {
                randomIndex = low + 1 + r.Next(0, high - low);
                Swap(nums, low, randomIndex);
            }

            int pivot = nums[low];
            int j = low;
            for (int i = low + 1; i <= high; i++)
            {
                if (nums[i] < pivot)
                {
                    j++;
                    Swap(nums, i, j);
                }
            }
            Swap(nums, low, j);
            return j;
        }

        public static void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }
    }
}
