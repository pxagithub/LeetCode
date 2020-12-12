using System;

namespace _12__376.Wiggle_Subsequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(WiggleMaxLength(new[] {3,3,3,2,5}));
        }

        public static int WiggleMaxLength(int[] nums)
        {
            if (nums.Length <= 1) return nums.Length;

            int[] minus = new int[nums.Length - 1];
            for (int i = 1; i < nums.Length; i++)
            {
                minus[i - 1] = nums[i] - nums[i - 1];
            }
            int pre = minus[0];
            int res = pre==0?0:1;
            for (int i = 1; i < minus.Length; i++)
            {
                if (pre > 0)
                {
                    if (minus[i] < 0) { res++; pre = minus[i]; }
                    else pre += minus[i];
                }
                else if (pre < 0)
                {
                    if (minus[i] > 0) { res++; pre = minus[i]; }
                    else pre += minus[i];
                }
                else
                {
                    pre += minus[i];
                    if (pre != 0) res++;
                }
            }
            return res + 1;


        }
    }
}
