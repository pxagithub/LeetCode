using System;
using System.Collections.Generic;
using System.Linq;

namespace Second
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = {1, 11, 22, 33, 44, 55, 66, 77, 88, 99};
            int[] arr1 = { 2, 1, 3, 5, 4, 6, 7 };
            Console.WriteLine(GetWinner(arr, 1000000000));//99
            Console.WriteLine(GetWinner(arr1,2));//5
        }
        public static int GetWinner(int[] arr, int k)
        {
            int i = 0, t = 0;
            while (t<k&&i<arr.Length-1)
            {
                if (arr[i]>arr[i+1])
                {
                    arr[i + 1] = arr[i];
                    ++t;
                }
                else
                {
                    t = 1;
                }

                ++i;
            }

            return arr[i];

        }

        public static void Move(ref int[] arr, int i)
        {
            int temp = arr[i];

            List<int> list=arr.ToList();

            list.RemoveAt(i);
            list.Add(temp);

            arr = list.ToArray();
        }
    }
}
