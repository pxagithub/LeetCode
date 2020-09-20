using System;
using System.Collections.Generic;

namespace _20__78.Subsets
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var subset in Subsets(new[] { 1, 2, 3 }))
            {
                Console.WriteLine("["+string.Join(",",subset)+"]");
            }
        }
        public static IList<IList<int>> Subsets(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();
            res.Add(new List<int>());
            if (nums.Length==0)
            {
                return res;
            }
            BackTracking(nums,0,new List<int>() , res);
            return res;

        }

        public static void BackTracking(int[] nums, int start, List<int> path, IList<IList<int>> res)
        {
            if (start==nums.Length)
            {
                return;
            }

            for (int i = start; i < nums.Length; i++)
            {
                path.Add(nums[i]);
                if (!res.Contains(path))
                {
                    res.Add(new List<int>(path));
                }

                BackTracking(nums, i + 1, path, res);

                path.Remove(nums[i]);
            }
        }
    }
}
