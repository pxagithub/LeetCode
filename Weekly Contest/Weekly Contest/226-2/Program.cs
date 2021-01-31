using System;
using System.Diagnostics.CodeAnalysis;

namespace _226_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", RestoreArray(new[] {new[] {2, 1}, new[] {3, 4}, new[] {3, 2}})));
            Console.WriteLine(string.Join(",",RestoreArray(new[] {new[] {4, -2}, new[] {1, 4}, new[] {-3, 1}})));
            Console.WriteLine(string.Join(",", RestoreArray(new[] { new[] { 10000, -10000 }, })));
            
        }

        

        public static int[] RestoreArray(int[][] adjacentPairs)
        {
            int n = adjacentPairs.Length+1;
            int[] temp = new int[2 * n];

            Array.Sort(adjacentPairs, (a, b) =>
            {
                if (a[0] > b[0]) return 1;
                else if (a[0] < b[0]) return -1;
                else return a[1] - b[1];
            });
            int leftIndex = n-1, rightIndex = n+1;
            int[] first = adjacentPairs[0];
            temp[n] = first[0];
            temp[leftIndex] = first[1];
            bool[] used=new bool[n-1];
            for (int i = 1; i < n-1; i++)
            {
                if (adjacentPairs[i][0]==first[0])
                {
                    used[i] = true;
                    temp[rightIndex] = adjacentPairs[i][1];
                }
                else if (adjacentPairs[i][1]==first[0])
                {
                    used[i] = true;
                    temp[rightIndex] = adjacentPairs[i][0];
                }
            }

            
            while (rightIndex-leftIndex<n-1)
            {
                int left = temp[leftIndex], right = temp[rightIndex];
                for (int i = 1; i < n-1; i++)
                {
                    if (used[i]) continue;
                    if (adjacentPairs[i][0]==left)
                    {
                        leftIndex--;
                        temp[leftIndex] = adjacentPairs[i][1];
                        used[i] = true;
                        break;
                    }
                    else if (adjacentPairs[i][1]==left)
                    {
                        leftIndex--;
                        temp[leftIndex] = adjacentPairs[i][0];
                        used[i] = true;
                        break;
                    }
                }
                for (int i = 1; i < n - 1; i++)
                {
                    if (used[i]) continue;
                    if (adjacentPairs[i][0] == right)
                    {
                        rightIndex++;
                        temp[rightIndex] = adjacentPairs[i][1];
                        used[i] = true;
                        break;
                    }
                    else if (adjacentPairs[i][1] == right)
                    {
                        rightIndex++;
                        temp[rightIndex] = adjacentPairs[i][0];
                        used[i] = true;
                        break;
                    }
                }

            }
            int[] res=new int[n];
            Array.Copy(temp,leftIndex,res,0,n);
            return res;
        }

       
    }
    
}
