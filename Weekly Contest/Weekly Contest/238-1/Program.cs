using System;

namespace _238_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SumBase(34,6));
            Console.WriteLine(SumBase(42,2));
        }

        public static int SumBase(int n, int k)
        {
            int res = 0;
            while (n > 0)
            {
                if (n >= k)
                {
                    int temp = n / k;
                    while (temp>k)
                    {
                        temp /= k;
                    }
                    if (temp<k)
                    {
                        res += temp;
                    }
                    

                    

                }
                else
                {
                    res += n;
                    n = 0;
                }
                
            }
            return res;

        }
    }
}
