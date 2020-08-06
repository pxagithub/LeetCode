using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace _06_336._Palindrome_Pairs
{
    class Program
    {
        /*336. 回文对
           给定一组唯一的单词， 找出所有不同 的索引对(i, j)，使得列表中的两个单词， words[i] + words[j] ，可拼接成回文串。
           
           示例 1:
           输入: ["abcd","dcba","lls","s","sssll"]
           输出: [[0,1],[1,0],[3,2],[2,4]] 
           解释: 可拼接成的回文串为 ["dcbaabcd","abcddcba","slls","llssssll"]

           示例 2:
           输入: ["bat","tab","cat"]
           输出: [[0,1],[1,0]] 
           解释: 可拼接成的回文串为 ["battab","tabbat"]*/
        static void Main(string[] args)
        {
            string[] x = {"abcd", "dcba", "lls", "s", "sssll"};
            string[] y = { "bat", "tab", "cat" };

            IList<IList<int>> res1 = PalindromePairs(x);
            IList<IList<int>> res2 = PalindromePairs(y);

            foreach (var r in res1)
            {
                Console.WriteLine($"[[{string.Join("],[",r)}]]");
            }

            Console.WriteLine("------------------");

            foreach (var r in res2)
            {
                Console.WriteLine($"[[{string.Join("],[", r)}]]");
            }
        }

        private static List<Node> tree;

        public static IList<IList<int>> PalindromePairs(string[] words)
        {
            tree=new List<Node>();
            tree.Add(new Node());
            int n = words.Length;
            for (int i = 0; i < n; i++)
            {
                Insert(words[i], i);
            }

            List<IList<int>> ret = new List<IList<int>>();
            for (int i = 0; i < n; i++)
            {
                int m = words[i].Length;
                for (int j = 0; j < m+1; j++)
                {
                    if (IsPalindrome(words[i],j,m-1))
                    {
                        int leftId = FindWord(words[i], 0, j - 1);
                        if (leftId!=-1&&leftId!=i)
                        {
                            ret.Add(new List<int>(){i,leftId});
                        }
                    }

                    if (j!=0&&IsPalindrome(words[i],0,j-1))
                    {
                        int rightId = FindWord(words[i], j, m - 1);
                        if (rightId!=-1&&rightId!=i)
                        {
                            ret.Add(new List<int>() {rightId, i});
                        }
                    }
                }
            }

            return ret;
        }

        public static void Insert(string s, int id)
        {
            int len = s.Length, add = 0;
            for (int i = 0; i < len; i++)
            {
                int x = s[i] - 'a';
                if (tree[add].ch[x]==0)
                {
                    tree.Add(new Node());
                    tree[add].ch[x] = tree.Count - 1;
                }

                add = tree[add].ch[x];
            }

            tree[add].flag = id;
        }

        public static bool IsPalindrome(string s, int left, int right)
        {
            int len = right - left + 1;
            for (int i = 0; i < len/2; i++)
            {
                if (s[left+i]!=s[right-i])
                {
                    return false;
                }
            }
            return true;
        }

        public static int FindWord(string s, int left, int right)
        {
            int add = 0;
            for (int i = right; i >= left; i--)
            {
                int x = s[i] - 'a';
                if (tree[add].ch[x]==0)
                {
                    return -1;
                }

                add = tree[add].ch[x];
            }

            return tree[add].flag;
        }


        class Node
        {
            public int[] ch=new int[26];
            public int flag;

            public Node()
            {
                flag = -1;
            }
        }
    }
}
