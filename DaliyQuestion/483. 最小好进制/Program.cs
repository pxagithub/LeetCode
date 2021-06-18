using System;

namespace _483._最小好进制
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

    }

    public class Solution
    {
        public string SmallestGoodBase(string n)
        {
            long nVal = long.Parse(n);
            int mMax = (int) Math.Floor(Math.Log(nVal) / Math.Log(2));
            for (int i = mMax; i > 1; i--)
            {
                int k = (int) Math.Pow(nVal, 1.0 / i);
                long mul = 1, sum = 1;
                for (int j = 0; j < i; j++)
                {
                    mul *= k;
                    sum += mul;
                }

                if (sum==nVal)
                {
                    return k.ToString();
                }
            }

            return (nVal - 1).ToString();
        }
    }
}
