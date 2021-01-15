using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Class;

namespace _15_947._Most_Stones_Removed_with_Same_Row_or_Column
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] s1 = {new[] {0, 0}, new[] {0, 1}, new[] {1, 0}, new[] {1, 2}, new[] {2, 1}, new[] {2, 2}};
            int[][] s2 = {new[] {0, 0}, new[] {0, 2}, new[] {1, 1}, new[] {2, 0}, new[] {2, 2}};
            Console.WriteLine(RemoveStones(s1));
            Console.WriteLine(RemoveStones(s2));
        }

        public static int RemoveStones(int[][] stones)
        {
            int n = stones.Length;
            if (n <= 1) 
            {
                return 0;
            }
            UnionFind0 ufs=new UnionFind0();
            foreach (var stone in stones)
            {
                ufs.Union(stone[0] + 10001, stone[1]);
            }

            return n - ufs.Count;


        }
    }
    public class UnionFind0
    {
        public int Count { get; private set; }//圈数量
        Dictionary<int, int> parent;
        public UnionFind0()
        {
            parent = new Dictionary<int, int>();
            Count = 0;
        }
        public int Find(int x)
        {
            if (!parent.ContainsKey(x)) { parent[x] = x; Count++; }//新值
            if (x != parent[x]) parent[x] = Find(parent[x]);
            return parent[x];
        }
        public void Union(int x, int y)//联合两个值
        {
            int rootX = Find(x);//找根索引
            int rootY = Find(y);//找根索引
            if (rootX == rootY) return;
            parent[rootX] = rootY;//直接x并入y?
            Count--;
        }
    }
}
