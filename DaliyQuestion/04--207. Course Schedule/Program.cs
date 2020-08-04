using System;
using System.Collections.Generic;

namespace _04__207._Course_Schedule
{
    class Program
    {
        /*207. 课程表
           你这个学期必须选修 numCourse 门课程，记为 0 到 numCourse-1 。
           在选修某些课程之前需要一些先修课程。 例如，想要学习课程 0 ，你需要先完成课程 1 ，我们用一个匹配来表示他们：[0,1]
           给定课程总量以及它们的先决条件，请你判断是否可能完成所有课程的学习？
           
           示例 1:
           输入: 2, [[1,0]] 
           输出: true
           解释: 总共有 2 门课程。学习课程 1 之前，你需要完成课程 0。所以这是可能的。

           示例 2:
           输入: 2, [[1,0],[0,1]]
           输出: false
           解释: 总共有 2 门课程。学习课程 1 之前，你需要先完成​课程 0；并且学习课程 0 之前，你还应先完成课程 1。这是不可能的。*/
        static void Main(string[] args)
        {
            int[][] x = {new[] {1, 0}, new[] {0, 2}};
            int[][] y = {new[] {0, 1}, new[] {1, 0}};
            int[][] z = {new[] {1, 0}, new[] {0, 2}, new[] {2, 1}};
            Console.WriteLine(CanFinish(2,x));
            Console.WriteLine(CanFinish(2,y));

        }

        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            List<List<int>> adjacency=new List<List<int>>();

            for (int i = 0; i < numCourses; i++)
            {
                adjacency.Add(new List<int>());
            }

            int[] flags=new int[numCourses];

            foreach (var cp in prerequisites)
            {
                adjacency[cp[1]].Add(cp[0]);
            }

            for (int i = 0; i < numCourses; i++)
            {
                if (!Dfs(adjacency,flags,i))
                {
                    return false;
                }
            }

            return true;

        }

        public static bool Dfs(List<List<int>> adjacency, int[] flags, int i)
        {
            if (flags[i]==1)
            {
                return false;
            }

            if (flags[i]==-1)
            {
                return true;
            }

            flags[i] = 1;

            foreach (var j in adjacency[i])
            {
                if (!Dfs(adjacency,flags,j))
                {
                    return false;
                }

                
            }
            flags[i] = -1;

            return true;
        }
    }
}
