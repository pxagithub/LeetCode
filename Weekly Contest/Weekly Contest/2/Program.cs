using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace _2
{
    class Program
    {
        static void Main()
        {
            string x1 = "input", x2 = "output";
            string y1 = "abc", y2 = "bcd";
            string z1 = "aab", z2 = "bbb";
            Console.WriteLine(CanConverString(x1,x2,9));
            Console.WriteLine(CanConverString(y1,y2,10));
            Console.WriteLine(CanConverString(z1,z2,27));
        }

        public static List<char> circle = new List<char>();
        public static bool CanConverString(string s, string t, int k)
        {
            int times = 0;
            int count = 0;

            int i = 0, j = 0;

            while (i<s.Length)
            {
                

            }



            return true;
        }


        public static void CreateCircle()
        {
            for (int i = 0; i < 26; i++)
            {
                circle.Add('a' + i);
            }
        }
    }
}
