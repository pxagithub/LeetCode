using System;
using System.Text;

namespace _13__43.Multiply_Strings
{
    class Program
    {
        /*43. 字符串相乘
           给定两个以字符串形式表示的非负整数 num1 和 num2，返回 num1 和 num2 的乘积，它们的乘积也表示为字符串形式。
           
           示例 1:
           
           输入: num1 = "2", num2 = "3"
           输出: "6"
           示例 2:
           
           输入: num1 = "123", num2 = "456"
           输出: "56088"
           说明：
           
           num1 和 num2 的长度小于110。
           num1 和 num2 只包含数字 0-9。
           num1 和 num2 均不以零开头，除非是数字 0 本身。
           不能使用任何标准库的大数类型（比如 BigInteger）或直接将输入转换为整数来处理。*/
        static void Main(string[] args)
        {

            string num1 = "123", num2 = "456";

        }

        public static string Multiply(string num1, string num2)
        {
            if (num1.Equals("0")||num2.Equals("0"))
            {
                return "0";
            }


            int m = num1.Length, n = num2.Length;

            int[] ansArray=new int[m+n];
            for (int i = m-1; i >= 0; i--)
            {
                int x = num1[i] - '0';
                for (int j = n-1; j >= 0; j--)
                {
                    int y = num2[j] - '0';
                    ansArray[i + j + 1] += x * y;
                }
            }

            for (int i = m+n-1; i > 0; i--)
            {
                ansArray[i - 1] += ansArray[i] / 10;
                ansArray[i] %= 10;
            }

            int index = ansArray[0] == 0 ? 1 : 0;
            StringBuilder ans = new StringBuilder();
            while (index<m+n)
            {
                ans.Append(ansArray[index]);
                index++;
            }

            return ans.ToString();
        }
    }
}
