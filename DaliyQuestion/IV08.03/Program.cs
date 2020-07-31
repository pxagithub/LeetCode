using System;
using System.Text.RegularExpressions;

namespace IV08._03.Magic_Index
{
    class Program
    {
        /*面试题 08.03. 魔术索引
           魔术索引。 在数组A[0...n-1]中，有所谓的魔术索引，满足条件A[i] = i。给定一个有序整数数组，编写一种方法找出魔术索引，若有的话，在数组A中找出一个魔术索引，如果没有，则返回-1。若有多个魔术索引，返回索引值最小的一个。
           示例1:
           输入：nums = [0, 2, 3, 4, 5]
           输出：0
           说明: 0下标的元素为0
           示例2:
           输入：nums = [1, 1, 1]
           输出：1
           提示:
           nums长度在[1, 1000000]之间*/
        static void Main(string[] args)
        {
            int[] x = {0, 2, 3, 4, 5};
            int[] y = {1, 1, 1};
            Console.WriteLine(FindMagicIndex(x));
            Console.WriteLine(FindMagicIndex(y));
        }

        private static int res;
        private static int temp;
        public static int FindMagicIndex(int[] nums)
        {
            res = -1;
            if (nums.Length==0)
            {
                return res;
            }

            temp = int.MaxValue;
            int low = 0, high = nums.Length-1;
            Recur(nums, low, high);
            return res;
        }

        public static void Recur(int[] nums, int low, int high)
        {
            int mid = (low + high) / 2;
            if (nums[mid]==mid)
            {
                temp = Math.Min(temp, mid);
                res = temp;
                return;
            }

            if (low>=high)
            {
                return;
            }
            Recur(nums,low,mid-1);
            if (res==-1)
            {
                Recur(nums, mid + 1, high);
            }
            
            
        }
    }
}
