using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace _225_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinCharacters("da", "cced"));
            Console.WriteLine(MinCharacters("dee","a"));
            Console.WriteLine(MinCharacters("aba","caa"));
            Console.WriteLine(MinCharacters("dabadd","cda"));
        }

        public static int MinCharacters(string a, string b)
        {
            
            int[] A=new int[26];
            int[] B=new int[26];
            int[] X=new int[26];
            for (int i = 0; i < a.Length; i++)
            {
                int index = a[i] - 'a';
                A[index]++;
                X[index]++;
            }

            for (int i = 0; i < b.Length; i++)
            {
                int index = b[i] - 'a';
                B[index]++;
                X[index]++;
            }

            int res1 = 0, res2 = 0, res3 = 0, res4 = 0, res5 = 0;
            int maxA = MaxChar(A), maxB = MaxChar(B), minA = MinChar(A), minB = MinChar(B);
            for (int i = minB; i <= maxA; i++)
            {
                res1 += B[i];
            }

            for (int i = minA; i <= maxB; i++)
            {
                res2 += A[i];
            }

            for (int i = minA; i <= maxB; i++)
            {
                res4 += B[i];
            }

            for (int i = minB; i <= maxA; i++)
            {
                res5 += A[i];
            }

            res3 = a.Length + b.Length - X.Max();
            return Math.Min(res4,Math.Min(res5, Math.Min(Math.Min(res1, res2), res3)));

        }

        public static int MaxChar(int[] array)
        {
            int index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0) index = i;
            }

            return index;
        }

        public static int MinChar(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]!=0)
                {
                    return i;
                }
            }

            return 0;
        }
    }
}
