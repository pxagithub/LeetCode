using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Microsoft.VisualBasic.CompilerServices;

namespace _10__40._Combination_Sum_II
{
    class Program
    {
        static void Main(string[] args)
        {
            /*40. 组合总和 II
               给定一个数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。
               candidates 中的每个数字在每个组合中只能使用一次。
               说明：
               所有数字（包括目标数）都是正整数。
               解集不能包含重复的组合。 

               示例 1:
               输入: candidates = [10,1,2,7,6,1,5], target = 8,
               所求解集为:
               [
               [1, 7],
               [1, 2, 5],
               [2, 6],
               [1, 1, 6]
               ]

               示例 2:
               输入: candidates = [2,5,2,1,2], target = 5,
               所求解集为:
               [
               [1,2,2],
               [5]
               ]*/
            IList<IList<int>> x = CombinationSum2(new[] {10, 1, 2, 7, 6, 1, 5}, 8);
            IList<IList<int>> y = CombinationSum2(new[] {2, 5, 2, 1, 2}, 5);

            //List<int> a = new List<int>() {1, 1, 1};
            //List<int> b = new List<int>() {1, 1, 1};

            //IList<IList<int>> z=new List<IList<int>>();
            //z.Add(a);
            //Console.WriteLine(z.Any(b.SequenceEqual));


            Console.WriteLine();
        }

        public static IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            Array.Sort(candidates);
            HashSet<IList<int>> res = new HashSet<IList<int>>();
            Dfs(0, 0, target, candidates, new List<int>(), res);
            return res.ToList();
        }

        public static void Dfs(int start, int sum, int target,int[] candidates, List<int> path, HashSet<IList<int>> res)
        {
            if (sum == target) 
            {
                if (!res.Any(path.SequenceEqual))
                {
                    res.Add(new List<int>(path));
                }
                return;
            }

            if (sum>target)
            {
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                if (sum+candidates[i]>target)
                {
                    break;
                }

                if (sum<=target)
                {
                    int temp = sum;
                    temp += candidates[i];
                    path.Add(candidates[i]);
                    Dfs(i + 1, temp, target, candidates, path, res); 
                    path.RemoveAt(path.Count - 1);
                }
                
            }
        }
    }
}
