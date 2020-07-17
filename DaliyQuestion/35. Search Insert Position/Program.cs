using System;
using System.ComponentModel.Design;

namespace _35._Search_Insert_Position
{
    class Program
    {
        /*35. 搜索插入位置
           给定一个排序数组和一个目标值，在数组中找到目标值，并返回其索引。如果目标值不存在于数组中，返回它将会被按顺序插入的位置。
           你可以假设数组中无重复元素。
           示例 1:
           输入: [1,3,5,6], 5
           输出: 2
           示例 2:
           输入: [1,3,5,6], 2
           输出: 1
           示例 3:
           输入: [1,3,5,6], 7
           输出: 4
           示例 4:
           输入: [1,3,5,6], 0
           输出: 0*/
        static void Main(string[] args)
        {
            int[] x = {1, 3, 5, 6};
            Console.WriteLine(SearchInsert(x, 5));//2
            Console.WriteLine(SearchInsert(x, 2));//1
            Console.WriteLine(SearchInsert(x, 7));//4
            Console.WriteLine(SearchInsert(x, 0));//0
            Console.WriteLine(SearchInsert(new []{1},2));//1

        }

        public static int SearchInsert(int[] nums, int target)
        {
            #region 递归
            //if (nums.Length == 0) return 0;
            //int low = 0;
            //int high = nums.Length - 1;
            //int mid = (low + high) / 2;
            //if (target == nums[mid])
            //{
            //    return mid;
            //}
            //else if (target > nums[mid])
            //    return BinarySearch(nums, mid + 1, high, target);
            //else
            //    return BinarySearch(nums, low, mid, target);
            #endregion

            #region 循环

            if (nums.Length == 0) return 0;
            int low = 0, high = nums.Length - 1;
            while (low<=high)
            {
                int mid = (low + high) / 2;
                if (target == nums[mid])
                    return mid;
                else if (target > nums[mid])
                    low = mid + 1;
                else
                    high = mid - 1;
            }
            return low;

            #endregion

        }

        public static int BinarySearch(int[] nums, int low, int high, int target)
        {
            int mid = (low + high) / 2;
            if (low >= high)
            {
                if (nums[mid] == target)
                {
                    return mid;
                }
                else
                {
                    return target > nums[mid] ? mid + 1 : mid;
                }
            }
                
            if (target == nums[mid])
            {
                return mid;
            }
            else if (target > nums[mid])
                return BinarySearch(nums, mid + 1, high, target);
            else
                return BinarySearch(nums, low, mid, target);
        }
    }
}
