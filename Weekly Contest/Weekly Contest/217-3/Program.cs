using System;
using System.Collections.Generic;

namespace _217_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = {2, 3, 3, 2};
            int[] y = {1, 2, 2, 1};
            int[] z = {1, 2, 1, 2};
            int[] temp =
            {
                2, 7, 11, 48, 29, 5, 12, 4, 27, 55, 57, 33, 45, 49, 33, 32, 26, 29, 39, 4, 13, 24, 48, 47, 3, 24, 56,
                57, 28, 50, 4, 8, 34, 46, 44, 47, 44, 27, 56, 30, 16, 20, 34, 35, 57, 57, 17, 9, 25, 16, 28, 44
            };
            //Console.WriteLine(MinMoves(temp,57));
            Console.WriteLine(MinMoves(x, 3));
            Console.WriteLine(MinMoves(y, 2));
            Console.WriteLine(MinMoves(z, 2));

        }

        public static int MinMoves(int[] nums, int limit)
        {
            int i = 0, j = nums.Length - 1;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            int res = int.MaxValue;
            while (i < j)
            {
                int sum = nums[i] + nums[j];
                if (dic.ContainsKey(sum))
                {
                    dic[sum]++;
                }
                else
                {
                    dic.Add(sum, 1);
                }

                i++;
                j--;
            }
            foreach (var d in dic)
            { 
                int temp = 0;
                foreach (var di in dic)
                {
                    if (di.Key != d.Key)
                    {
                        if (Math.Abs(di.Key - d.Key) < limit) temp += di.Value;
                        else
                        {
                            temp += di.Value * 2;
                        }
                    }
                }

                res = Math.Min(res, temp);
            }

            return res;


        }
    }
}
