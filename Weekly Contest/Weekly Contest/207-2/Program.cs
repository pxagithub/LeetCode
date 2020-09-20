using System;
using System.Collections.Generic;

namespace _207_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(MaxUniqueSplit("ababccc"));//5
            Console.WriteLine(MaxUniqueSplit("aba"));//2
            Console.WriteLine(MaxUniqueSplit("aa"));//1
            Console.WriteLine(MaxUniqueSplit("addbsd"));//5
            Console.WriteLine(MaxUniqueSplit("fcmfacp"));//6
            Console.WriteLine(MaxUniqueSplit("gpaccacseleac"));//10
        }

        public static int MaxUniqueSplit(string s)
        {
            Dictionary<char, int> pairCount = new Dictionary<char, int>();
            List<string> pair=new List<string>(); 
            for (int i = 0; i < s.Length; i++)
            {
                if (!pairCount.ContainsKey(s[i]))
                {
                    pairCount.Add(s[i], 1);
                }
                else
                {
                    pairCount[s[i]]++;
                }
            }

            for (int i = 1; i < s.Length; i++)
            {
                if (pairCount[s[i]] > 1 && pairCount[s[i - 1]] > 1)
                {
                    if (s[i]==s[i-1]&&pairCount[s[i]]<=2)
                    {
                        continue;
                    }
                    string temp = s[i - 1].ToString()+ s[i].ToString() ;
                    if (!pair.Contains(temp))
                    {
                        pair.Add(temp);
                        pairCount[s[i]]--;
                        pairCount[s[i - 1]]--;
                        i++;
                    }
                }
            }

            return pair.Count + pairCount.Count;
        }
    }
}
