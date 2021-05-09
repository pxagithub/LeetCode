using System;

namespace _240_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] x = new[] {new[]{ 2033, 2034 }, new[] {2039, 2047}, new[] {1998, 2042}, new[] {2047, 2048}, new[] {2025, 2029}, new[] {2005, 2044}, new[] {1990, 1992}, new[] {1952, 1956}, new[] {1984, 2014}};
            Console.WriteLine(MaximumPopulation(x));
        }
        public static int MaximumPopulation(int[][] logs)
        {
            
            int[] births = new int[logs.Length];
            int[] deaths = new int[logs.Length];
            for (int k = 0; k < logs.Length; k++)
            {
                births[k] = logs[k][0];
                deaths[k] = logs[k][1];
            }

            Array.Sort(births);
            Array.Sort(deaths);
            int now = births[0];
            int count = 1;
            int res = now;
            int max = count;
            int i = 0, j = 0;
            while (i < logs.Length)
            {
                int birth = births[i];
                int death = deaths[j];
                if (birth < death)
                {
                    now = birth;
                    count++;
                    i++;
                }
                else if(birth>death)
                {
                    now = death;
                    count--;
                    j++;
                }
                else
                {
                    now = birth;
                    i++;
                    j++;
                }

                if (max<count)
                {
                    max = count;
                    res = now;
                }
            }

            return res;


        }
    }
}
