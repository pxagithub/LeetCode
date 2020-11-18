using System;

namespace _18__134.Gas_Station
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CanCompleteCircuit(new []{3,1,1},new []{1,2,2}));
        }
        public static int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int[] remain = new int[gas.Length];
            for (int i = 0; i < gas.Length; i++)
            {
                remain[i] = gas[i] - cost[i];
            }
            for (int start = 0; start < remain.Length; start++)
            {
                if (remain[start] >= 0)
                {
                    int remainGas = remain[start], i = start + 1;
                    while (i <= remain.Length)
                    {
                        i = i < remain.Length ? i : i - remain.Length;
                        remainGas += remain[i];
                        if (remainGas < 0) break;
                        if (i == start)
                        {
                            if (remainGas >= 0) return start;
                        }
                        i++;
                    }
                }
            }
            return -1;
        }
    }
}
