using System;
using System.Collections.Generic;

namespace _242_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CanReach("011010",2,3));
            Console.WriteLine(CanReach("01101110", 2, 3));


        }
        public static bool CanReach(string s, int minJump, int maxJump)
        {
            int n = s.Length;
            int[] list = new int[n + 1];
            list[0] = 0; list[1] = 1;
            for (int i = 1; i < n; i++)
            {
                int a = i - minJump, b = i - maxJump;
                if (a < 0) a = 0;
                if (b < 0) b = -1;
                int x = list[b + 1] - list[a];
                list[i + 1] = list[i];
                if (x > 0 && s[i] == '0') list[i + 1]++;
            }

            return list[^1] > list[^2];
        }
    }
}
