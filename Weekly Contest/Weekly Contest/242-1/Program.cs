using System;

namespace _242_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] x = {1, 3, 2};
            Console.WriteLine(MinSpeedOnTime(x,6));
            Console.WriteLine(MinSpeedOnTime(x,2.7));
            Console.WriteLine(MinSpeedOnTime(x,1.9));

        }
        public static int MinSpeedOnTime(int[] dist, double hour)
        {
            int left = 1, right = 10000005;
            while (left < right)
            {
                int mid = (left + right) / 2;
                double total = 0;
                for (int i = 0; i < dist.Length - 1; i++)
                {
                    int t = dist[i] / mid;
                    if (dist[i] % mid != 0)
                    {
                        t++;
                    }
                    total += t;
                }

                total += (double)dist[^1] / mid;
                if (total <= hour)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }
            if (left == 10000005) return -1;
            return left;


        }

    }
}
