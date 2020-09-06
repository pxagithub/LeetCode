using System;

namespace _205_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ModifyString("?zs"));
            Console.WriteLine(ModifyString("ubv?w"));
            Console.WriteLine(ModifyString("j?qg??b"));
            Console.WriteLine(ModifyString("??yw?ipkj?"));
        }

        public static string ModifyString(string s)
        {
            string res = "";

            if (s.Length==0)
            {
                return res;
            }

            if (s.Length==1)
            {
                return s == "?" ? "a" : s;
            }

            if (s[0]!='?')
            {
                res += s[0];
            }
            else
            {
                for (char i='a'; i < 'z'; i++)
                {
                    if (s[1]!=i)
                    {
                        res += i;
                        break;
                    }
                }
            }

            for (int i = 1; i < s.Length - 1; i++) 
            {
                if (s[i] == '?') 
                {
                    for (char j = 'a'; j < 'z'; j++)
                    {
                        if (res[i - 1] != j && s[i + 1] != j) 
                        {
                            res += j;
                            break;
                        }
                    }
                }
                else
                {
                    res += s[i];
                }
            }

            if (s[^1] != '?')
            {
                res += s[^1];
            }
            else
            {
                for (char i = 'a'; i < 'z'; i++)
                {
                    if (res[^1] != i)
                    {
                        res += i;
                        break;
                    }
                }
            }

            return res;

        }
    }
}
