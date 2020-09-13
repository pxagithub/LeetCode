using System;
using System.Collections.Generic;
using System.Linq;

namespace _206_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] xPreferences =
            {
                new []{1,3,2},//0
                new []{2,3,0},//1
                new []{1,3,0},//2
                new []{0,2,1}//3
            };
            int[][] xPairs =
            {
                new[] {1,3},
                new[] {0,2}
            };

            Console.WriteLine(UnhappyFriends(4,xPreferences,xPairs));
        }

        public static int UnhappyFriends(int n, int[][] preferences, int[][] pairs)
        {
            int res = 0;
            Dictionary<int, int> pairsDictionary = new Dictionary<int, int>();

            for (int i = 0; i < pairs.Length; i++)
            {
                pairsDictionary.Add(pairs[i][0], pairs[i][1]);
                pairsDictionary.Add(pairs[i][1], pairs[i][0]);
            }

            for (int i = 0; i < n; i++)
            {
                int pairIndex_i = Array.IndexOf(preferences[i],pairsDictionary[i]);
                for (int j = 0; j < n; j++)
                {
                    if (i!=j)
                    {
                        int pairIndex_j = Array.IndexOf(preferences[j], pairsDictionary[j]);
                        int friendIndex_i = Array.IndexOf(preferences[j], i);
                        int friendIndex_j = Array.IndexOf(preferences[i], j);
                        if (friendIndex_j<pairIndex_i&&friendIndex_i<pairIndex_j)
                        {
                            res++;
                            break;
                        }
                    }
                }
            }

            return res;
        }
    }
}
