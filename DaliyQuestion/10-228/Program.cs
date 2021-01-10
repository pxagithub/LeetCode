using System;
using System.Collections.Generic;

namespace _10_228
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", SummaryRanges(new[] {0, 1, 2, 4, 5, 7})));
            Console.WriteLine(string.Join(",", SummaryRanges(new[] {0, 2, 3, 4, 6, 8, 9})));
        }
        public static IList<string> SummaryRanges(int[] nums)
        {
            List<string> res = new List<string>();
            if (nums.Length == 0) return res;
            int index = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] - nums[i - 1] == 1)
                    continue;
                else
                {
                    if (index == i - 1)
                    {
                        res.Add(nums[index].ToString());
                    }
                    else
                    {
                        res.Add(nums[index].ToString() + "->" + nums[i - 1].ToString());
                    }
                    index = i;
                }
            }

            if (index==nums.Length-1)
            {
                res.Add(nums[index].ToString());
            }
            else
            {
                res.Add(nums[index].ToString() + "->" + nums[^1].ToString());
            }
            return res;


        }
    }
}
