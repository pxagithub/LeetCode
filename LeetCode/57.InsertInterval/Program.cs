using System;
using System.Collections.Generic;

namespace _57.InsertInterval
{
    class Program
    {
        /*
         * 57. 插入区间
           给出一个无重叠的 ，按照区间起始端点排序的区间列表。
           
           在列表中插入一个新的区间，你需要确保列表中的区间仍然有序且不重叠（如果有必要的话，可以合并区间）。
           
           示例 1:
           
           输入: intervals = [[1,3],[6,9]], newInterval = [2,5]
           输出: [[1,5],[6,9]]
           示例 2:
           
           输入: intervals = [[1,2],[3,5],[6,7],[8,10],[12,16]], newInterval = [4,8]
           输出: [[1,2],[3,10],[12,16]]
           解释: 这是因为新的区间 [4,8] 与 [3,5],[6,7],[8,10] 重叠
         */
        static void Main(string[] args)
        {
            int[][] x = {new[] {1, 3}, new[] {6, 9}};
            int[][] y = {new[] {1, 2}, new[] {3, 5}, new[] {6, 7}, new[] {8, 10}, new[] {12, 16}};

            int[] newX = {2, 5};
            int[] newY = {4, 8};

            int[][] res1 = Insert(x, newX);
            int[][] res2 = Insert(y, newY);
            Console.WriteLine();
        }

        public static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> ans=new List<int[]>();
            bool flag = false;

            for (int i = 0; i < intervals.Length; i++)
            {
                if (newInterval[0]>intervals[i][1])
                {
                    ans.Add(intervals[i]);
                    continue;
                }

                if (newInterval[1]<intervals[i][0])
                {
                    ans.Add(newInterval);
                    flag = !flag;
                    for (; i < intervals.Length; i++)
                    {
                        ans.Add(intervals[i]);
                    }
                    break;
                }

                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
            }
            if(!flag)
                ans.Add(newInterval);
            return ans.ToArray();
        }
    }
}
