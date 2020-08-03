using System;
using System.Linq;
using System.Net.Http.Headers;

namespace _415._Add_Strings
{
    class Program
    {
        /*415. 字符串相加
           给定两个字符串形式的非负整数 num1 和num2 ，计算它们的和。
           
           注意：
           
           num1 和num2 的长度都小于 5100.
           num1 和num2 都只包含数字 0-9.
           num1 和num2 都不包含任何前导零。
           你不能使用任何內建 BigInteger 库， 也不能直接将输入的字符串转换为整数形式。*/
        static void Main(string[] args)
        {
            string x = "666";
            string y = "666";
            Console.WriteLine(AddStrings(x,y));
        }
        public static string AddStrings(string num1, string num2)
        {
            string res = "";
            int i = num1.Length - 1, j = num2.Length - 1, carry = 0;
            while (i>=0||j>=0)
            {
                int n1 = i >= 0 ? num1[i] - '0' : 0;
                int n2 = j >= 0 ? num2[j] - '0' : 0;
                int tmp = n1 + n2 + carry;
                carry = tmp / 10;
                res += (tmp % 10).ToString();
                i--;
                j--;
            }

            if (carry==1)
            {
                res += "1";
            }

            

            return string.Join("", res.Reverse());
        }
    }
}
