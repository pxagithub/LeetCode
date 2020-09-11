using System;
using System.Collections.Generic;

namespace _11__216.Combination_Sum_III
{
    class Program
    {
        static void Main(string[] args)
        {
            /*216. 组合总和 III
               找出所有相加之和为 n 的 k 个数的组合。组合中只允许含有 1 - 9 的正整数，并且每种组合中不存在重复的数字。
               
               说明：
               所有数字都是正整数。
               解集不能包含重复的组合。 

               示例 1:
               输入: k = 3, n = 7
               输出: [[1,2,4]]

               示例 2:
               输入: k = 3, n = 9
               输出: [[1,2,6], [1,3,5], [2,3,4]]*/
            IList<IList<int>> x = CombinationSum3(3, 7);
            IList<IList<int>> y = CombinationSum3(3, 9);
            Console.WriteLine();
        }

        public static IList<IList<int>> CombinationSum3(int k, int n)
        {
            IList<IList<int>> res = new List<IList<int>>();
            Dfs(1, 0, k, n, new List<int>(), res);
            return res;
        }

        public static void Dfs(int start, int sum, int k,  int target, List<int> path, IList<IList<int>> res)
        {
            if (sum==target&&k==0)
            {
                res.Add(new List<int>(path));
                return;
            }

            if (sum>target||k<0)
            {
                return;
            }

            
            for (int i = start; i <= 9; i++)
            {
                if (sum+i>target)
                {
                    break;
                }
                else
                {
                    int temp = sum + i;
                    path.Add(i);
                    Dfs(i + 1, temp, k - 1, target, path, res);
                    path.RemoveAt(path.Count-1);
                }
            }
            
        }
    }
}
