using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] z = { 7, 6, 5, 4, 3, 2, 1 };
            //QuickSortStrict(z);
            //for (int i = 0; i < z.Length; i++)
            //{
            //    Console.WriteLine(z[i]);
            //}
            int[] x = {12, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7};
            int[] res = FindMaximumSubarrayViolent(x);
            Console.WriteLine("起始数字："+x[res[0]]+ "起始位置:" + res[0]);
            Console.WriteLine("结束数字:"+x[res[1]]+"结束位置:"+res[1]);
            Console.WriteLine("最大子数组和："+res[2]);

        }
        public static void QuickSortStrict(int[] data)
        {
            QuickSortStrict(data, 0, data.Length - 1);
        }

        public static void QuickSortStrict(int[] data, int low, int high)
        {
            if (low >= high) return;
            int temp = data[low];
            int i = low + 1, j = high;
            while (true)
            {
                while (data[j] > temp) j--;
                while (data[i] < temp && i < j) i++;
                if (i >= j) break;
                Swap(data, i, j);
                i++; j--;
            }
            if (j != low)
                Swap(data, low, j);
            QuickSortStrict(data, j + 1, high);
            QuickSortStrict(data, low, j - 1);
        }
        public static void Swap(int[] nums, int i, int j)
        {
            int temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }

        public static int[] FindMaximumSubarrayViolent(int[] a)
        {
            int max = int.MinValue;
            int[] res=new int[3];
            int sum;
            for (int i = 0; i < a.Length; i++)
            {
                sum = 0;
                for (int j = i; j < a.Length; j++)
                {
                    
                    sum += a[j];
                    if (sum > max)
                    {
                        max = sum;
                        res[0] = i;
                        res[1] = j;
                    }
                }
            }
            res[2] = max;
            return res;
        }

        public static int[] FindMaximumSubarray(int[] a, int low, int high)
        {
            
            if (high==low)
            {
                int[] res = new int[3];
                res[0] = low;
                res[1] = high;
                res[2] = a[low];
                return res;
            }

            else
            {
                int mid = (low + high) / 2;
                int[] resleft = FindMaximumSubarray(a, low, mid);
                int[] resright = FindMaximumSubarray(a, mid + 1, high);
                int[] rescross = FindMaximumCrossingSubarray(a, low, mid, high);
                if (resleft[2]>=resright[2]&&resleft[2]>rescross[2])
                {
                    return resleft;
                }
                else if (resright[2]>=resleft[2]&&resright[2]>=rescross[2])
                {
                    return resright;
                }
                else
                {
                    return rescross;
                }
            }
        }


        public static int[] FindMaximumCrossingSubarray(int[] a, int low, int mid, int high)
        {
            int[] res = new int[3];
            int leftsum = int.MinValue;
            int sum = 0;
            for (int i = mid; i > low; i--)
            {
                sum += a[i];
                if (sum > leftsum)
                {
                    leftsum = sum;
                    res[0] = i;
                }
            }

            int rightsum = int.MinValue;
            sum = 0;
            for (int j = mid + 1; j < high; j++)
            {
                sum += a[j];
                if (sum > rightsum)
                {
                    rightsum = sum;
                    res[1] = j;
                }
            }

            res[2] = leftsum + rightsum;
            return res;
        }

    }
}
