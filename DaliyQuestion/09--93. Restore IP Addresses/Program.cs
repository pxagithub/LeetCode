using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace _09__93._Restore_IP_Addresses
{
    class Program
    {
               /*93. 复原IP地址
                给定一个只包含数字的字符串，复原它并返回所有可能的 IP 地址格式。
                有效的 IP 地址正好由四个整数（每个整数位于 0 到 255 之间组成），整数之间用 '.' 分隔。

                示例:
                输入: "25525511135"
                输出: ["255.255.11.135", "255.255.111.35"]*/
        static void Main(string[] args)
        {
            string x = "25525511135";
            Console.WriteLine(string.Join(",",RestoreIpAddresses(x)));
        }

        public static IList<string> RestoreIpAddresses(string s)
        {
            List<string> res = new List<string>();

            StringBuilder ip = new StringBuilder();

            for (int a = 1; a < 4; a++)
            {
                for (int b = 1; b < 4; b++)
                {
                    for (int c = 1; c < 4; c++)
                    {
                        for (int d = 1; d < 4; d++)
                        {
                            if (a+b+c+d==s.Length)
                            {
                                int n1 = int.Parse(s.Substring(0, a));
                                int n2 = int.Parse(s.Substring(a, b));
                                int n3 = int.Parse(s.Substring(a+b, c));
                                int n4 = int.Parse(s.Substring(a + b + c));
                                if (n1 <= 255 && n2 <= 255 && n3 <= 255 && n4 <= 255)
                                {
                                    ip.Append(n1).Append('.').Append(n2).Append('.').Append(n3).Append('.').Append(n4);
                                    if (ip.Length==s.Length+3)
                                    {
                                        res.Add(ip.ToString());
                                    }

                                    ip.Clear();
                                }
                                
                            }
                        }
                    }
                }
            }
            return res;
        }
    }
}
