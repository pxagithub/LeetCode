using System;

namespace _11_649.Dota2_Senate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PredictPartyVictory("DDRRR"));
        }

        public static string PredictPartyVictory(string senate)
        {
            bool[] baned = new bool[senate.Length];
            int countR = 0, countD = 0, n = senate.Length;
            for (int k = 0; k < n; k++)
            {
                if (senate[k] == 'R') countR++;
                else countD++;
            }

            int i = 0;
            while (countR!=0&&countD!=0)
            {
                i = i % n;
                if (!baned[i])
                {
                    if (senate[i] == 'R')
                    {
                        int j = i + 1;
                        while (countD != 0)
                        {
                            j = j % n;
                            if (senate[j] == 'D' && !baned[j])
                            {
                                baned[j] = true;
                                countD--;
                                break;
                            }
                            j++;
                        }
                    }
                    else
                    {
                        int j = i + 1;
                        while (countR != 0)
                        {
                            j = j % n;
                            if (senate[j] == 'R' && !baned[j])
                            {
                                baned[j] = true;
                                countR--;
                                break;
                            }
                            j++;
                        }
                    }
                }

                i++;
            }

            return countD > countR ? "Dire" : "Radiant";


        }
    }
}
