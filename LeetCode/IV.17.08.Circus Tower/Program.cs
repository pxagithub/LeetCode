﻿using System;

namespace IV17._08.Circus_Tower
{
    class Program
    {
        /*面试题 17.08. 马戏团人塔
           有个马戏团正在设计叠罗汉的表演节目，一个人要站在另一人的肩膀上。出于实际和美观的考虑，在上面的人要比下面的人矮一点且轻一点。已知马戏团每个人的身高和体重，请编写代码计算叠罗汉最多能叠几个人。
           示例：
           输入：height = [65,70,56,75,60,68] weight = [100,150,90,190,95,110]
           输出：6
           解释：从上往下数，叠罗汉最多能叠 6 层：(56,90), (60,95), (65,100), (68,110), (70,150), (75,190)
           提示：
           height.length == weight.length <= 10000*/
        static void Main(string[] args)
        {
            int[] h = new int[] {65, 70, 56, 75, 60, 68};
            int[] w=new int[]{100,150,90,190,95,110};
            Console.WriteLine(BestSeqAtIndex(h,w));
        }
        public static int BestSeqAtIndex(int[] height, int[] weight)
        {
            (int tHeight,int tWeight)[] hw=new (int, int)[height.Length];
            for (int i = 0; i < hw.Length; i++)
            {
                hw[i] = (height[i], weight[i]);
            }
            Array.Sort(hw,(tuple1,tuple2)=>
            {
                if(tuple1.tHeight!=tuple2.tHeight)
                    return tuple1.tHeight.CompareTo(tuple2.tHeight);
                else
                {
                    return tuple2.tWeight.CompareTo(tuple1.tWeight);
                }
            });
            //for (int i = 0; i < hw.Length; i++)
            //{
            //    Console.WriteLine(hw[i]);
            //}
            
            int[] dp=new int[height.Length];
            dp[0] = 1;
            int res = 0;
            foreach (var person in hw)
            {
                int i = Array.BinarySearch(dp, 0, res, person.tWeight);
                if (i < 0)
                    i = -(i + 1);
                dp[i] = person.tWeight;
                if (i == res)
                    ++res;

            }

            return res;
        }
    }
}
