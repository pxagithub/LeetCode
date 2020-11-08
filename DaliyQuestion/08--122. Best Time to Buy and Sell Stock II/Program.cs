using System;

namespace _08__122._Best_Time_to_Buy_and_Sell_Stock_II
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxProfit(new[] {7, 1, 5, 3, 6, 4}));
        }

        public static int MaxProfit(int[] prices)
        {
            int res = 0, low = prices[0];
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i - 1] < prices[i])
                {
                    if (prices[i - 1] < low) low = prices[i - 1];
                }
                    
                else
                {
                        res += prices[i - 1] - low;
                        low = prices[i];
                }
            }
            if (prices[^1] > low) res += prices[^1] - low;
            return res;

        }
    }
}
