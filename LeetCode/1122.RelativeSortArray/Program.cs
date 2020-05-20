using System;
using System.Collections.Generic;
using System.Linq;

namespace _1122.RelativeSortArray
{
    class Program
    {
        /*
         * 1122. 数组的相对排序
           给你两个数组，arr1 和 arr2，
           
           arr2 中的元素各不相同
           arr2 中的每个元素都出现在 arr1 中
           对 arr1 中的元素进行排序，使 arr1 中项的相对顺序和 arr2 中的相对顺序相同。未在 arr2 中出现过的元素需要按照升序放在 arr1 的末尾。
        
           示例：
           
           输入：arr1 = [2,3,1,3,2,4,6,7,9,2,19], arr2 = [2,1,4,3,9,6]
           输出：[2,2,2,1,4,3,3,9,6,7,19]           
           
           提示：
           
           arr1.length, arr2.length <= 1000
           0 <= arr1[i], arr2[i] <= 1000
           arr2 中的元素 arr2[i] 各不相同
           arr2 中的每个元素 arr2[i] 都出现在 arr1 中
         */
        static void Main(string[] args)
        {
            int[] arr1 = {2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19};
            int[] arr2 = {2, 1, 4, 3, 9, 6};

            int[] res = RelativeSortArray(arr1, arr2);
            Console.WriteLine();
        }
        private static Dictionary<int,int> pvPair=new Dictionary<int, int>();
        public static int[] RelativeSortArray(int[] arr1, int[] arr2)
        {
            for (int i = 0; i < arr2.Length; i++)
            {
                pvPair.Add(arr2[i],i);
            }
            List<int> res1=new List<int>();
            List<int> res2=new List<int>();
            for (int i = 0; i < arr1.Length; i++)
            {
                if (pvPair.ContainsKey(arr1[i]))
                    res1.Add(arr1[i]);
                else 
                    res2.Add(arr1[i]);
            }
            res1.Sort((v1,v2)=>(pvPair[v1].CompareTo(pvPair[v2])));
            res2.Sort();
            return res1.Concat(res2).ToArray();
        }

        
    }
}
