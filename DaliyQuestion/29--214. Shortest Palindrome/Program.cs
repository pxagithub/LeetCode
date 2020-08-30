using System;
using System.Net.Http.Headers;

namespace _29__214._Shortest_Palindrome
{
    class Program
    {
        static void Main(string[] args)
        {
            /*214. 最短回文串
               给定一个字符串 s，你可以通过在字符串前面添加字符将其转换为回文串。找到并返回可以用这种方式转换的最短回文串。
               
               示例 1:
               输入: "aacecaaa"
               输出: "aaacecaaa"
               
               示例 2:
               输入: "abcd"
               输出: "dcbabcd"*/
            string x = "aacecaaa";
            string y = "dcbabcd";
            string z = "aabba";
            Console.WriteLine(ShortestPalindrome(x));
            Console.WriteLine(ShortestPalindrome(y));
            Console.WriteLine(ShortestPalindrome(z));

        }

        private static string ShortestPalindrome(string s)
        {
            if (IsPalindrome(s))
            {
                return s;
            }
            string res = "";
            int i = 0, j = s.Length-1;
            while (i < j)
            {
                int temp = j;

                while (s[i]==s[temp]&&i<=temp)
                {
                    i++;
                    temp--;
                }
                if (i >= temp)
                {
                    break;
                }

                if (s[i]!=s[temp])
                {
                    i = 0;
                    j--;
                }
                
                
            }

            for (int k = j + 1; k < s.Length; k++)
            {
                res = s[k] + res;
            }

            return res + s;
        }

        private static bool IsPalindrome(string s)
        {
            for (int i = 0; i < s.Length/2; i++)
            {
                if (s[i]!=s[s.Length-1-i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
