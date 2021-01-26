using System;

namespace _26_1128.Number_of_Equivalent_Domino_Pairs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(NumEquivDominoPairs(new []{new []{1,2},new []{2,1},new []{3,4},new []{5,6},new []{2,1},new []{3,4}}));
        }

        public static int NumEquivDominoPairs(int[][] dominoes)
        {
            int res = 0;
            bool[] check = new bool[dominoes.Length];
            for (int i = 0; i < dominoes.Length; i++)
            {
                if (check[i]) continue;
                int x1 = dominoes[i][0], y1 = dominoes[i][1];
                int count = 0;
                for (int j = i + 1; j < dominoes.Length; j++)
                {
                    int x2 = dominoes[j][0], y2 = dominoes[j][1];
                    if ((x1 == x2 && y1 == y2) || (x1 == y2 && x2 == y1))
                    {
                        count++;
                        check[j] = true;
                    }
                }
                res += (count + count * count) / 2;
            }
            return res;

        }
    }
}
