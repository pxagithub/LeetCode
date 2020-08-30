using System;
using System.Linq;

namespace _30__557._Reverse_Words_in_a_String_III
{
    class Program
    {
        static void Main(string[] args)
        {
            /*557. 反转字符串中的单词 III
               给定一个字符串，你需要反转字符串中每个单词的字符顺序，同时仍保留空格和单词的初始顺序。
               示例：
               
               输入："Let's take LeetCode contest"
               输出："s'teL ekat edoCteeL tsetnoc"*/
            string x = "Let's take LeetCode contest";
            Console.WriteLine(ReverseWords(x));
        }

        public static string ReverseWords(string s)
        {
            string res = "";
            string temp = "";
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i]!=' ')
                {
                    temp = s[i] + temp ;
                }
                else
                {
                    res = res + temp + s[i];
                    temp = "";
                }
            }

            return res+temp;
        }
    }
}
