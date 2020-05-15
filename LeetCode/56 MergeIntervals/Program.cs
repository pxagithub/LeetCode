using System;
using System.Collections.Generic;
using System.Linq;

namespace _56_MergeIntervals
{
    class Program
    {
        /*
         * 56. 合并区间
           给出一个区间的集合，请合并所有重叠的区间。
           
           示例 1:
           
           输入: [[1,3],[2,6],[8,10],[15,18]]
           输出: [[1,6],[8,10],[15,18]]
           解释: 区间 [1,3] 和 [2,6] 重叠, 将它们合并为 [1,6].
           示例 2:
           
           输入: [[1,4],[4,5]]
           输出: [[1,5]]
           解释: 区间 [1,4] 和 [4,5] 可被视为重叠区间。
         */
        static void Main(string[] args)
        {
            int[][] x = {new[] {1, 3}, new[] {2, 6}, new[] {8, 10}, new[] {15, 18}};
            int[][] y = {new[] {1, 4}, new[] {4, 5}};
            int[][] res1 = Merge1(x);
            int[][] res2 = Merge1(y);
            Console.ReadLine();

        }

        public static int[][] Merge(int[][] intervals)
        {
            //按照区间起始位置排序
            Array.Sort(intervals,(v1,v2)=>v1[0]-v2[0]);
            //遍历区间
            int[][] res=new int[intervals.Length][];
            int idx = -1;
            foreach (var interval in intervals)
            {
                //如果数组是空的，货当前区间的起始位置大于结果数组中最后区间的终止位置，则不合并，直接将当前区间加入数组
                if (idx==-1||interval[0]>res[idx][1])
                {
                    res[++idx] = interval;
                }
                else
                {
                    //反之将当前区间合并至结果数组的最后区间
                    res[idx][1] = Math.Max(res[idx][1], interval[1]);
                }
            }
            int[][] res1=new int[idx+1][];
            Array.ConstrainedCopy(res,0,res1,0,idx+1);
            
            return res1;
        }

        //C#用时最短答案
        public static int[][] Merge1(int[][] intervals)
        {
            //输入: [[1,3],[2,6],[8,10],[15,18]]
            //输入: [[1,4],[4,5]]
            if (intervals.Length < 2) return intervals;

            intervals = intervals.OrderBy(x => x[0]).ToArray();
            var res = new List<int[]>();
            var cur = intervals[0];
            foreach (var next in intervals)
            {
                if (cur[1] >= next[0])
                    cur[1] = Math.Max(cur[1], next[1]);
                else
                {
                    res.Add(cur);
                    cur = next;
                }
            }
            res.Add(cur);
            return res.ToArray();
        }
    }
}
