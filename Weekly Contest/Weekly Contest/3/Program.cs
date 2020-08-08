using System;
using System.Collections;
using System.Collections.Generic;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "(()))", s2 = "())", s3 = "))())(", s4 = "((((((", s5 = "()())))()";
            Console.WriteLine(MinInsertions(s1));
            Console.WriteLine(MinInsertions(s2));
            Console.WriteLine(MinInsertions(s3));
            Console.WriteLine(MinInsertions(s4));
            Console.WriteLine(MinInsertions(s5));

        }

        public static int MinInsertions(string s)
        {
            List<char> list=new List<char>();

            int count = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i]=='(')
                {
                    list.Add('(');
                }

                if (s[i]==')')
                {
                    if (list.Contains('(')&&list.Contains(')'))
                    {
                        list.Remove('(');
                        list.Remove(')');
                    }
                    else if (list.Contains('('))
                    {
                        list.Add(')');
                    }
                    else if(list.Contains(')'))
                    {
                        list.Remove(')');
                        count --;
                    }
                    else
                    {
                        list.Add(')');
                        count += 2;
                    }
                }
            }

            int x = 0, y = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == '(') x++;
                else y++;
            }

            if (x==0)
            {
                y = 0;
            }

            return count + 2 * x -y;
        }
    }
}
