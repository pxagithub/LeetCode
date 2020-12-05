using System;
using System.Globalization;
using System.Threading.Channels;

namespace _05__621.Task_Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] task1 = {'A', 'A', 'A', 'B', 'B', 'B'};
            char[] task2 = {'A', 'A', 'A', 'A', 'A', 'A', 'B', 'C', 'D', 'E', 'F', 'G'};
            Console.WriteLine(LeastInterval(task1, 2));
            Console.WriteLine(LeastInterval(task1, 0));
            Console.WriteLine(LeastInterval(task2, 2));
        }

        public static int LeastInterval(char[] tasks, int n)
        {
            int[] alphabet=new int[26];
            int len = tasks.Length;
            for (int i = 0; i < len; i++)
            {
                alphabet[tasks[i] - 'A']++;
            }
            Array.Sort(alphabet,(x1,x2)=>x2-x1);
            int count = 1;
            while (count<26&&alphabet[count]==alphabet[0])
            {
                count++;
            }

            return Math.Max(len, count + (n + 1) * (alphabet[0] - 1));
        }
    }
}
