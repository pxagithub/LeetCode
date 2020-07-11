using System;
using System.Collections;
using System.Collections.Generic;

namespace _315.Count_of_smaller_numbers_after_self
{
    class Program
    {
        /*315. 计算右侧小于当前元素的个数
           给定一个整数数组 nums，按要求返回一个新数组 counts。数组 counts 有该性质： counts[i] 的值是  nums[i] 右侧小于 nums[i] 的元素的数量。
           示例:
           输入: [5,2,6,1]
           输出: [2,1,1,0] 
           解释:
           5 的右侧有 2 个更小的元素 (2 和 1).
           2 的右侧仅有 1 个更小的元素 (1).
           6 的右侧有 1 个更小的元素 (1).
           1 的右侧有 0 个更小的元素.*/
        static void Main(string[] args)
        {
            int[] x = {5, 2, 6, 1};
            Console.WriteLine(string.Join(",",CountSmallerByMergeAndIndex(x)));
        }

        //归并排序法+索引数组法
        public static int[] index;
        public static int[] counter;
        public static int[] temp;
        public static IList<int> CountSmallerByMergeAndIndex(int[] nums)
        {
            List<int> res = new List<int>();
            int len = nums.Length;
            if (len == 0) return res;

            temp = new int[len];
            counter = new int[len];
            index = new int[len];

            for (int i = 0; i < len; i++)
            {
                index[i] = i;
            }

            MergeAndCountSmaller(nums, 0, len - 1);
            for (int i = 0; i < len; i++)
            {
                res.Add(counter[i]);
            }

            return res;
        }

        private static void MergeAndCountSmaller(int[] nums, int l, int r)
        {
            if(l==r) return;//只有一个元素时不统计

            int mid = l + (r - l) / 2;
            MergeAndCountSmaller(nums, l, mid);
            MergeAndCountSmaller(nums, mid + 1, r);
            //归并排序的优化同样适用于该问题，如果索引数组有序则没必要继续计算
            if (nums[index[mid]]>nums[index[mid+1]])
            {
                MergeOfTwoSortedArrayAndCountSmaller(nums, l, mid, r);
            }
        }

        private static void MergeOfTwoSortedArrayAndCountSmaller(int[] nums, in int l, in int mid, in int r)
        {
            for (int k = l; k <= r; k++)  temp[k] = index[k]; 
                
            int i = l;
            int j = mid + 1;
            //左边出列的时候，计数
            for (int k = l; k <= r ; k++)
            {
                if (i > mid)
                {
                    index[k] = temp[j];
                    j++;
                }
                else if(j>r)
                {
                    index[k] = temp[i];
                    i++;
                    //此时j用完了,[7,8,9 | 1,2,3]
                    //之前的数就和后面的区间长度构成逆序
                    counter[index[k]] += (r - mid);
                }
                else if (nums[temp[i]]<=nums[temp[j]])
                {
                    index[k] = temp[i];
                    i++;
                    //此时[4,5,6 | 1,2,3,10,12,13]
                    //      mid          j
                    counter[index[k]] += (j - mid - 1);
                }
                else
                {//nums[index[i]]>num[index[j]] 构成逆序
                    index[k] = temp[j];
                    j++;
                }
            }

        }
    }
}
