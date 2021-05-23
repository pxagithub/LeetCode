using System;
using System.Collections.Generic;

namespace _23_1707._与数组中元素的最大异或值
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaximizeXor(new []{ 0, 1, 2, 3, 4 },new []{new []{3,1},new []{1,3},new []{5,6}}));
        }
        public static int[] MaximizeXor(int[] nums, int[][] queries)
        {
            int[] res = new int[queries.Length];
            HashSet<int> set = new HashSet<int>();
            int min = int.MaxValue, max = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                min = Math.Min(nums[i], min);
                max = Math.Max(nums[i], max);
                if (!set.Contains(nums[i]))
                {
                    set.Add(nums[i]);
                }
            }

            for (int i = 0; i < queries.Length; i++)
            {
                int x = queries[i][0], m = queries[i][1];
                if (m < min) res[i] = -1;
                else
                {
                    if (m <= set.Count)
                    {
                        int temp = 0;
                        foreach (var s in set)
                        {
                            temp = Math.Max(temp, s ^ x);
                        }
                        res[i] = temp;
                    }
                    else
                    {
                        int temp = 0;
                        for (int j = 0; j <= m; j++)
                        {
                            if (set.Contains(j))
                            {
                                temp = Math.Max(temp, x ^ j);
                            }
                        }
                        res[i] = temp;
                    }
                }
            }
            return res;

        }
    }
}
