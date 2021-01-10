using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _02__239
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", MaxSlidingWindow(new[] {1, 3, -1, -3, 5, 3, 6, 7}, 3)));

        }
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            LinkedList<int> q = new LinkedList<int>();
            int[] res = new int[nums.Length - k + 1];
            for (int i = 0; i < nums.Length; i++)
            {
                if (q.Count > 0 && q.First.Value + k <= i)
                {
                    q.RemoveFirst();
                }
                while (q.Count > 0 && nums[q.Last.Value] <= nums[i])
                {
                    q.RemoveLast();
                }
                q.AddLast(i);
                if (i - k + 1 >= 0)
                {
                    res[i - k + 1] = nums[q.First.Value];
                }
            }
            return res;
        }
    }
    
}
