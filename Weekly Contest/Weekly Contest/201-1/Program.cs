using System;

namespace _201_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "leEeetcode", s2 = "abBAcC", s3 = "s";
            Console.WriteLine(MakeGood(s1));
            Console.WriteLine(MakeGood(s2));
            Console.WriteLine(MakeGood(s3));

        }

        public static string MakeGood(string s)
        {
            int i = 0, j = 1;
            while (j<s.Length)
            {
                if ((s[i]==char.ToLower(s[j])&&s[i]!=s[j])|| (s[j] == char.ToLower(s[i]) && s[i] != s[j]))
                {
                    s = s.Remove(j, 1);
                    s = s.Remove(i, 1);
                    i = 0;
                    j = 1;
                }
                else
                {
                    i++;
                    j++;
                }
            }

            return s;
        }

        
    }
}
