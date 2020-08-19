using System;
using System.Text;

namespace _19__647.Palindromic_Substrings
{
    class Program
    {
        /*647. 回文子串
           给定一个字符串，你的任务是计算这个字符串中有多少个回文子串。
           具有不同开始位置或结束位置的子串，即使是由相同的字符组成，也会被视作不同的子串。
           
           示例 1：
           输入："abc"
           输出：3
           解释：三个回文子串: "a", "b", "c"

           示例 2：
           输入："aaa"
           输出：6
           解释：6个回文子串: "a", "a", "a", "aa", "aa", "aaa"*/
        static void Main(string[] args)
        {
            string a = "abc";
            string b = "aaa";
            string c = "ababa";
            Console.WriteLine(CountSubstringsManacher(a));//3
            Console.WriteLine(CountSubstringsManacher(b));//6
            Console.WriteLine(CountSubstringsManacher(c));//9
        }

        /// <summary>
        /// 中心扩散法
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static int CountSubstrings(string s)
        {
            if (s.Length==0)
            {
                return 0;
            }

            int n = s.Length, count = 0;
            for (int i = 0; i < 2*n-1; i++)
            {
                //当i为偶数时，中心为字符，当i为奇数时，中心落在两个字符之间
                int l = i / 2, r = i / 2 + i % 2;

                //中心扩散
                while (l>=0&&r<n&&s[l]==s[r])
                {
                    l--;
                    r++;
                    count++;
                }
            }

            return count;
        }

        public static int CountSubstringsManacher(string s)
        {
            int n = s.Length;
            StringBuilder sb = new StringBuilder("$#");

            for (int i = 0; i < n; i++) 
            {
                sb.Append(s[i]);
                sb.Append('#');
            }

            n = sb.Length;
            sb.Append('!');

            int[] dp = new int[n];
            int iMax = 0, rMax = 0, res = 0;

            for (int i = 1; i < n; i++) 
            {
                //初始化DP
                dp[i] = i <= rMax ? Math.Min(rMax - i + 1, dp[2 * iMax - i]) : 1;

                //中心扩展
                while (sb[i+dp[i]]==sb[i-dp[i]])
                {
                    dp[i]++;
                }

                //动态维护iMax和rMax
                if (i + dp[i] - 1 > rMax)
                {
                    iMax = i;
                    rMax = i + dp[i] - 1;
                }

                //统计答案，当前贡献为(dp[i]-1)/2向上取整
                res += dp[i] / 2;
            }

            return res;

        }
    }
}
