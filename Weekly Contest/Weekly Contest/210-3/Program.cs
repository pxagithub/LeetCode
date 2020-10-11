using System;
using System.Linq;

namespace _210_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CheckPalindromeFormation("ulacfd", "jizalu"));
        }

        public static bool CheckPalindromeFormation(string a, string b)
        {
            int n = a.Length;
            if (n==1)
            {
                return true;
            }

            for (int i = 1; i <= n; i++)
            {
                string temp1 = a.Substring(0, i) + b.Substring(i, n - i);
                string temp2=new string(temp1.ToCharArray().Reverse().ToArray());
                if (temp1==temp2)
                {
                    return true;
                }

                temp1 = b.Substring(0, i) + a.Substring(i, n - i);
                temp2= new string(temp1.ToCharArray().Reverse().ToArray());
                if (temp1==temp2)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
