using System;
using System.Collections.Generic;
using System.Linq;

namespace _217_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = {3, 5, 2, 6};
            int[] y = {2, 4, 3, 3, 5, 4, 9, 6};
            Console.WriteLine(string.Join(",", MostCompetitive(x, 2)));
            Console.WriteLine(string.Join(",", MostCompetitive(y, 4)));

        }

        public static int[] MostCompetitive(int[] nums, int k)
        {
            List<int> res = nums.ToList();
            int i = 0;
            while (res.Count>k)
            {
                int j = i + 1;
                while (j<=nums.Length-k+i)
                {
                    if (nums[i] >= nums[j])
                    {
                        res.RemoveRange(i, j - i);
                    }

                    j++;
                }

                i++;
            }

            return res.ToArray();

        }
    }
}
