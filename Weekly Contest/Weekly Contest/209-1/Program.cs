using System;

namespace _209_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SpecialArray(new []{ 0, 4, 3, 0, 4 }));
        }

        public static int SpecialArray(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < nums.Length; i++)
                {
                    if (i <= nums[j]) count++;
                }
                if (count == i) return i;
            }
            return -1;

        }
    }
}
