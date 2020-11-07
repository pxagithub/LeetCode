using System;

namespace _07__327._Count_of_Range_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CountRangeSum(new[] { -2, 5, -1 }, -2, 2));
        }

        /// <summary>
        /// 归并排序
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        //public static int CountRangeSum(int[] nums, int lower, int upper)
        //{
        //    long s = 0;
        //    long[] sum = new long[nums.Length + 1];
        //    for (int i = 0; i < nums.Length; ++i)
        //    {
        //        s += nums[i];
        //        sum[i + 1] = s;
        //    }
        //    return CountRangeSumRecursive(sum, lower, upper, 0, sum.Length - 1);
        //}
        /// <summary>
        /// 归并排序递归
        /// </summary>
        /// <param name="sum"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        //public static int CountRangeSumRecursive(long[] sum, int lower, int upper, int left, int right)
        //{
        //    if (left == right)
        //    {
        //        return 0;
        //    }
        //    else
        //    {
        //        int mid = (left + right) / 2;
        //        int n1 = CountRangeSumRecursive(sum, lower, upper, left, mid);
        //        int n2 = CountRangeSumRecursive(sum, lower, upper, mid + 1, right);
        //        int ret = n1 + n2;

        //        // 首先统计下标对的数量
        //        int i = left;
        //        int l = mid + 1;
        //        int r = mid + 1;
        //        while (i <= mid)
        //        {
        //            while (l <= right && sum[l] - sum[i] < lower)
        //            {
        //                l++;
        //            }
        //            while (r <= right && sum[r] - sum[i] <= upper)
        //            {
        //                r++;
        //            }
        //            ret += r - l;
        //            i++;
        //        }

        //        // 随后合并两个排序数组
        //        int[] sorted = new int[right - left + 1];
        //        int p1 = left, p2 = mid + 1;
        //        int p = 0;
        //        while (p1 <= mid || p2 <= right)
        //        {
        //            if (p1 > mid)
        //            {
        //                sorted[p++] = (int)sum[p2++];
        //            }
        //            else if (p2 > right)
        //            {
        //                sorted[p++] = (int)sum[p1++];
        //            }
        //            else
        //            {
        //                if (sum[p1] < sum[p2])
        //                {
        //                    sorted[p++] = (int)sum[p1++];
        //                }
        //                else
        //                {
        //                    sorted[p++] = (int)sum[p2++];
        //                }
        //            }
        //        }
        //        for (int j = 0; j < sorted.Length; j++)
        //        {
        //            sum[left + j] = sorted[j];
        //        }
        //        return ret;
        //    }
        //}

        
        
        
        /// <summary>
        /// 线段树
        /// </summary>
        public static int CountRangeSum(int[] nums, int lower, int upper)
        {
            long sum = 0;
            long[] preSum = new long[nums.Length + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
                preSum[i + 1] = sum;
            }

            long lbound = long.MaxValue, rbound = long.MinValue;
            foreach (var x in preSum)
            {
                lbound = Math.Min(Math.Min(lbound, x), Math.Min(x - lower, x - upper));
                rbound = Math.Max(Math.Max(rbound, x), Math.Max(x - lower, x - upper));
            }

            SegNode root = new SegNode(lbound, rbound);
            int res = 0;
            foreach (var x in preSum)
            {
                res += Count(root, x - upper, x - lower);
                Insert(root, x);
            }

            return res;
        }

        public static int Count(SegNode root, long left, long right )
        {
            if (root == null) return 0;
            if (left > root.Hi || right < root.Lo) return 0;
            if (left <= root.Lo && root.Hi <= right) return root.Add;
            return Count(root.LeftChild, left, right) + Count(root.RightChild, left, right);
        }

        public static void Insert(SegNode root, long val)
        {
            root.Add++;
            if(root.Lo==root.Hi) return;

            long mid = (root.Lo + root.Hi) >> 1;
            if (val<=mid)
            {
                if (root.LeftChild == null) root.LeftChild = new SegNode(root.Lo, mid);
                Insert(root.LeftChild, val);
            }
            else
            {
                if (root.RightChild == null) root.RightChild = new SegNode(mid + 1, root.Hi);
                Insert(root.RightChild, val);
            }
        }

        
    }

    class SegNode
    {
        public long Lo, Hi;
        public int Add;
        public SegNode LeftChild, RightChild;

        public SegNode(long left, long right)
        {
            Lo = left;
            Hi = right;
            Add = 0;
            LeftChild = null;
            RightChild = null;
        }
    }
}
