using System;
using System.Linq;

namespace _201_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindKthBit(3, 2));//1
            Console.WriteLine(FindKthBit(4, 12));//0
            Console.WriteLine(FindKthBit(1, 1));//0
            Console.WriteLine(FindKthBit(2, 3));//1
            Console.WriteLine(FindKthBit(6,57));//0

        }

        public static char FindKthBit(int n, int k)
        {
            int[] length=new int[n];
            length[0] = 1;

            for (int i = 1; i < n; i++)
            {
                length[i] = 2 * length[i - 1] + 1;
            }

            return Recur(n, k, length);

        }

        public static char Recur(int n, int k, int[] length)
        {
            if (n == 1||k==1)
            {
                return '0';
            }

            if (k <= length[n - 1] / 2)
            {
                return Recur(n - 1, k,length);
            }

            if (k == (length[n - 1] + 1) / 2)
            {
                return '1';
            }

            else
            {
                return Recur(n - 1, 2 * length[n - 2] - k + 2,length)=='0'?'1':'0';
            }
        }
    }
}
