using System;

namespace _410.Split_array_largest_sum
{
    class Program
    {
        /*410. 分割数组的最大值
           给定一个非负整数数组和一个整数 m，你需要将这个数组分成 m 个非空的连续子数组。设计一个算法使得这 m 个子数组各自和的最大值最小。
           注意:
           数组长度 n 满足以下条件:
           1 ≤ n ≤ 1000
           1 ≤ m ≤ min(50, n)
           示例:
           输入:
           nums = [7,2,5,10,8]
           m = 2
           输出:
           18
           解释:
           一共有四种方法将nums分割为2个子数组。
           其中最好的方式是将其分为[7,2,5] 和 [10,8]，
           因为此时这两个子数组各自的和的最大值为18，在所有情况中最小。*/
        static void Main(string[] args)
        {
            int[] x = {7, 2, 5, 10, 8,9,11};
            Console.WriteLine(SplitArrayByDp(x,4));
            Console.WriteLine(SplitArrayByDp(x, 4));

        }

        /// <summary>
        /// 动态规划
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int SplitArrayByDp(int[] nums, int m)
        {
            int n = nums.Length;
            int[][] dp = new int[n + 1][];
            for (int i = 0; i < n+1; i++)
            {
                dp[i]=new int[m+1];
                Array.Fill(dp[i],int.MaxValue);
            }

            int[] sub = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                sub[i + 1] = sub[i] + nums[i];
            }

            dp[0][0] = 0;
            for (int i = 1; i < n+1; i++)
            {
                for (int j = 1; j < Math.Min(i,m)+1; j++)
                {
                    for (int k = 0; k < i; k++)
                    {
                        dp[i][j] = Math.Min(dp[i][j], Math.Max(dp[k][j - 1], sub[i] - sub[k]));
                    }
                }
            }

            return dp[n][m];
        }

        /// <summary>
        /// 贪心+二分查找
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public static int SplitArrayByGreedyAndBinarySearch(int[] nums, int m)
        {
            int left = 0, right = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                right += nums[i];
                left = left < nums[i] ? nums[i] : left;
            }

            while (left<right)
            {
                int mid = (right - left) / 2 + left;
                if (Check(nums,mid,m))
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return left;
        }

        private static bool Check(int[] nums, int x, int m)
        {
            int sum = 0;
            int count = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                if (sum+nums[i]>x)
                {
                    count++;
                    sum = nums[i];
                }
                else
                {
                    sum += nums[i];
                }
            }

            return count <= m;
        }
    }
}
