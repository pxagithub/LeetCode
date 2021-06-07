using System;

namespace _494._目标和
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindTargetSumWays(new []{ 1 },1));
        }

        private static int res = 0;
        public static int FindTargetSumWays(int[] nums, int target)
        {
            Dfs(nums, target, 0, 0);
            return res;
        }

        public static void Dfs(int[] nums, int target, int sum, int index)
        {
            if (index == nums.Length)
            {
                if (sum == target)
                    res++;
            }
            else
            {
                Dfs(nums, target, sum + nums[index], index + 1);
                Dfs(nums, target, sum - nums[index], index + 1);
            }
            
        }
    }
}
