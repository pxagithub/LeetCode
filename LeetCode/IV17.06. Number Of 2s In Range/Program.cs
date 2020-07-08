using System;

namespace IV17._06._Number_Of_2s_In_Range
{
    class Program
    {
        /*面试题 17.06. 2出现的次数
           编写一个方法，计算从 0 到 n (含 n) 中数字 2 出现的次数。
           示例:
           输入: 25
           输出: 9
           解释: (2, 12, 20, 21, 22, 23, 24, 25)(注意 22 应该算作两次)
           提示：
           n <= 10^9*/
        static void Main(string[] args)
        {
            Console.WriteLine(NumberOf2sInRange(25));
            Console.WriteLine(NumberOf2sInRange(25));
            Console.WriteLine(NumberOf2sInRange(25));

        }

        public static int NumberOf2sInRange(int n)
        {
            if (n == 0) return 0;

            int digit = (int) Math.Log10(n) + 1;//n的位数
            int[,] dp=new int[digit+1,2];
            //dp[i,0]=NumberOf2sInRange(n % Math.Pow(10,i)) 保存0~n的1-i位组成的数中 2 的个数
            //dp[i,1]=NumberOf2sInRange(99......9)保存i位均为9 如99999中 2 的个数
            dp[1, 0] = n % 10 >= 2 ? 1 : 0;
            dp[1, 1] = 1;
            for (int i = 2; i <= digit; i++)
            {
                int k = n / ((int) Math.Pow(10, i - 1)) % 10;
                dp[i, 0] = k * dp[i - 1, 1] + dp[i - 1, 0];
                if (k == 2)
                    dp[i, 0] += n % (int) Math.Pow(10, i - 1) + 1;
                else if (k > 2)
                    dp[i, 0] += (int) Math.Pow(10, i - 1);
                //计算i-1位均为9的值包含 2 的个数
                dp[i, 1] = 10 * dp[i - 1, 1] + (int) Math.Pow(10, i - 1);
            }

            return dp[digit, 0];
        }
    }
}
