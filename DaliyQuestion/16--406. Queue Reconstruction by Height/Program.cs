using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace _16__406._Queue_Reconstruction_by_Height
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] x =
            {
                new[] {7, 0}, new[] {4, 4}, new[] {7, 1}, new[] {5, 0}, new[] {6, 1}, new[] {5, 2}
            };
            int[][] res = ReconstructQueue(x);
            Console.WriteLine();
        }
        public static int[][] ReconstructQueue(int[][] people)
        {
            Array.Sort(people, (p1, p2) => p1[0] == p2[0] ? p1[1] - p2[1] : p2[0] - p1[0]);
            List<int[]> res = new List<int[]>();
            foreach (var person in people)
            {
                res.Insert(person[1], person);
            }

            return res.ToArray();
        }

        
    }
}
