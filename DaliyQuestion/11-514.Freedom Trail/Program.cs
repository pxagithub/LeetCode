using System;
using System.Linq;

namespace _11_514.Freedom_Trail
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FindRotateSteps("abcde", "ade"));
            Console.WriteLine(FindRotateSteps("pqwcx", "cpqwx"));
            Console.WriteLine(FindRotateSteps("godding","gniog"));
            Console.WriteLine(FindRotateSteps("godding", "gd"));
            Console.WriteLine(FindRotateSteps("godding", "gni"));
        }

        public static int FindRotateSteps(string ring, string key)
        {
            int n = ring.Length;
            int res = key.Length;
            int[] dp=new int[n];
            Array.Fill(dp,int.MaxValue);//新建dp数组后填入最大值
            for (int i = 0; i < n; i++)
            {
                if (ring[i]==key[0])
                {
                    dp[i] = Math.Min(i, n - i);//计算第一轮到每个字母的距离
                }
            }

            if (key.Length<=1)
            {
                return key.Length + dp.Min();
            }

            for (int i = 1; i < key.Length; i++)
            {
                int[] temp = new int[n];
                Array.Copy(dp, temp,n);
                Array.Fill(dp, int.MaxValue);
                for (int j = 0; j < n; j++)
                {
                    if (ring[j]==key[i])
                    {
                        dp[j] = MinTrail(temp, j);
                    }
                }
            }


            return res + dp.Min();
        }

        public static int MinTrail(int[] dp, int index)
        {
            int res = int.MaxValue;
            for (int i = 0; i < dp.Length; i++)
            {
                if (dp[i]!=int.MaxValue)
                {
                    int temp = Math.Min(Math.Abs(index - i), dp.Length-Math.Abs(i-index));
                    temp += dp[i];
                    res = res < temp ? res : temp;
                }
            }

            return res;
        }
    }
}
