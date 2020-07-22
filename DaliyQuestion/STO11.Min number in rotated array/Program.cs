using System;

namespace STO11.Min_number_in_rotated_array
{
    class Program
    {
        /*剑指 Offer 11. 旋转数组的最小数字
           把一个数组最开始的若干个元素搬到数组的末尾，我们称之为数组的旋转。输入一个递增排序的数组的一个旋转，输出旋转数组的最小元素。例如，数组 [3,4,5,1,2] 为 [1,2,3,4,5] 的一个旋转，该数组的最小值为1。  
           
           示例 1：
           
           输入：[3,4,5,1,2]
           输出：1
           示例 2：
           
           输入：[2,2,2,0,1]
           输出：0*/
        static void Main(string[] args)
        {
            int[] x = {1,3,3,3};
            int[] y = {2, 2, 2, 0, 1};
            int[] z = {5,3,1};
            Console.WriteLine(string.Join(",",MinArray(x),MinArray(y),MinArray(z)));
        }

        public static int MinArray(int[] numbers)
        {
            int low = 0;
            int high = numbers.Length - 1;
            if (numbers.Length==2)
            {
                return Math.Min(numbers[0], numbers[1]);
            }
            while (low<high)
            {
                int mid = (low + high) / 2;
                
                
                    if (numbers[mid] == numbers[high])
                    {
                        high--;
                    }
                    if (numbers[mid]>numbers[high])
                    {
                        low = mid+1;
                    }

                    if (numbers[mid] < numbers[high])
                    {
                        high = mid;
                    }
                
            }

            return numbers[low];
        }
    }
}
