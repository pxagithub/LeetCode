using System;

namespace Bi_43_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",",ConstructDistancedSequence(3)));
            Console.WriteLine(string.Join(",", ConstructDistancedSequence(5)));
        }
        public static int[] ConstructDistancedSequence(int n)
        {
            int[] res = new int[2 * n - 1];
            res[0] = res[n] = n;
            if (n==1)
            {
                return new[] {1};
            }

            if (n==2)
            {
                return new[] {2, 1, 2};
            }
            if (n==3)
            {
                res[1] = 1;
            }
            else
            {
                res[1] = res[n - 1] = n - 2;
            }
            
            for (int i = 2; i <= n-2; i++)
            {
                for (int j = 2; j < res.Length; j++)
                {
                    if (j+i<res.Length&&res[j]==0 && res[j+i]==0)
                    {
                        res[j] = res[j + i] = i;
                    }
                }
            }

            for (int i = 0; i < res.Length; i++)
            {
                if (i<n&&res[i]==0&&res[i+n-1]==0)
                {
                    res[i] = res[i + n - 1] = n-1;
                }

                if (res[i]==0)
                {
                    res[i] = 1;
                }
            }

            return res;
        }
    }
}
