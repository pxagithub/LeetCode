using System;
using System.Collections.Generic;
using System.Linq;

namespace _17__685._Redundant_Connection_II
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] x =
            {
                new[] {1, 2},
                new[] {1, 3},
                new[] {2, 3}
            };
            int[][] y =
            {
                new[] {1, 2},
                new[] {2, 3},
                new[] {3, 4},
                new[] {4, 1},
                new[] {1, 5}
            };
            Console.WriteLine(string.Join(",", FindRedundantDirectedConnection(x)));
            Console.WriteLine(string.Join(",", FindRedundantDirectedConnection(y)));
        }

        public static int[] FindRedundantDirectedConnection(int[][] edges)
        {
            int nodesCount = edges.Length;

            UnionFind uf = new UnionFind(nodesCount + 1);

            int[] parent = new int[nodesCount + 1];
            for (int i = 1; i <= nodesCount; i++)
            {
                parent[i] = i;
            }

            int conflict = -1;
            int cycle = -1;
            for (int i = 0; i < nodesCount; i++)
            {
                int[] edge = edges[i];
                int node1 = edge[0], node2 = edge[1];
                if (parent[node2]!=node2)
                {
                    conflict = i;
                }
                else
                {
                    parent[node2] = node1;
                    if (uf.Find(node1)==uf.Find(node2))
                    {
                        cycle = i;
                    }
                    else
                    {
                        uf.Union(node1, node2);
                    }
                }
            }

            if (conflict<0)
            {
                return new[] { edges[cycle][0], edges[cycle][1]};
            }
            else
            {
                int[] conflictEdge = edges[conflict];
                if (cycle>=0)
                {
                    return new[] { parent[conflictEdge[1]],conflictEdge[1] };
                }
                else
                {
                    return new[] {conflictEdge[0], conflictEdge[1]};
                }
            }
        }

        
    }

    class UnionFind
    {
        int[] ancestor;

        public UnionFind(int n)
        {
            ancestor = new int[n];
            for (int i = 0; i < n; i++)
            {
                ancestor[i] = i;
            }
        }

        public void Union(int index1, int index2)
        {
            ancestor[Find(index1)] = Find(index2);
        }

        public int Find(int index)
        {
            if (ancestor[index]!=index)
            {
                ancestor[index] = Find(ancestor[index]);
            }

            return ancestor[index];
        }
    }
        
    
}
