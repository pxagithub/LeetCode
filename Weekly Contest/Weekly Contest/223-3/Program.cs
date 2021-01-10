using System;

namespace _223_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] s1 = {1, 2, 3, 4};
            int[] t1 = {2, 1, 4, 5};
            int[][] a1 = {new[] {0, 1}, new[] {2, 3}};
            Console.WriteLine(MinimumHammingDistance(s1,t1,a1));
        }

        public static int MinimumHammingDistance(int[] s, int[] t, int[][] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                int x = a[i][0], y = a[i][1];
                if (s[x] == t[x] && s[y] == t[y])
                {
                    continue;
                }
                else if (s[x] != t[x] && s[y] != t[y])
                {
                    if (s[x] == t[y] || s[y] == t[x])
                    {
                        Swap(ref s[x], ref s[y]);
                    }
                }
                else
                {
                    if (s[x] == t[y] && s[y] == t[x])
                    {
                        Swap(ref s[x], ref s[y]);
                    }
                }
            }
            int res = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != t[i]) res++;
            }
            return res;

        }
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
