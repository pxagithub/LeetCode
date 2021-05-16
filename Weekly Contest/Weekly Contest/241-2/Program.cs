using System;
using System.Linq;

namespace _241_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinSwaps("010"));
        }
        public static int MinSwaps(string s)
        {
            int n = s.Length;
            int n0 = s.Count(c => c == '0');
            int n1 = s.Count(c => c == '1');
            int res = int.MaxValue;

            if (n1 == (n + 1) / 2 && n0 == n / 2)
            {
                int diff1 = 0;
                for (int i = 0; i < n; i++)
                {
                    if (s[i] - '0' == i % 2) diff1++;
                }
                res = Math.Min(res, diff1 / 2);
            }
            if (n0 == (n + 1) / 2 && n1 == n / 2)
            {
                int diff2 = 0;
                for (int i = 0; i < n; i++)
                {
                    if (s[i] - '0' != i % 2) diff2++;
                }
                res = Math.Min(res, diff2 / 2);
            }

            return res == int.MaxValue ? -1 : res;

        }
    }
}
