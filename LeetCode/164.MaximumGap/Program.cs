using System;
using System.Collections.Generic;
using System.Linq;

namespace _164.MaximumGap
{
    class Program
    {
        /*
         * 164. 最大间距
           给定一个无序的数组，找出数组在排序之后，相邻元素之间最大的差值。
           
           如果数组元素个数小于 2，则返回 0。
           
           示例 1:
           
           输入: [3,6,9,1]
           输出: 3
           解释: 排序后的数组是 [1,3,6,9], 其中相邻元素 (3,6) 和 (6,9) 之间都存在最大差值 3。
           示例 2:
           
           输入: [10]
           输出: 0
           解释: 数组元素个数小于 2，因此返回 0。
           说明:
           
           你可以假设数组中所有元素都是非负整数，且数值在 32 位有符号整数范围内。
           请尝试在线性时间复杂度和空间复杂度的条件下解决此问题。
         */
        static void Main(string[] args)
        {
            int[] x = {4, 6, 9, 1};
            int[] y = {10};

            Console.WriteLine(BucketMaximumGap(x));
            Console.WriteLine(BucketMaximumGap(y));

        }
        public static int MaximumGap(int[] nums)
        {
            if (nums.Length < 2) return 0;

            int max = int.MinValue;
            Array.Sort(nums);

            for (int i = 0; i < nums.Length-1; i++)
            {
                int gap = nums[i + 1] - nums[i];
                if (gap>=max)
                    max = gap;
                
            }

            return max;

        }

        public static int BucketMaximumGap(int[] nums)
        {
            if (nums.Length<2)
            {
                return 0;
            }

            int minI = nums.Min();
            int maxI = nums.Max();

            int bucketSize = Math.Max(1, (maxI - minI) / (nums.Length - 1));
            int bucketNum = (maxI - minI) / bucketSize + 1;

            List<Bucket> buckets=new List<Bucket>(bucketNum);
            for (int i = 0; i < bucketNum; i++)
            {
                buckets.Add(new Bucket());
            }


            foreach (var num in nums)
            {
                int bucketIndex = (num - minI) / bucketSize;
                buckets[bucketIndex].used = true;
                buckets[bucketIndex].minVal = Math.Min(num, buckets[bucketIndex].minVal);
                buckets[bucketIndex].maxVal = Math.Max(num, buckets[bucketIndex].maxVal);
            }

            int prevBucketMax = minI, maxGap = 0;
            foreach (var bucket in buckets)
            {
                if (!bucket.used)
                {
                    continue;   
                }

                maxGap = Math.Max(maxGap, bucket.minVal - prevBucketMax);
                prevBucketMax = bucket.maxVal;
            }

            return maxGap;
        }


    }
    public class Bucket
    {
        internal bool used = false;
        internal int minVal = int.MaxValue;
        internal int maxVal = int.MinValue;

    }
}
