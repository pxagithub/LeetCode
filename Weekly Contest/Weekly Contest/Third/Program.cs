using System;
using System.Collections.Generic;

namespace Third
{
    class Program
    {
        /**/
        static void Main(string[] args)
        {
            int[][] grid1 = { new[] { 0, 0, 1 }, new[] { 1, 1, 0 }, new[] { 1, 0, 0 } };
            Console.WriteLine(MinSwaps(grid1));//3
        }
        public static int MinSwaps(int[][] grid)
        {
            int n = grid.Length;
            List<int> a=new List<int>();

            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = n-1; j >= 0; j--)
                {
                    if (grid[i][j] == 0) count++; //数每一行的后缀0
                    else break;
                }
                a.Add(count);
            }

            int count1 = 0;//交换次数
            for (int i = 0; i < n - 1; i++)
            {
                if (a[i] >= n - i - 1) continue;//满足条件，该行直接跳过
                else
                {//不满足条件
                    int j = i; //用新参数遍历找满足条件的后缀0
                    for (; j < n; j++)
                    {
                        if (a[j] >= n - i - 1) break;
                    }
                    if (j == n) return -1; //找不到，直接返回-1
                    for (; j > i; j--) //找到了最先满足条件的后缀0个数 
                    {
                        //每一行交换上去
                        int temp = a[j];
                        a[j] = a[j - 1];
                        a[j - 1] = temp;

                        count1++; //记录交换次数
                    }
                }
            }
            return count1;

        }
    }
}
