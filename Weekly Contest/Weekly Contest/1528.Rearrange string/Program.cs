using System;

namespace _1528.Rearrange_string
{
    class Program
    {
        /*1528.重新排列字符串
         给你一个字符串 s 和一个 长度相同 的整数数组 indices 。
           请你重新排列字符串 s ，其中第 i 个字符需要移动到 indices[i] 指示的位置。
           返回重新排列后的字符串。
           示例 1：
           输入：s = "codeleet", indices = [4,5,6,7,0,2,1,3]
           输出："leetcode"
           解释：如图所示，"codeleet" 重新排列后变为 "leetcode" 。
           示例 2：
           输入：s = "abc", indices = [0,1,2]
           输出："abc"
           解释：重新排列后，每个字符都还留在原来的位置上。
           示例 3：
           输入：s = "aiohn", indices = [3,1,4,2,0]
           输出："nihao"
           示例 4：
           输入：s = "aaiougrt", indices = [4,0,2,6,7,3,1,5]
           输出："arigatou"
           示例 5：
           输入：s = "art", indices = [1,0,2]
           输出："rat"
           提示：
           s.length == indices.length == n
           1 <= n <= 100
           s 仅包含小写英文字母。
           0 <= indices[i] < n
           indices 的所有的值都是唯一的（也就是说，indices 是整数 0 到 n - 1 形成的一组排列）。*/
        static void Main(string[] args)
        {
            string x1 = "codeleet", x2 = "abc", x3 = "aiohn", x4 = "aaiougrt", x5 = "art";
            int[] y1 = {4, 5, 6, 7, 0, 2, 1, 3},
                y2 = {0, 1, 2},
                y3 = {3, 1, 4, 2, 0},
                y4 = {4, 0, 2, 6, 7, 3, 1, 5},
                y5 = {1, 0, 2};
            Console.WriteLine(string.Join("\n",RestoreString(x1,y1),RestoreString(x2,y2),RestoreString(x3,y3),RestoreString(x4,y4),RestoreString(x5,y5)));
        }

        public static string RestoreString(string s, int[] indices)
        {
            var sArr = s.ToCharArray();

            char[] strChar = new char[s.Length];

            for (int i = 0; i < indices.Length; i++)
            {

                strChar[indices[i]] = sArr[i];

            }
            return new string(strChar);
        }
    }
}
