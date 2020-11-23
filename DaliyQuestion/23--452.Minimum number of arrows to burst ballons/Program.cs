using System;

namespace _23__452.Minimum_number_of_arrows_to_burst_ballons
{
    class Program
    {
        static void Main()
        {
            int[][] x = {new[] {10, 16}, new[] {2, 8}, new[] {1, 6}, new[] {7, 12}};
            int[][] y = {new[] {-2147483646, -2147483645 }, new[] { 2147483646, 2147483647 } };
            int[][] z =
            {
                new[] {9, 12}, new[] {1, 10}, new[] {4, 11}, new[] {8, 12}, new[] {3, 9}, new[] {6, 9}, new[] {6, 7}
            };
            Console.WriteLine(FindMinArrowShots(z));
            Console.WriteLine(FindMinArrowShots(y));
            Console.WriteLine(FindMinArrowShots(x));
        }

        public static int FindMinArrowShots(int[][] points)
        {
            int res = points.Length;
            Array.Sort(points, (p1, p2) => {
                return p1[0] <= p2[0] ? -1 : 1;
            });
            for (int i = 0; i < points.Length; i++)
            {
                int left = points[i][0], right = points[i][1];
                int count = 0;
                
                for (int k = i + 1; k < points.Length; k++)
                {
                    if (points[k][0] <= right)
                    {
                        count++;
                        left = points[k][0];
                        right = right < points[k][1] ? right : points[k][1];
                    }
                    else
                    {
                        break;
                    }
                }
                i += count;
                res -= count;
            }
            return res;
        }
    }
}
