using System;
using System.Collections.Generic;
using System.Linq;

namespace _206_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] x =
            {
                new[] {0, 0},
                new[] {2, 2},
                new[] {3, 10},
                new[] {5, 2},
                new[] {7, 0}
            };
            int[][] y =
            {
                new[] {3, 12},
                new[] {-2, 5},
                new[] {-4, 1}
            };
            int[][] z =
            {
                new[] {0, 0},
                new[] {1, 1},
                new[] {1, 0},
                new[] {-1, 1}
            };
            int[][] a =
            {
                new[] {-1000000, -1000000},
                new[] {1000000, 1000000}
            };
            int[][] b =
            {
                new[] {0, 0}
            };

            Console.WriteLine(MinCostConnectPoints(x));//20
            Console.WriteLine(MinCostConnectPoints(y));//18
            Console.WriteLine(MinCostConnectPoints(z));//4
            Console.WriteLine(MinCostConnectPoints(a));//4000000
            Console.WriteLine(MinCostConnectPoints(b));//0
        }

        public static int MinCostConnectPoints(int[][] points)
        {
            if (points.Length == 1)
            {
                return 0;
            }


            int res = 0;

            List<int[]> linkedPoints = new List<int[]>();
            List<int[]> unLinkedPoints = points.ToList();

            while (unLinkedPoints.Count>0)
            {
                int[] point = new int[2];
                bool changed = false;
                foreach (var point1 in unLinkedPoints)
                {
                    int min = Int32.MaxValue;
                    linkedPoints.Add(point1);

                    foreach (var point2 in unLinkedPoints)
                    {
                        int distance = Math.Abs(point2[0] - point1[0]) + Math.Abs(point2[1] - point1[1]);
                        if (min > distance)
                        {
                            min = distance;
                            point = point2;
                            changed = true;
                        }
                    }
                    res += min;
                }
                if (changed)
                {
                    linkedPoints.Add(point);
                }
            }
        

            return res;
        }
    }
}
