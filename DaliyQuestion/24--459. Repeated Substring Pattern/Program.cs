﻿using System;

namespace _24__459._Repeated_Substring_Pattern
{
    class Program
    {
        /*459. 重复的子字符串
           给定一个非空的字符串，判断它是否可以由它的一个子串重复多次构成。给定的字符串只含有小写英文字母，并且长度不超过10000。
           
           示例 1:
           输入: "abab"
           输出: True
           解释: 可由子字符串 "ab" 重复两次构成。

           示例 2:
           输入: "aba"
           输出: False

           示例 3:
           输入: "abcabcabcabc"
           输出: True
           解释: 可由子字符串 "abc" 重复四次构成。 (或者子字符串 "abcabc" 重复两次构成。)*/

        static void Main(string[] args)
        {
            Console.WriteLine(RepeatedSubstringPattern("abab"));//T
            Console.WriteLine(RepeatedSubstringPattern("aba"));//F
            Console.WriteLine(RepeatedSubstringPattern("abcabcabcabc"));//T

        }

        public static bool RepeatedSubstringPattern(string s)
        {
            int n = s.Length;
            for (int i = 1; i * 2 <= n ; i++)
            {
                if (n % i == 0)
                {
                    bool match = true;
                    for (int j = i; j < n; j++)
                    {
                        if (s[j] != s[j-i])
                        {
                            match = false;
                            break;
                        }
                    }

                    if (match)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
