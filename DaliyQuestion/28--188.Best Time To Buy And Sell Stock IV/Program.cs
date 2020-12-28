using System;
using System.Collections.Generic;
using System.Linq;

namespace _28__188.Best_Time_To_Buy_And_Sell_Stock_IV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxProfit(2, new[] {2, 4, 1}));
            Console.WriteLine(MaxProfit(2, new[] {3, 2, 6, 5, 0, 3}));
            Console.WriteLine(MaxProfit(2, new[] {1, 2, 4, 2, 5, 7, 2, 4, 9, 0}));//13
        }

        public static int MaxProfit(int k, int[] prices)
        {
            if (prices.Length==0)
            {
                return 0;
            }

            int n = prices.Length;
            k = Math.Min(k, n / 2);
            int[] buy=new int[k+1];
            int[] sell=new int[k+1];

            buy[0] = -prices[0];
            sell[0] = 0;
            for (int i = 1; i <= k; i++)
            {
                buy[i] = sell[i] = int.MinValue / 2;
            }

            for (int i = 1; i < n; i++)
            {
                buy[0] = Math.Max(buy[0], sell[0] - prices[i]);
                for (int j = 1; j <= k; j++)
                {
                    buy[j] = Math.Max(buy[j], sell[j] - prices[i]);
                    sell[j] = Math.Max(sell[j], buy[j - 1] + prices[i]);
                }
            }

            return sell.Max();
        }
    }
}
