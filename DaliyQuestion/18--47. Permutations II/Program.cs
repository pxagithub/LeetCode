using System;
using System.Collections.Generic;
using System.Linq;

namespace _18__47._Permutations_II
{
    class Program
    {
        static void Main(string[] args)
        {
            /*47. 全排列 II
               给定一个可包含重复数字的序列，返回所有不重复的全排列。
               
               示例:
               输入: [1,1,2]
               输出:
               [
               [1,1,2],
               [1,2,1],
               [2,1,1]
               ]*/
            foreach (var permute in PermuteUnique(new []{2,2,1,1}))
            {
                Console.WriteLine(string.Join(",", permute));

            }
        }

        public static IList<IList<int>> PermuteUnique(int[] nums)
        {
            IList<IList<int>> res = new List<IList<int>>();

            if (nums.Length==0)
            {
                return res;
            }

            Array.Sort(nums);

            bool[] used = new bool[nums.Length];
            Stack<int> path = new Stack<int>();

            Backtracking(nums, nums.Length, 0, used, path, res);

            return res;
        }

        public static void Backtracking(int[] nums, int n, int depth, bool[] used, Stack<int> path, IList<IList<int>> res)
        {
            if (depth==n)
            {
                res.Add(new List<int>(path));
                return;
            }

            for (int i = 0; i < n; i++)
            {
                if (used[i])
                {
                    continue;
                }

                //剪枝条件：i>0是为了保证nums[i-1]有意义
                //写!used[i-1]是为了nums[i-1]在深度优先遍历的过程中刚刚被撤销选择
                if (i>0&&nums[i]==nums[i-1]&&!used[i-1])
                {
                    continue;
                }

                path.Push(nums[i]);
                used[i] = true;

                Backtracking(nums, n, depth + 1, used, path, res);

                //回溯部分的代码，和之前对称

                used[i] = false;
                path.Pop();
            }
        }
    }
}
