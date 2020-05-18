using System;

namespace _327.CountOfRangeSum
{
    class Program
    {
        /*
         * 327. 区间和的个数
           给定一个整数数组 nums，返回区间和在 [lower, upper] 之间的个数，包含 lower 和 upper。
           区间和 S(i, j) 表示在 nums 中，位置从 i 到 j 的元素之和，包含 i 和 j (i ≤ j)。
           
           说明:
           最直观的算法复杂度是 O(n2) ，请在此基础上优化你的算法。
           
           示例:
           
           输入: nums = [-2,5,-1], lower = -2, upper = 2,
           输出: 3 
           解释: 3个区间分别是: [0,0], [2,2], [0,2]，它们表示的和分别为: -2, -1, 2。
         */
        static void Main(string[] args)
        {
            int[] x = {-2, 5, 1};
            Console.WriteLine(CountRangeSum(x, -2, 2));

        }
        //错误
        public static int CountRangeSum(int[] nums, int lower, int upper)
        {
            int n = nums.Length;
            long[] sums=new long[n+1];
            long[] assists=new long[n+1];
            for (int i = 1; i <= n; i++)
            {
                sums[i] = sums[i - 1] + nums[i - 1];
            }

            return Merge(sums, assists, 0, n, lower, upper);
        }

        public static int Merge(long[] sums, long[] assists, int left, int right, int low, int up)
        {
            if (left >= right) return 0;
            int cnt = 0;
            int mid = left + (right - left) / 2;
            cnt += Merge(sums, assists, left, mid, low, up);
            cnt += Merge(sums, assists, mid + 1, right, low, up);

            int L = left;
            int upper = mid + 1, lower = mid + 1;
            while (L <= mid)
            {
                while (lower <= right && sums[lower] - sums[L] < low) lower++;
                while (upper <= right && sums[upper] - sums[L] <= up) upper++;

                cnt += upper - lower;
                L++;
            }

            L = left;
            int R = mid + 1;
            int pos = left;
            while (L<=mid||R<=right)
            {
                if (L > mid) assists[pos] = sums[R++];
                if (R > right && L <= mid) assists[pos] = sums[L++];

                if (L <= mid && R <= right)
                {
                    if (sums[L] <= sums[R]) assists[pos] = sums[L++];
                    else assists[pos] = sums[R++];
                }

                pos++;
            }

            for (int i = left; i <= right; i++) sums[i] = assists[i];
            return cnt;
        }
    }
}
