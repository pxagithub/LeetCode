using System;
using System.Collections.Generic;

namespace _14__20.Valid_Parentheses
{
    class Program
    {
        /*20. 有效的括号
           给定一个只包括 '('，')'，'{'，'}'，'['，']' 的字符串，判断字符串是否有效。
           有效字符串需满足：
           左括号必须用相同类型的右括号闭合。
           左括号必须以正确的顺序闭合。
           注意空字符串可被认为是有效字符串。
           示例 1:
           输入: "()"
           输出: true
           示例 2:
           输入: "()[]{}"
           输出: true
           示例 3:
           输入: "(]"
           输出: false
           示例 4:
           输入: "([)]"
           输出: false
           示例 5:
           输入: "{[]}"
           输出: true*/
        static void Main(string[] args)
        {
            Console.WriteLine(IsValid("()"));//T
            Console.WriteLine(IsValid("()[]{}"));//T
            Console.WriteLine(IsValid("(]"));//F
            Console.WriteLine(IsValid("([)]"));//F
            Console.WriteLine(IsValid("{[]}"));//T
        }

        public static bool IsValid(string s)
        {
            if (s.Length%2==1)
            {
                return false;
            }

            Dictionary<char, char> pairs = new Dictionary<char, char>();
            pairs.Add(')','(');
            pairs.Add(']', '[');
            pairs.Add('}', '{');

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (pairs.ContainsKey(c))
                {
                    if (stack.Count==0||stack.Peek()!=pairs[c])
                    {
                        return false;
                    }

                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }

            return stack.Count == 0;

        }
    }
}
