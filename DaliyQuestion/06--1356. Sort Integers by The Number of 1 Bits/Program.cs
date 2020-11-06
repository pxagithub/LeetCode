using System;
using System.Collections.Generic;

namespace _06__1356._Sort_Integers_by_The_Number_of_1_Bits
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",",SortByBits(new []{ 0, 1, 2, 3, 4, 5, 6, 7, 8 })));
            Console.WriteLine(string.Join(",", SortByBits(new[] {1000, 1000})));
        }

        public static int[] SortByBits(int[] arr)
        {
            
            
            Array.Sort(arr,(i,j)=>
            {
                if (NumberOfOne(i)>NumberOfOne(j))
                {
                    return 1;
                }
                else if (NumberOfOne(i) < NumberOfOne(j))
                {
                    return -1;
                }
                else
                {
                    if (i>j) return 1;
                    else if (i < j) return -1;
                    else return 0;
                }
            });
            return arr;

        }

        public static int NumberOfOne(int n)
        {
            int count = 0;
            while (n!=0)
            {
                count++;
                n &= n - 1;
            }

            return count;
        }
    }
}
