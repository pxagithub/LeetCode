using System;
using System.Collections.Generic;

namespace _04__659._Split_Array_into_Consecutive_Subsequences
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsPossible(new []{ 1, 2, 3, 3, 4, 5 }));
            Console.WriteLine(IsPossible(new []{ 1, 2, 3, 3, 4, 4, 5, 5 }));
            Console.WriteLine(IsPossible(new []{ 1, 2, 3, 4, 4, 5 }));
        }

        public static bool IsPossible(int[] nums)
        {
            Dictionary<int, int> jishu = new Dictionary<int, int>();
            Dictionary<int, int> wei = new Dictionary<int, int>();
            foreach (int x in nums)//统计出现次数
            {
                if (jishu.ContainsKey(x)) jishu[x]++; else jishu[x] = 1;
            }
            foreach (int x in nums)
            {
                int jis = jishu[x];//获得出现次数
                if (jis > 0)//能用次数大于0
                {
                    int zuos = wei.ContainsKey(x - 1) ? wei[x - 1] : 0;//左1结尾的序列数
                    if (zuos > 0)//左1结尾的序列数大于0
                    {
                        jishu[x] = jis - 1;//能加入到前面序列就加入
                        wei[x - 1] = zuos - 1;//前数为尾的序列数-1
                        if (wei.ContainsKey(x)) wei[x]++; else wei[x] = 1;//以本数结尾的序列数+1
                    }
                    else//前面数结尾的序列数小于等于0时, 那要从本数开新序列
                    {
                        int count1 = jishu.ContainsKey(x + 1) ? jishu[x + 1] : 0;//找到右1 个数
                        int count2 = jishu.ContainsKey(x + 2) ? jishu[x + 2] : 0;//找到右2 个数
                        if (count1 > 0 && count2 > 0)//右1和右2个数均大于零
                        {
                            jishu[x] = jis - 1;//本数计数-1
                            jishu[x + 1] = count1 - 1;//右1计数-1
                            jishu[x + 2] = count2 - 1;//右2计数-1
                            if (wei.ContainsKey(x + 2)) wei[x + 2]++; else wei[x + 2] = 1;//以右2结尾的序列数+1
                        }
                        else
                        {
                            return false;//如果找不到，表示失败了
                        }
                    }
                }
            }
            return true;//遍历完每次都能找得到，表示成功了


        }
    }
}
