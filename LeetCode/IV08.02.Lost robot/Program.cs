using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace IV08._02.Lost_robot
{
    class Program
    {
        /*面试题 08.02. 迷路的机器人
           设想有个机器人坐在一个网格的左上角，网格 r 行 c 列。机器人只能向下或向右移动，但不能走到一些被禁止的网格（有障碍物）。设计一种算法，寻找机器人从左上角移动到右下角的路径。网格中的障碍物和空位置分别用 1 和 0 来表示。
           返回一条可行的路径，路径由经过的网格的行号和列号组成。左上角为 0 行 0 列。如果没有可行的路径，返回空数组。
           示例 1:
           输入:
           [
           [0,0,0],
           [0,1,0],
           [0,0,0]
           ]
           输出: [[0,0],[0,1],[0,2],[1,2],[2,2]]
           解释: 
           输入中标粗的位置即为输出表示的路径，即
           0行0列（左上角） -> 0行1列 -> 0行2列 -> 1行2列 -> 2行2列（右下角）
           说明：r 和 c 的值均不超过 100。*/
        static void Main(string[] args)
        {
            int[][] x = new[]
            {
                new[] {0, 0, 0},
                new[] {0, 1, 0},
                new[] {0, 0, 0}
            };
            foreach (var point in PathWithObstacles(x))
            {
                Console.Write("[");
                foreach (var i in point)
                {
                    Console.Write($"{i},");
                }
                Console.WriteLine("]");
            }
        }
        public static IList<IList<int>> PathWithObstacles(int[][] obstacleGrid)
        {
            IList<IList<int>> res = new List<IList<int>>();
            if (obstacleGrid.Length == 0) return res;
            if (obstacleGrid[0][0] == 1 || obstacleGrid[^1][^1] == 1) return res;
            int[,] dp=new int[obstacleGrid.Length,obstacleGrid[0].Length];
            dp[0, 0] = obstacleGrid[0][0];
            for (int i = 1; i < obstacleGrid.Length; i++)
            {
                dp[i, 0] = obstacleGrid[i][0] + dp[i - 1,0];
            }
            for(int j = 1; j < obstacleGrid[0].Length; j++)
            {
                dp[0, j] = obstacleGrid[0][j] + dp[0, j - 1];
            }
            for (int i = 1; i < obstacleGrid.Length; i++)
            {
                for (int j = 1; j < obstacleGrid[0].Length; j++)
                {
                    dp[i, j] = Math.Min(dp[i, j - 1], dp[i - 1, j]) + obstacleGrid[i][j];
                }
            }

            if (dp[obstacleGrid.Length-1, obstacleGrid[0].Length-1]==0)
            {
                int i = obstacleGrid.Length-1;
                int j = obstacleGrid[0].Length - 1;
                res.Add(new List<int>(){i,j});
                while (true)
                {
                    if(i<=0||j<=0)
                        break;
                    if (dp[i-1,j]==0)
                    {
                        i--;
                        res.Add(new List<int>(){i,j});
                        continue;
                    }
                    else
                    {
                        j--;
                        res.Add(new List<int>(){i,j});
                        continue;
                    }
                }

                if (i>0)
                {
                    for (; i > 0; i--)
                    {
                        res.Add(new List<int>() { i-1, 0 });
                    } 
                }
                if(j>0)
                    for(;j>0;j--)
                        res.Add(new List<int>() { 0, j-1 });
            }
            return res.Reverse().ToList();
        }
    }
}
