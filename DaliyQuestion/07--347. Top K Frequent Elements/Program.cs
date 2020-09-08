using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using DataStructLibrary;

namespace _07__347._Top_K_Frequent_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            /*347. 前 K 个高频元素
               给定一个非空的整数数组，返回其中出现频率前 k 高的元素。
               
               示例 1:
               输入: nums = [1,1,1,2,2,3], k = 2
               输出: [1,2]

               示例 2:
               输入: nums = [1], k = 1
               输出: [1]*/

            int[] x = {4,1,-1,2,-1,2,3};
            int[] y = {3, 0, 1, 0};
            int[] z = {5, -3, 9, 1, 7, 7, 9, 10, 2, 2, 10, 10, 3, -1, 3, 7, -9, -1, 3, 3};

            Console.WriteLine(string.Join(",", TopKFrequent(x, 2)));
            Console.WriteLine(string.Join(",", TopKFrequent(y, 1)));
            Console.WriteLine(string.Join(",", TopKFrequent(z, 3)));
            Console.WriteLine(string.Join(",", TopKFrequent(new []{6, 0, 1, 4, 9, 7, -3, 1, -4, -8, 4, -7, -3, 3, 2, -3, 9, 5, -4, 0}, 6)));
            
        }

        public static int[] TopKFrequent(int[] nums, int k)
        {
            int[] res = new int[k];
            Dictionary<int, int> dic = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dic.ContainsKey(nums[i])) dic[nums[i]]++;
                else dic[nums[i]] = 1;
            }
            List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>(dic);
            list.Sort((x, y) => { return -x.Value + y.Value; });
            for (int i = 0; i < k; i++)
            {
                res[i] = list[i].Key;
            }
            return res;
        }

        
    }
}
