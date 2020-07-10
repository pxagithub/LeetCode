using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DataStructLibrary;



namespace _834.Sum_of_distances_in_tree
{
    class Program
    {
        /*
         *834. 树中距离之和
           给定一个无向、连通的树。树中有 N 个标记为 0...N-1 的节点以及 N-1 条边 。
           
           第 i 条边连接节点 edges[i][0] 和 edges[i][1] 。
           
           返回一个表示节点 i 与其他所有节点距离之和的列表 ans。
           
           示例 1:
           
           输入: N = 6, edges = [[0,1],[0,2],[2,3],[2,4],[2,5]]
           输出: [8,12,6,10,10,10]
           解释: 
           如下为给定的树的示意图：
            0
           / \
          1   2
             /|\
            3 4 5
           
           我们可以计算出 dist(0,1) + dist(0,2) + dist(0,3) + dist(0,4) + dist(0,5) 
           也就是 1 + 1 + 2 + 2 + 2 = 8。 因此，answer[0] = 8，以此类推。
           说明: 1 <= N <= 10000
         */
        static void Main(string[] args)
        {
            int[][] edges = {new[] {0, 1}, new[] {0, 2}, new[] {2, 3}, new[] {2, 4}, new[] {2, 5}};
            int N = 6;
            int[] res = SumOfDistancesInTree(N, edges);
            Console.WriteLine();

        }
        public static int[] ans, count;
        public static int n;
        public static List<ISet<int>> graph;
        public static int[] SumOfDistancesInTree(int N, int[][] edges)
        {
            n = N;
            graph =new List<ISet<int>>();
            ans=new int[N];
            count=new int[N];
            Array.Fill(count,1);

            for (int i = 0; i < N; i++)
            {
                graph.Add(new HashSet<int>());
            }

            foreach (var edge in edges)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            dfs1(0, -1);
            dfs2(0, -1);
            return ans;

        }

        public static void dfs1(int node, int parent)
        {
            foreach (var child in graph[node])
            {
                if (child!=parent)
                {
                    dfs1(child,node);
                    count[node] += count[child];
                    ans[node] += ans[child] + count[child];
                }
            }
        }

        public static void dfs2(int node, int parent)
        {
            foreach (var child in graph[node])
            {
                if (child!=parent)
                {
                    ans[child] = ans[node] - count[child] + n - count[child];
                    dfs2(child,node);
                }
            }
        }
    }
}
