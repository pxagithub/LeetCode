using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices.ComTypes;

namespace IV01._05_One_time_edit
{
    class Program
    {
        /*面试题 01.05. 一次编辑
           字符串有三种编辑操作:插入一个字符、删除一个字符或者替换一个字符。 给定两个字符串，编写一个函数判定它们是否只需要一次(或者零次)编辑。

           示例 1:
           输入: 
           first = "pale"
           second = "ple"
           输出: True

           示例 2:
           输入: 
           first = "pales"
           second = "pal"
           输出: False*/
        static void Main(string[] args)
        {
            string xFirst = "pale";
            string xSecond = "ple";
            string yFirst = "pales";
            string ySecond = "pal";
            Console.WriteLine(OneEditWay(xFirst,xSecond));//True
            Console.WriteLine(OneEditWay(yFirst,ySecond));//False
        }

        static bool OneEditWay(string first, string second)
        {
            int firstLen = first.Length;
            int secondLen = second.Length;
            if (Math.Abs(firstLen - secondLen) > 1) return false;
            if (string.IsNullOrEmpty(first) && string.IsNullOrEmpty(second)) return true;
            int[,] dp=new int[firstLen+1,secondLen+1];
            for (int i = 0; i < firstLen; i++)
            {
                dp[i, 0] = i;
            }

            for (int i = 0; i < secondLen; i++)
            {
                dp[0, i] = i;
            }

            for (int i = 0; i < firstLen; i++)
            {
                for (int j = 0; j < secondLen; j++)
                {
                    if (first[i] == second[j]) dp[i + 1, j + 1] = dp[i, j];
                    else
                    {
                        dp[i+1,j+1] = Math.Min(Math.Min(dp[i, j + 1] + 1, dp[i + 1, j] + 1), dp[i, j]+1);
                    }
                }
                
            }

            if (dp[firstLen, secondLen] <= 1) return true;
            return false;
        }
    }
}
