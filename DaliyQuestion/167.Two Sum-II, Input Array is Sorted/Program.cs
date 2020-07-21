using System;

namespace _167.Two_Sum_II__Input_Array_is_Sorted
{
    class Program
    {
        /*167. 两数之和 II - 输入有序数组
           给定一个已按照升序排列 的有序数组，找到两个数使得它们相加之和等于目标数。
           函数应该返回这两个下标值 index1 和 index2，其中 index1 必须小于 index2。
           说明:
           返回的下标值（index1 和 index2）不是从零开始的。
           你可以假设每个输入只对应唯一的答案，而且你不可以重复使用相同的元素。
           示例:
           输入: numbers = [2, 7, 11, 15], target = 9
           输出: [1,2]
           解释: 2 与 7 之和等于目标数 9 。因此 index1 = 1, index2 = 2 。*/
        static void Main(string[] args)
        {
            int[] x = {2, 7, 11, 15};
            Console.WriteLine(string.Join(",", TwoSum(x, 9)));//1,2
            Console.WriteLine(string.Join(",", TwoSum(x, 13)));//1,3
            Console.WriteLine(string.Join(",", TwoSum(x, 22)));//2,4
            Console.WriteLine(string.Join(",", TwoSum(x, 17)));//1,4
            int[] y = {3, 24, 50, 79, 88, 150, 345};
            Console.WriteLine(string.Join(",",TwoSum(y,200)));//3,6

        }
        //二分查找
        //public static int[] TwoSum(int[] numbers, int target)
        //{
        //    int res1 = 0, res2 = 0;
        //    for (int i = 0; i < numbers.Length; i++)
        //    {
        //        int temp = target - numbers[i];
        //        int low = i+1, high = numbers.Length - 1;
        //        while (low <= high)
        //        {
        //            int mid = (low + high) / 2;
        //            if (numbers[mid]==temp)
        //            {
        //                res1 = i + 1;
        //                res2 = mid + 1;
        //                return new int[]{res1,res2};
        //            }

        //            if (numbers[mid]>temp)
        //            {
        //                high = mid-1;
        //            }

        //            if (numbers[mid]<temp)
        //            {
        //                low = mid+1;
        //            }
        //        }
        //    }
        //    return new int[]{res1,res2};
        //}
        

        /// <summary>
        /// 双指针
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] numbers, int target)
        {
            int i = 0, j = numbers.Length - 1;
            while (i<j)
            {
                int temp = numbers[i] + numbers[j];
                if (temp>target)
                {
                    j--;
                    continue;
                }

                if (temp < target)
                {
                    i++;
                    continue;
                }
                else
                {
                    return new int[]{i+1,j+1};
                }
            }
            return new int[]{0,0};
        }

        
    }
}
