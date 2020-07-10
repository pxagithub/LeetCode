using System;

namespace IV42.Maximum_sum_of_consecutive_subarrays
{
    /*剑指 Offer 42. 连续子数组的最大和
       输入一个整型数组，数组里有正数也有负数。数组中的一个或连续多个整数组成一个子数组。求所有子数组的和的最大值。
       要求时间复杂度为O(n)。
       示例1:
       输入: nums = [-2,1,-3,4,-1,2,1,-5,4]
       输出: 6
       解释: 连续子数组 [4,-1,2,1] 的和最大，为 6。
       提示：
        1 <= arr.length <= 10^5
       -100 <= arr[i] <= 100*/
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = {-2, 1, -3, 4, -1, 2, 1, -5, 4};
            Console.WriteLine(MaxSubArray(x));
        }

        static int MaxSubArray(int[] nums)
        {
            int max = nums[0];
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (sum > 0)
                    sum += nums[i];
                else
                    sum = nums[i];
                max = Math.Max(max, sum);
            }

            return max;
        }
    }
}
