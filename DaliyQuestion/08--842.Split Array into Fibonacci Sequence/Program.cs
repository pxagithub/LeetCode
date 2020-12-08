using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace _08__842.Split_Array_into_Fibonacci_Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", SplitIntoFibonacci("123456579")));
            Console.WriteLine(string.Join(",", SplitIntoFibonacci("11235813")));
            Console.WriteLine(string.Join(",", SplitIntoFibonacci("112358130")));
            Console.WriteLine(string.Join(",", SplitIntoFibonacci("0123")));
            Console.WriteLine(string.Join(",", SplitIntoFibonacci("1101111")));

        }

        public static IList<int> SplitIntoFibonacci(string S)
        {
            List<int> res = new List<int>();
            Backtrack(S, res, 0);
            return res;

        }

        public static bool Backtrack(string s, List<int> res, int index)
        {
            if (index==s.Length&&res.Count>=3)
            {
                return true;
            }

            for (int i = index; i < s.Length; i++)
            {
                if (s[index]=='0'&&i>index)
                {
                    break;
                }

                long num = Transfer(s.Substring(index, i + 1 - index));

                if (num>int.MaxValue)
                {
                    break;
                }

                int count = res.Count;
                if (count >= 2 && num > res[count - 1] + res[count - 2])
                {
                    break;
                }

                if (count <= 1 || num == res[count - 1] + res[count - 2])
                {
                    res.Add((int) num);
                    if (Backtrack(s,res,i+1))
                    {
                        return true;
                    }
                    res.RemoveAt(res.Count-1);
                }
            }

            return false;
        }

        public static long Transfer(string s)
        {
            return Convert.ToInt64(s);
        } 
    }
}
