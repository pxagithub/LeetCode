using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _22__679.Game
{
    class Program
    {
        /*679. 24 点游戏
           你有 4 张写有 1 到 9 数字的牌。你需要判断是否能通过 *，/，+，-，(，) 的运算得到 24。
           
            示例 1:
           输入: [4, 1, 8, 7]
           输出: True
           解释: (8-4) * (7-1) = 24
           
            示例 2:
           输入: [1, 2, 1, 2]
           输出: False

           注意:
           除法运算符 / 表示实数除法，而不是整数除法。例如 4 / (1 - 2/3) = 12 。
           每个运算符对两个数进行运算。特别是我们不能用 - 作为一元运算符。例如，[1, 1, 1, 1] 作为输入时，表达式 -1 - 1 - 1 - 1 是不允许的。
           你不能将数字连接在一起。例如，输入为 [1, 2, 1, 2] 时，不能写成 12 + 12 。*/
        static void Main(string[] args)
        {
            int[] x = {4, 1, 8, 7};
            int[] y = {1, 2, 1, 2};
            Console.WriteLine(JudgePoint24(x));
            Console.WriteLine(JudgePoint24(y));

        }


        private  static readonly  int _target = 24;
        private static readonly double _epsilon = 1e-6;
        private static readonly int _add = 0, _multiply = 1, _subtract = 2, _divide = 3;

        public static bool JudgePoint24(int[] nums)
        {
            List<double> list = new List<double>();
            foreach (var num in nums)
            {
                list.Add((double) num);
            }

            return Solve(list);
        }

        private static bool Solve(List<double> list)
        {
            if (list.Count==0)
            {
                return false;
            }

            if (list.Count==1)
            {
                return Math.Abs(list[0] - _target) < _epsilon;
            }

            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (i!=j)
                    {
                        List<double> list2 = new List<double>();
                        for (int k = 0; k < count; k++)
                        {
                            if (k!=i&&k!=j)
                            {
                                list2.Add(list[k]);
                            }
                        }

                        for (int k = 0; k < 4; k++)
                        {
                            if (k<2&&i>j)
                            {
                                continue;
                            }

                            if (k==_add)
                            {
                                list2.Add(list[i]+list[j]);
                            }

                            else if (k==_multiply)
                            {
                                list2.Add(list[i] * list[j]);
                            }

                            else if (k==_subtract)
                            {
                                list2.Add(list[i] - list[j]);
                            }

                            else if (k==_divide)
                            {
                                if (Math.Abs(list[j])<_epsilon)
                                {
                                    continue;
                                }
                                else
                                {
                                    list2.Add((list[i]/list[j]));
                                }
                            }

                            if (Solve(list2))
                            {
                                return true;
                            }

                            list2.RemoveAt(list2.Count - 1);
                        }
                        }
                    }
                }

            return false;
        }
        

    }
}
