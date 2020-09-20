using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _207_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "  hello";
            string y = " practice   makes   perfect";


            Console.WriteLine(ReorderSpaces(x));
            Console.WriteLine(ReorderSpaces(y));
        }

        public static string ReorderSpaces(string text)
        {
            int spaceCount = 0;
            List<string> wordList = new List<string>();
            string temp = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i]==' ')
                {
                    spaceCount++;
                    if (temp.Length!=0)
                    {
                        wordList.Add(temp);
                        temp = "";
                    }
                }
                else
                {
                    temp += text[i];
                }
            }

            if (temp.Length!=0)
            {
                wordList.Add(temp);
            }

            if (wordList.Count==1)
            {
                string x = "";
                for (int i = 0; i < spaceCount; i++)
                {
                    x += ' ';
                }
                return wordList[0] + x;
            }

            int everyWordsSpace = spaceCount/(wordList.Count-1);
            int lastSpace = spaceCount - everyWordsSpace * (wordList.Count-1);

            string res = "";
            for (int i=0; i < wordList.Count-1; i++)
            {
                res += wordList[i];
                for (int j = 0; j < everyWordsSpace; j++)
                {
                    res += ' ';
                }
            }

            res += wordList[wordList.Count - 1];
            

            for (int i = 0; i < lastSpace; i++)
            {
                res += ' ';
            }

            return res;
        }
    }
}
