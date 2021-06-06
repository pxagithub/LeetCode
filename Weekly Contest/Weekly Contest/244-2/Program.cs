using System;

namespace _244_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReductionOperations (new[] { 5, 1, 3 }));
            Console.WriteLine(ReductionOperations(new[] { 1, 1, 1 }));
            Console.WriteLine(ReductionOperations(new[] { 1, 1, 2, 2, 3 }));

        }

        public static int ReductionOperations(int[] nums)
        {
            Array.Sort(nums);
            int res = 0, n = nums.Length;
            for (int i = n-2; i >= 0; i--)
            {
                if (nums[i + 1] != nums[i])
                {
                    res += n - i-1;
                }
            }
            return res;
        }
    }
}
