using System;
using System.Linq;

namespace _02__STO20.A_string_representing_a_numeric_value
{
    class Program
    {
        static void Main(string[] args)
        {
            /*剑指 Offer 20. 表示数值的字符串
               请实现一个函数用来判断字符串是否表示数值（包括整数和小数）。例如，字符串"+100"、"5e2"、"-123"、"3.1416"、"-1E-16"、"0123"都表示数值，但"12e"、"1a3.14"、"1.2.3"、"+-5"及"12e+5.4"都不是。*/
            Console.WriteLine(IsNumber(".1"));//T
            Console.WriteLine(IsNumber("5e2"));//T
            Console.WriteLine(IsNumber("-123"));//T
            Console.WriteLine(IsNumber("3.1416"));//T
            Console.WriteLine(IsNumber("-1E-16"));//T
            Console.WriteLine(IsNumber("0123"));//T
            Console.WriteLine(IsNumber("12e"));//F
            Console.WriteLine(IsNumber("1a3.14"));//F
            Console.WriteLine(IsNumber("1.2.3"));//F
            Console.WriteLine(IsNumber("+-5"));//F
            Console.WriteLine(IsNumber("12e+5.4"));//F
        }

        enum Dp
        {
            Start,//可以进入E以外的任意状态
            Symbol,//首位的符号位,可以进入Number状态或FP状态
            Number,//数字,可以进入E状态或者Point状态
            E,//可以进入AE状态
            ES,//E后的第一个符号位,可以进入AE
            AE,//After E,捕获任意数字后退出
            Point,//可以进入E状态,捕获任意数字后退出
            FP,//首位是小数点,奇怪的状态增加了
        };

        public static bool IsNumber(string s)
        {
            //朴素的思路就是判断符不符合规范，不符合直接False
            s = s.Trim();
            if (string.IsNullOrEmpty(s)) return false;
            char[] number = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            char[] symbol = new char[] { '+', '-' };
            char[] e = new char[] { 'E', 'e' };
            Dp dp = Dp.Start;//状态
                             //朴素的状态机
            foreach (char i in s)
            {
                switch (dp)
                {
                    case Dp.Start:
                        if (symbol.Contains(i)) dp = Dp.Symbol;
                        else if (number.Contains(i)) dp = Dp.Number;
                        else if ('.'.Equals(i)) dp = Dp.FP;
                        else return false;
                        break;
                    case Dp.Symbol:
                        if (number.Contains(i)) dp = Dp.Number;
                        else if ('.'.Equals(i)) dp = Dp.FP;
                        else return false;
                        break;
                    case Dp.Number:
                        if (number.Contains(i)) break;//数字状态的延续
                        else if (e.Contains(i)) dp = Dp.E;
                        else if ('.'.Equals(i)) dp = Dp.Point;
                        else return false;
                        break;
                    case Dp.E:
                        if (symbol.Contains(i)) dp = Dp.ES;//e后第一位可以是符号位
                        else if (number.Contains(i)) dp = Dp.AE;
                        else return false;
                        break;
                    case Dp.ES:
                        if (number.Contains(i)) dp = Dp.AE;
                        else return false;
                        break;
                    case Dp.AE:
                        if (number.Contains(i)) break;//AE的延续
                        else return false;
                        break;
                    case Dp.Point:
                        if (number.Contains(i)) break;//Point的延续
                        else if (e.Contains(i)) dp = Dp.E;
                        else return false;
                        break;
                    case Dp.FP:
                        if (number.Contains(i)) dp = Dp.Point;//进入Point
                        else return false;
                        break;
                }

            }
            if (dp == Dp.E || dp == Dp.Symbol || dp == Dp.ES || dp == Dp.FP) return false;
            return true;
        }
    }
}
