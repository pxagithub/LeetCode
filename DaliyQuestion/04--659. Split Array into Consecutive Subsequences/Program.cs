using System;
using System.Collections.Generic;

namespace _04__659._Split_Array_into_Consecutive_Subsequences
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPossible(new []{ 1, 2, 3, 3, 4, 5 }));
            Console.WriteLine(IsPossible(new []{ 1, 2, 3, 3, 4, 4, 5, 5 }));
            Console.WriteLine(IsPossible(new []{ 1, 2, 3, 4, 4, 5 }));
        }

        public static bool IsPossible(int[] nums)
        {
            Dictionary<int, int> counter = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (counter.ContainsKey(nums[i]))
                {
                    counter[nums[i]]++;
                }
                else
                {
                    counter.Add(nums[i], 1);
                }
            }
            Dictionary<int, int> end = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (counter[nums[i]] == 0)
                {
                    continue;
                }
                counter[nums[i]] -= 1;
                if (end.ContainsKey(nums[i] - 1) && end[nums[i] - 1] > 0)
                {
                    end[nums[i] - 1] -= 1;
                    if (end.ContainsKey(nums[i]))
                    {
                        end[nums[i]] += 1;
                    }
                    else
                    {
                        end.Add(nums[i], 1);
                    }
                }
                else if (counter.ContainsKey(nums[i] + 1) && counter[nums[i] + 1] > 0 && counter.ContainsKey(nums[i] + 2) && counter[nums[i] + 2] > 0)
                {
                    counter[nums[i] + 1] -= 1;
                    counter[nums[i] + 2] -= 1;
                    if (end.ContainsKey(nums[i] + 2))
                    {
                        end[nums[i] + 2] += 1;
                    }
                    else
                    {
                        end.Add(nums[i] + 2, 1);
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;


        }
    }
}
