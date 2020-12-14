using System;
using System.Collections.Generic;

namespace _14__49._Group_Anagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<IList<string>> a=GroupAnagrams(new []{ "eat", "tea", "tan", "ate", "nat", "bat" });
            Console.WriteLine();
        }
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            for (int i = 0; i < strs.Length; i++)
            {
                char[] temp = strs[i].ToCharArray();
                Array.Sort(temp);
                string s=new string(temp);
                if (dic.ContainsKey(s))
                {
                    dic[s].Add(strs[i]);
                }
                else
                {
                    dic.Add(s,new List<string>(){strs[i]});
                }
            }

            return new List<IList<string>>(dic.Values);
        }
    }
}
