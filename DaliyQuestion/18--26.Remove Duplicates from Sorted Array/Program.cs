using System;

namespace _18__26.Remove_Duplicates_from_Sorted_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1,1,2,2,3,3,4,5,6,7};
            int[] nums1 = {0, 0, 1, 1, 1, 2, 2, 3, 3, 4};
            // nums 是以“引用”方式传递的。也就是说，不对实参做任何拷贝
            int len = RemoveDuplicates(nums1);

            // 在函数里修改输入数组对于调用者是可见的。
            // 根据你的函数返回的长度, 它会打印出数组中 该长度范围内 的所有元素。
            for (int i = 0; i < len; i++)
            {
                Console.Write(nums1[i]);
            }

            
        }
        public static int RemoveDuplicates(int[] nums)
        {
            int len = nums.Length;
            int cur = 0;
            for (int i = 1; i < len; i++)
            {
                if (nums[cur]<nums[i])
                {
                    nums[++cur] = nums[i];
                }
            }

            return cur + 1;

        }
        
    }
}
