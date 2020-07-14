using System;
using System.Collections.Generic;
using System.Linq;

namespace _120._Triangle
{
    /*120. 三角形最小路径和
       给定一个三角形，找出自顶向下的最小路径和。每一步只能移动到下一行中相邻的结点上。
       相邻的结点 在这里指的是 下标 与 上一层结点下标 相同或者等于 上一层结点下标 + 1 的两个结点。
       例如，给定三角形：
       [
               [2],
              [3,4],
             [6,5,7],
            [4,1,8,3]
       ]
       自顶向下的最小路径和为 11（即，2 + 3 + 5 + 1 = 11）。
       说明：
       如果你可以只使用 O(n) 的额外空间（n 为三角形的总行数）来解决这个问题，那么你的算法会很加分。*/
    class Program
    {
        static void Main(string[] args)
        {
            List<IList<int>> x=new List<IList<int>>()
            {
                new List<int>(){2},
                new List<int>(){3,4},
                new List<int>(){6,5,7},
                new List<int>(){4,1,8,3}
            };
            Console.WriteLine(MinimumTotal(x));//11
        }
        public static int MinimumTotal(IList<IList<int>> triangle)
        {
            int row = triangle.Count;
            int column = triangle[row - 1].Count;
            int[] dp = new int[column];
            

            dp[0] = triangle[0][0];
            for (int i = 1; i < row; i++)
            {
                for (int j = triangle[i].Count-1; j >=0; j--)
                {
                    if (j==0)
                    {
                        dp[j] += triangle[i][j];
                    }
                    else if (j==triangle[i].Count-1)
                    {
                        dp[j] = dp[j - 1] + triangle[i][j];
                    }
                    else
                    {
                        dp[j] = Math.Min(dp[j - 1], dp[j]) + triangle[i][j];
                    }
                }
            }

            return dp.Min();
        }
    }
}
