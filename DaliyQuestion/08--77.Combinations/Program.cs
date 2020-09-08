using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace _08__77.Combinations
{
    class Program
    {
        static void Main(string[] args)
        {
            /*77. 组合
               给定两个整数 n 和 k，返回 1 ... n 中所有可能的 k 个数的组合。
               
               示例:
               输入: n = 4, k = 2
               输出:
               [
               [2,4],
               [3,4],
               [2,3],
               [1,2],
               [1,3],
               [1,4],
               ]*/
            IList<IList<int>> a = Combine(4, 2);
            IList<IList<int>> b = Combine(6, 4);

            Console.WriteLine();


        }

        public static IList<IList<int>> Combine(int n, int k)
        {
            var res = new List<IList<int>>();
            Recruion(1, n, k, new int[k], res);
            return res;

        }

        static void Recruion(int start, int n, int k, int[] item, IList<IList<int>> res)
        {
            if (k == 0)
            {
                res.Add(item.ToList());
                return;
            }
            for (var i = start; i <= n - k + 1; i++)
            {
                item[item.Length - k] = i;
                Recruion(i + 1, n, k - 1, item, res);
            }
        }

    }
}
