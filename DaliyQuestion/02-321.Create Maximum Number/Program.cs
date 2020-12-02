using System;

namespace _02_321.Create_Maximum_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(",", MaxNumber(new[] {3, 4, 6, 5}, new[] {9, 1, 2, 5, 8, 3}, 5)));
            Console.WriteLine(string.Join(",", MaxNumber(new[] {6, 7}, new[] {6, 0, 4}, 5)));
            Console.WriteLine(string.Join(",", MaxNumber(new[] {3, 9}, new[] {8, 9}, 3)));

        }

        public static int[] MaxNumber(int[] nums1, int[] nums2, int k)
        {
            int m = nums1.Length, n = nums2.Length;
            int[] maxSubsequence=new int[k];
            int start = Math.Max(0, k - n), end = Math.Min(k, m);
            for (int i = start; i <= end; i++)
            {
                int[] subsequence1 = MaxSubSequence(nums1, i);
                int[] subsequence2 = MaxSubSequence(nums2, k - i);
                int[] curMaxSubsequence = Merge(subsequence1, subsequence2);
                if (compare(curMaxSubsequence,0,maxSubsequence,0)>0)
                {
                    Array.Copy(curMaxSubsequence, maxSubsequence, k);
                }
            }

            return maxSubsequence;


        }

        public static int[] MaxSubSequence(int[] nums, int k)
        {
            int length = nums.Length;
            int[] stack = new int[k];
            int top = -1;
            int remain = length - k;
            for (int i = 0; i < length; i++)
            {
                int num = nums[i];
                while (top >= 0 && stack[top] < num && remain > 0)
                {
                    top--;
                    remain--;
                }

                if (top<k-1)
                {
                    stack[++top] = num;
                }
                else
                {
                    remain--;
                }
                
            }
            return stack;
        }

        public static int[] Merge(int[] subsequence1, int[] subsequence2)
        {
            int x = subsequence1.Length, y = subsequence2.Length;
            if (x==0)
            {
                return subsequence2;
            }
            if (y == 0)
            {
                return subsequence1;
            }
            int mergeLength = x + y;
            int[] merged = new int[mergeLength];
            int index1 = 0, index2 = 0;
            for (int i = 0; i < mergeLength; i++)
            {
                if (compare(subsequence1, index1, subsequence2, index2) > 0)
                {
                    merged[i] = subsequence1[index1++];
                }
                else
                {
                    merged[i] = subsequence2[index2++];
                }
            }
            return merged;

        }

        public static int compare(int[] subsequence1, int index1, int[] subsequence2, int index2)
        {
            int x = subsequence1.Length, y = subsequence2.Length;
            while (index1 < x && index2 < y)
            {
                int difference = subsequence1[index1] - subsequence2[index2];
                if (difference != 0)
                {
                    return difference;
                }
                index1++;
                index2++;
            }
            return (x - index1) - (y - index2);
        }
    }
}
