using System;

namespace MajorityElement
{
    /*
        169.多数元素（求众数）
        给定一个大小为 n 的数组，找到其中的多数元素。多数元素是指在数组中出现次数大于 ⌊ n/2 ⌋ 的元素。

        你可以假设数组是非空的，并且给定的数组总是存在多数元素。

        示例 1:
        输入: [3,2,3]
        输出: 3

        示例 2:
        输入: [2,2,1,1,1,2,2]
        输出: 2
     */

    class Program
    {
        static void Main(string[] args)
        {
            int[] x = {3, 2, 3};
            int[] y = {2, 2, 1, 1, 1, 2, 2};
            int[] z = {8, 9, 8, 9, 8};
            Console.WriteLine(MajorityElement(x));
            Console.WriteLine(MajorityElement(y));
            Console.WriteLine(MajorityElement(z));
        }

        public static int MajorityElement(int[] nums)
        {
            return MajorityElementRec(nums, 0, nums.Length - 1);
        }

        public static int MajorityElementRec(int[] nums, int lo, int hi)
        {
            //base case: the only element in an array of size 1 is the majority
            //element.
            if (lo == hi)
            {
                return nums[lo];
            }

            //recurse on left and right parts of the slice
            int mid = (hi - lo) / 2 + lo;
            int left = MajorityElementRec(nums, lo, mid);
            int right = MajorityElementRec(nums, mid + 1, hi);

            //if the two parts agree on the majority element, return it.
            if (left == right)
            {
                return left;
            }

            //otherwise, count each element and return the "winner".
            int leftCount = CountInRange(nums, left, lo, hi);
            int rightCount = CountInRange(nums, right, lo, hi);

            return leftCount > rightCount ? left : right;

        }

        public static int CountInRange(int[] nums, int num, int lo, int hi)
        {
            int count = 0;
            for (int i = lo; i <= hi; i++)
            {
                if (nums[i] == num)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
