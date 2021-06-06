using System;
using System.Linq;

namespace _244_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinFlips("111000"));
            Console.WriteLine(MinFlips("010"));
            Console.WriteLine(MinFlips("1110"));
            Console.WriteLine(MinFlips("01001001101"));

        }
        public static int MinFlips(string s)
        {
            int n = s.Length;
            string s1 = "", s2 = "";
            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    s1 += '0';s2 += '1';
                }
                else
                {
                    s1 += '1';s2 += '0';
                }
            }
            int index = 0;
            for (int i = 0; i < n-1; i++)
            {
                if (s[i] == s[i + 1]) {
                    if (i >= 1 && s[i] != s[i - 1]) index = i + 1;
                    index = i; break; 
                }
            }
            int[] count = new int[4];
            for (int i = 0; i < n; i++)
            {
                if (s[i] != s1[i]) count[0]++;
                if (s[i] != s2[i]) count[1]++;
                if (s[i] != s1[(i + n - 1-index) % n]) count[2]++;
                if (s[i] != s2[(i + n - 1-index) % n]) count[3]++;
            }

            return count.Min();

        }
    }
}
