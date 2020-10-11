using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _210_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] x =
            {
                new[] {0, 1},
                new[] {0, 3},
                new[] {1, 2},
                new[] {1, 3}
            };
            Console.WriteLine(MaximalNetworkRank(4,x));
        }

        public static int MaximalNetworkRank(int n, int[][] roads)
        {
            Dictionary<int, List<int>> dic = new Dictionary<int, List<int>>();
            int max = 0;
            foreach (var point in roads)
            {
                if (!dic.ContainsKey(point[0]))
                {
                    dic.Add(point[0],new List<int>());
                    dic[point[0]].Add(point[1]);
                }
                else
                {
                    dic[point[0]].Add(point[1]);
                }
                if (!dic.ContainsKey(point[1]))
                {
                    dic.Add(point[1], new List<int>(point[0]));
                    dic[point[1]].Add(point[0]);
                }
                else
                {
                    dic[point[1]].Add(point[0]);
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (dic.ContainsKey(i))
                {
                    for (int j = i+1; j < n; j++)
                    {
                        if (dic.ContainsKey(j))
                        {
                            int temp = dic[i].Count + dic[j].Count;
                            if (dic[i].Contains(j))
                            {
                                temp--;
                            }

                            max = max > temp ? max : temp;
                        }
                
                    }
                }
            }

            return max;

        }



        
    }
}
