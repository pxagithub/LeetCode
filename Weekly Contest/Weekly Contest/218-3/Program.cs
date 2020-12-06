using System;

namespace _218_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConcatenatedBinary(1));
            Console.WriteLine(ConcatenatedBinary(3));
            Console.WriteLine(ConcatenatedBinary(12));
            Console.WriteLine(ConcatenatedBinary(10000));//574174111

        }

        public static int ConcatenatedBinary(int n)
        {
            int x = (int) 1e9 + 7;
            int res = 0;
            for (int i = 1; i <= n; i++)
            {
                string cur = "";
                for (int j = i;j>=1 ; j/=2)
                {
                    cur += (char) ('0' + j % 2);
                }

                for (int j = cur.Length-1; j >=0; j--)
                {
                    res = res * 2 + cur[j] - '0';
                    if (res > x) res -= x;
                }
            }

            return res;
        }

        
    }
}
