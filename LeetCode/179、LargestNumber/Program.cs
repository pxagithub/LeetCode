using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _179_LargestNumber
{
    class Program
    {
        /*
           179. 最大数
           给定一组非负整数，重新排列它们的顺序使之组成一个最大的整数。
           
           示例 1:
           
           输入: [10,2]
           输出: 210
           示例 2:
           
           输入: [3,30,34,5,9]
           输出: 9534330
           说明: 输出结果可能非常大，所以你需要返回一个字符串而不是整数。
         */
        static void Main(string[] args)
        {
            int[] x = {10, 2};
            int[] y = {3, 30, 34, 5, 9};
            Console.WriteLine(LargestNumber(x));
            Console.WriteLine(LargestNumber(y));

        }
        public static string LargestNumber(int[] nums)
        {
            //将输入数组转换为字符串
            string[] str=new string[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                str[i] = nums[i].ToString();
            }

            //通过比较类比较字符串大小
            Array.Sort(str,new LargerNumberComparator());

            //如果排序后的最大值是0，那么返回0
            if (str[0].Equals("0"))
            {
                return "0";
            }

            //从排序好的数组获得最大值
            StringBuilder largestNumberStr=new StringBuilder();
            foreach (var s in str)
            {
                largestNumberStr.Append(s);
            }

            return largestNumberStr.ToString();
        }

        private class LargerNumberComparator : Comparer<string>
        {

            public override int Compare(string a, string b)
            {
                string order1 = a + b;
                string order2 = b + a;
                return order2.CompareTo(order1);
            }
        }
    }
}
