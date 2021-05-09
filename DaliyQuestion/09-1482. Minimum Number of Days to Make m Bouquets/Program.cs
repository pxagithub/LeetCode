using System;
using System.Linq;

namespace _09_1482._Minimum_Number_of_Days_to_Make_m_Bouquets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MinDays(new []{ 7, 7, 7, 7, 12, 7, 7 },2,3));
        }
        public static int MinDays(int[] bloomDay, int m, int k)
        {
            int n = m * k;
            if (n > bloomDay.Length) return -1;
            int low = bloomDay.Min(), high = bloomDay.Max();
            while (low<high)
            {
                int day = (low + high) / 2;
                if (CanMakeFlower(bloomDay,m,k,day))
                {
                    high = day;
                }
                else
                {
                    low = day + 1;
                }
            }

            return low;

        }
        public static bool CanMakeFlower(int[] bloomDay, int m, int k, int day)
        {
            int bouquets = 0;
            int flowers = 0;
            int len = bloomDay.Length;
            for (int i = 0; i < len&&bouquets<m; i++)
            {
                if (bloomDay[i]<=day)
                {
                    flowers++;
                    if (flowers==k)
                    {
                        bouquets++;
                        flowers = 0;
                    }
                }
                else
                {
                    flowers = 0;
                }
            }
            return bouquets >= m;
        }
    }
}
