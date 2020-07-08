using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace IV16._11.Diving_Board
{
    class Program
    {
        /*面试题 16.11. 跳水板
           你正在使用一堆木板建造跳水板。有两种类型的木板，其中长度较短的木板长度为shorter，长度较长的木板长度为longer。你必须正好使用k块木板。编写一个方法，生成跳水板所有可能的长度。
           返回的长度需要从小到大排列。
           示例：
           输入：
           shorter = 1
           longer = 2
           k = 3
           输出： {3,4,5,6}
           提示：
           0 < shorter <= longer
           0 <= k <= 100000*/
        static void Main(string[] args)
        {
            int[] x = DivingBoard(1, 2, 3);//3,4,5,6
            int[] y = DivingBoard(1, 1, 10000);//10000
            for (int i = 0; i < x.Length; i++)
            {
                Console.WriteLine(x[i]);
            }

            for (int i = 0; i < y.Length; i++)
            {
                Console.WriteLine(y[i]);
            }
        }
        public static int[] DivingBoard(int shorter, int longer, int k)
        {
            List<int> res = new List<int>();
            if (k == 0) return res.ToArray();
            if (shorter ==longer) return new int[]{shorter*k};
            for (int i = 0; i <= k; i++)
            {
                res.Add(longer*i+shorter*(k-i));
            }

            return res.ToArray();
        }
    }
}
