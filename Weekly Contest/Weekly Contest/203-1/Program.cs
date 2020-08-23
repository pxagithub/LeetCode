using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _203_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = {1, 3, 1, 2};
            int a = 4;

            int[] y = {2, 1, 2, 1, 2, 1, 2, 1, 2};
            int b = 2;

            int[] z = {1, 3, 5, 7};
            int c = 7;


            Console.WriteLine(string.Join(",", MostVisited(a, x)));//[1,2]
            Console.WriteLine(string.Join(",", MostVisited(b, y)));//[2]
            Console.WriteLine(string.Join(",", MostVisited(c, z)));//[1,2,3,4,5,6,7]

        }

        public static IList<int> MostVisited(int n, int[] rounds)
        {
            int[] visited = new int[n+1];

            for (int i = 0; i < rounds.Length-1; i++)
            {
                int step1 = rounds[i], step2 = rounds[i + 1];
                while (step2!=step1)
                {
                    visited[step1]++;
                    step1 = step1 > n - 1 ? 1 : step1 + 1;
                }
            }

            visited[rounds[^1]]++;

            int max = visited.Max();

            List<int> res = new List<int>();

            for (int i = 1; i < visited.Length; i++)
            {
                if (visited[i] == max) 
                {
                    res.Add(i);
                }
            }

            return res;
        }
    }
}
