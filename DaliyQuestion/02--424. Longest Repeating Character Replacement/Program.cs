using System;

namespace _02__424._Longest_Repeating_Character_Replacement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CharacterReplacement("AABABBA",1));
        }

        public static int CharacterReplacement(string s, int k)
        {
            int[] nums = new int[26];
            int res = 0;
            int left = 0, right = 0;
            while (right < s.Length)
            {
                int index = s[right] - 'A';
                nums[index]++;
                res = Math.Max(res, nums[index]);
                if (right - left + 1 - res > k)
                {
                    nums[s[left]-'A']--;
                    left++;
                }
                right++;
            }
            return right - left;

        }
    }
}
