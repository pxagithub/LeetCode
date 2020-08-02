using System;

namespace Fourth
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums1 = { 2, 4, 5, 8, 10 };
            int[] nums2 = { 4, 6, 8, 9 };
            Console.WriteLine(MaxSum(nums1,nums2));
        }

        public static int MaxSum(int[] nums1, int[] nums2)
        {
            long sum1 = 0, sum2 = 0;
            long res = 0;
            int i = 0, j = 0;
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] == nums2[j])
                {
                    res += (Math.Max(sum1, sum2) + nums1[i]);
                    sum1 = 0;
                    sum2 = 0;
                    i++;
                    j++;
                }
                else if (nums1[i] < nums2[j])
                {
                    sum1 += nums1[i];
                    i++;
                }
                else
                {
                    sum2 += nums2[j];
                    j++;
                }
            }
            while (i < nums1.Length)
            {
                sum1 += nums1[i];
                i++;
            }
            while (j < nums2.Length)
            {
                sum2 += nums2[j];
                j++;
            }
            res += Math.Max(sum1, sum2);
            return (int)(res % ((int)Math.Pow(10, 9) + 7));

            
        }
    }
}
