using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bi_43_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaximumGain("cdbcbbaaabab", 4, 5));
            Console.WriteLine(MaximumGain("aabbaaxybbaabb", 5, 4));
        }

        public static int MaximumGain(string s, int x, int y)
        {
            int res = 0;
            Stack<char> stack = new Stack<char>();
            if (x>=y)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (stack.Count==0)
                    {
                        stack.Push(s[i]);
                        continue;
                    }
                    if (stack.Peek()=='a'&&s[i]=='b')
                    {
                        res += x;
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(s[i]);
                    }
                }

                s = new string(stack.ToArray().Reverse().ToArray());
                stack.Clear();
                for (int i = 0; i < s.Length; i++)
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(s[i]);
                        continue;
                    }
                    if (stack.Peek()=='b'&&s[i]=='a')
                    {
                        res += y;
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(s[i]);
                    }
                }
            }
            else
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(s[i]);
                        continue;
                    }
                    if (stack.Peek() == 'b' && s[i] == 'a')
                    {
                        res += y;
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(s[i]);
                    }
                }

                s = new string(stack.ToArray().Reverse().ToArray());
                stack.Clear();
                for (int i = 0; i < s.Length; i++)
                {
                    if (stack.Count == 0)
                    {
                        stack.Push(s[i]);
                        continue;
                    }
                    if (stack.Peek() == 'a' && s[i] == 'b')
                    {
                        res += x;
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(s[i]);
                    }
                }
            }
            
            return res;
        }
    }
}
