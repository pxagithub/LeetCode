using System;
using System.Linq;
using System.Runtime.Versioning;

namespace _24__135.Candy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Candy(new[] {1, 0, 2}));//5
            Console.WriteLine(Candy(new[] {1, 2, 2}));//4
            Console.WriteLine(Candy(new[] {1, 2, 87, 87, 87, 2, 1}));//13
            Console.WriteLine(Candy(new[] {1, 2, 3, 3, 2, 4, 5, 6, 1, 2, 0}));//22
        }
        public static int Candy(int[] ratings)
        {
            int n = ratings.Length;
            int[] res = new int[n];
            for (int i = 1; i < n; i++)
            {
                int pre = i - 1;
                if (ratings[i] > ratings[pre])
                {
                    res[i] = Math.Max(res[i], res[pre] + 1);
                }
            }

            for (int i = n-2; i >= 0; i--)
            {
                int next = i + 1;
                if (ratings[i]>ratings[next])
                {
                    res[i] = Math.Max(res[i], res[next] + 1);
                }
            }
            
            return res.Sum()+n;


        }
    }
}
