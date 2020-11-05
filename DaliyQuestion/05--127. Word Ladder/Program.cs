using System;
using System.Collections.Generic;

namespace _05__127._Word_Ladder
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] x = {"hot", "dot", "dog", "lot", "log", "cog"};
            string[] y = {"hot", "dot", "dog", "lot", "log"};
            Console.WriteLine(LadderLength("hit", "cog", x));
            Console.WriteLine(LadderLength("hit", "cog", y));
        }

        static Dictionary<string, int> wordId;
        static List<List<int>> edge;
        static int nodeNum;
        public static int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            wordId = new Dictionary<string, int>();
            edge = new List<List<int>>();
            nodeNum = 0;
            foreach (var word in wordList)
            {
                AddEdge(word);
            }
            AddEdge(beginWord);
            if (!wordId.ContainsKey(endWord))
            {
                return 0;
            }
            int[] dis = new int[nodeNum];
            Array.Fill(dis, int.MaxValue);
            int beginId = wordId[beginWord], endId = wordId[endWord];
            dis[beginId] = 0;

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(beginId);
            while (queue.Count != 0)
            {
                int x = queue.Dequeue();
                if (x == endId) return dis[endId] / 2 + 1;

                foreach (var it in edge[x])
                {
                    if (dis[it] == int.MaxValue)
                    {
                        dis[it] = dis[x] + 1;
                        queue.Enqueue(it);
                    }
                }
            }
            return 0;
        }

        public static void AddEdge(string word)
        {
            AddWord(word);
            int id1 = wordId[word];
            char[] array = word.ToCharArray();
            int length = array.Length;
            for (int i = 0; i < length; i++)
            {
                char temp = array[i];
                array[i] = '*';
                string newWord = new string(array);
                AddWord(newWord);
                int id2 = wordId[newWord];
                edge[id1].Add(id2);
                edge[id2].Add(id1);
                array[i] = temp;
            }
        }

        public static void AddWord(string word)
        {
            if (!wordId.ContainsKey(word))
            {
                wordId.Add(word, nodeNum++);
                edge.Add(new List<int>());
            }
        }
    }
}
