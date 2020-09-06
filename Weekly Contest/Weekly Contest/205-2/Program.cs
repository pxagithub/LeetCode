﻿using System;
using System.Collections.Generic;

namespace _205_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x1 = { 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000, 100000 };
            int[] y1= {1864};
            int[] x2 = {1, 1};
            int[] y2 = {1, 1, 1};
            int[] x3 = {7, 7, 8, 3};
            int[] y3 = {1, 2, 9, 7};
            int[] x4 = {4, 7, 9, 11, 23};
            int[] y4 = {3, 5, 1024, 12, 18};

            Console.WriteLine(NumTriplets(x1, y1));
            Console.WriteLine(NumTriplets(x2, y2));
            Console.WriteLine(NumTriplets(x3, y3));
            Console.WriteLine(NumTriplets(x4, y4));

        }
        public static int NumTriplets(int[] nums1, int[] nums2)
        {
            long[] xSquare = new long[nums1.Length];
            long[] ySquare = new long[nums2.Length];

            List<long> xProduct = new List<long>();
            List<long> yProduct = new List<long>();

            for (int i = 0; i < nums1.Length; i++)
            {
                xSquare[i] = nums1[i] * nums1[i];
            }

            for (int i = 0; i < nums2.Length; i++)
            {
                ySquare[i] = nums2[i] * nums2[i];
            }

            for (int i = 0; i < nums1.Length - 1; i++)
            {
                for (int j = i + 1; j < nums1.Length; j++) 
                {
                    xProduct.Add((long)nums1[i] * (long)nums1[j]);
                }
            }

            for (int i = 0; i < nums2.Length - 1; i++)
            {
                for (int j = i + 1; j < nums2.Length; j++)
                {
                    yProduct.Add((long)nums2[i] * (long)nums2[j]);
                }
            }

            int res = 0;
            for (int i = 0; i < xSquare.Length; i++)
            {
                for (int j = 0; j < yProduct.Count; j++)
                {
                    if (xSquare[i]==yProduct[j])
                    {
                        res++;
                    }
                }
            }

            for (int i = 0; i < ySquare.Length; i++)
            {
                for (int j = 0; j < xProduct.Count; j++)
                {
                    if (ySquare[i] == xProduct[j])
                    {
                        res++;
                    }
                }
            }

            return res;
        }
    }
}
