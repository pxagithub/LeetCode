using System;
using System.Collections.Generic;

namespace _09_39.Combination_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            /*39. 组合总和
               给定一个无重复元素的数组 candidates 和一个目标数 target ，找出 candidates 中所有可以使数字和为 target 的组合。
               candidates 中的数字可以无限制重复被选取。

               说明：
               所有数字（包括 target）都是正整数。
               解集不能包含重复的组合。 

               示例 1：
               输入：candidates = [2,3,6,7], target = 7,
               所求解集为：
               [
               [7],
               [2,2,3]
               ]

               示例 2：
               输入：candidates = [2,3,5], target = 8,
               所求解集为：
               [
               [2,2,2,2],
               [2,3,3],
               [3,5]
               ]
               
               提示：
               1 <= candidates.length <= 30
               1 <= candidates[i] <= 200
               candidate 中的每个元素都是独一无二的。
               1 <= target <= 500*/
            IList<IList<int>> x = CombinationSum(new[] {2, 3, 6, 7}, 7);
            IList<IList<int>> y = CombinationSum(new[] {2, 3, 5}, 8);
            Console.WriteLine();

        }
        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            int len = candidates.Length;
            var res=new List<IList<int>>();
            if (len==0)
            {
                return res;
            }

            //排序是剪枝的前提
            Array.Sort(candidates);
            Dfs(0, len, candidates, target, new List<int>(), res);
            return res;
        }

        static void Dfs(int start, int len, int[] candidates, int target, List<int> path, IList<IList<int>> res)
        {
            //由于进入更深层的时候，小于0的部分被剪枝，因此递归终止条件只判断等于0的情况
            if (target==0)
            {
                res.Add(new List<int>(path));
                return;
            }

            for (int i = start; i < len; i++)
            {
                //重点理解这里剪枝，前提是候选数组已经有序，
                if (target-candidates[i]<0)
                {
                    break;
                }

                path.Add(candidates[i]);
                Dfs(i, len, candidates, target - candidates[i], path, res);
                path.RemoveAt(path.Count-1);
            }
            
        }
    }
}
