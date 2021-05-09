using System;

namespace _240_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x1 = {55, 30, 5, 4, 2};
            int[] x2 = {100, 20, 10, 10, 5};
            Console.WriteLine(MaxDistance(x1,x2));
        }
        public static int MaxDistance(int[] nums1, int[] nums2)
        {
            int i = 0;
            int res = 0;
            while (i < nums1.Length)
            {
                int left = 0, right = nums2.Length-1;
                int mid = (left + right) / 2;
                while (nums1[i]>nums2[mid])
                {
                    mid = (mid + left) / 2;
                }

                while (mid+1<nums2.Length&&nums2[mid+1]>=nums1[i])
                {
                    mid++;
                }

                res = Math.Max(res, mid - i);

                i++;
            }

            return res;

        }
    }
}
