using System;

namespace KthLargestElementInAnArray
{

    /*
        215. 数组中的第K个最大元素
       在未排序的数组中找到第 k 个最大的元素。请注意，你需要找的是数组排序后的第 k 个最大的元素，而不是第 k 个不同的元素。
       
       示例 1:
       
       输入: [3,2,1,5,6,4] 和 k = 2
       输出: 5
       示例 2:
       
       输入: [3,2,3,1,2,4,5,5,6] 和 k = 4
       输出: 4
       说明:
       
       你可以假设 k 总是有效的，且 1 ≤ k ≤ 数组的长度。
       
       通过次数105,115提交次数169,655
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = {3, 2, 1, 5, 6, 4};
            int kx = 2;
            int[] y = {3, 2, 3, 1, 2, 4, 5, 5, 6};
            int ky = 4;
            Console.WriteLine(FindKthLargest(x,kx));
            Console.WriteLine(FindKthLargest(y,ky));
        }

        public static int FindKthLargest(int[] nums, int k)
        {

        }
    }
}
