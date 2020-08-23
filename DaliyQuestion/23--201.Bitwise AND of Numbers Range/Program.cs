using System;

namespace _23__201.Bitwise_AND_of_Numbers_Range
{
    class Program
    {
        /*201. 数字范围按位与
           给定范围 [m, n]，其中 0 <= m <= n <= 2147483647，返回此范围内所有数字的按位与（包含 m, n 两端点）。
           
           示例 1: 
           
           输入: [5,7]
           输出: 4
           示例 2:
           
           输入: [0,1]
           输出: 0*/
        static void Main(string[] args)
        {
            Console.WriteLine(RangeBitWiseAnd(5,7));
            Console.WriteLine(RangeBitWiseAnd(0,1));
            Console.WriteLine(RangeBitWiseAnd(20000, 2147483647));
        }

        public static int RangeBitWiseAnd(int m, int n)
        {
            int zeros = 0;
            while (n>m)
            {
                n = n & (n - 1);
            }

            return n;
        }

    }
}
