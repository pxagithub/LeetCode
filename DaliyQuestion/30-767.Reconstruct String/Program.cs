using System;
using System.Linq;

namespace _30_767.Reconstruct_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReorganizeString("aba"));
            Console.WriteLine(ReorganizeString("aaab"));
            Console.WriteLine(ReorganizeString("vvvlo"));
            Console.WriteLine(ReorganizeString("blflxll"));

        }

        public static string ReorganizeString(string s)
        {
            //出现次数最多的字母有没有超过一半
            int mid = (s.Length + 1) / 2;
            //计数
            var dict = s.GroupBy(x => x)
                .OrderBy(x => x.Count())
                .ToDictionary(x => x.Key, x => x.Count());

            if (dict.Values.All(x => x <= mid))
            {
                var arr = new char[s.Length];
                Action<int> action = (i) =>
                {
                    var key = dict.Keys.First();
                    arr[i] = key;
                    dict[key]--;
                    if (dict[key] <= 0) dict.Remove(key);
                };

                //交替生成
                for (int i = 1; i < arr.Length; i+=2)
                {
                    action(i);
                }

                for (int i = 0; i < arr.Length; i+=2)
                {
                    action(i);
                }
                return new string(arr);
            }

            return "";
        }

            
    }
}
