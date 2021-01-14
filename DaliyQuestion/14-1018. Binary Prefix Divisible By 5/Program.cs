using System;
using System.Collections.Generic;

namespace _14_1018._Binary_Prefix_Divisible_By_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", PrefixesDivBy5(new[]
            {
                1, 0, 0, 1, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1,
                0, 0, 0, 1
            })));
        }

        public static IList<bool> PrefixesDivBy5(int[] A)
        {
            Int32 n = A.Length;
            Int32[] binary = new Int32[n];
            Boolean[] res = new bool[n];
            binary[0] = A[0];
            res[0] = binary[0] == 0;
            for (Int32 i = 1; i < n; i++)
            {
                binary[i] = binary[i - 1] << 1;
                if (A[i] == 1) binary[i]++;
                binary[i] %= 5;
                res[i] = binary[i]  == 0;
            }

            Console.WriteLine(string.Join(",",binary));
            return res;
        }

        
    }
}
