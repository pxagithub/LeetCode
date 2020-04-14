using System;

namespace MedianOfTwoSortedArrays
{
    /*
    4.寻找两个有序数组的中位数
    给定两个大小为 m 和 n 的有序数组 nums1 和 nums2。

    请你找出这两个有序数组的中位数，并且要求算法的时间复杂度为 O(log(m + n))。

    你可以假设 nums1 和 nums2 不会同时为空。

    示例 1:
    nums1 = [1, 3]
    nums2 = [2]    
    则中位数是 2.0
    示例 2:    
    nums1 = [1, 2]
    nums2 = [3, 4]
    则中位数是 (2 + 3)/2 = 2.5
     */
    class Program
    {
        static void Main(string[] args)
        {
            //example 1
            int[] x1 = {1, 3};
            int[] x2 = {2};
            //example 2
            int[] y1 = {1, 2};
            int[] y2 = {3, 4};

            Console.WriteLine(FindMedianSortedArrays(x1,x2));
            Console.WriteLine(FindMedianSortedArrays(y1,y2));
        }

        //public static double FindMedianSortedArrays(int[] a, int[] b)
        //{
        //    int m = a.Length;
        //    int n = b.Length;
        //    if (m > n)
        //    {
        //        int[] temp = a;
        //        a = b;
        //        b = temp;
        //        int tmp = m;
        //        m = n;
        //        n = tmp;
        //    }

        //    int iMin = 0, iMax = m, halfLen = (m + n + 1) / 2;
        //    while (iMin<=iMax)
        //    {
        //        int i = (iMin + iMax) / 2;
        //        int j = halfLen - i;
        //        if (i<iMax&&b[j-1]>a[i])
        //        {
        //            iMin = i + 1;//i is too small   
        //        }
        //        else if (i>iMin&&a[i-1]>b[j])
        //        {
        //            iMax = i - 1;
        //        }
        //        else
        //        {
        //            int maxLeft = 0;
        //            if (i==0) maxLeft = b[j - 1];
                    
        //            else if (j==0) maxLeft = a[i - 1];
                    
        //            else maxLeft = Math.Max(a[i - 1], b[j - 1]);

        //            if ((m + n) % 2 == 1) return maxLeft;

        //            int minRight = 0;
        //            if (i == m) minRight = b[j];
        //            else if (j == n) minRight = a[i];
        //            else minRight = Math.Min(b[j], a[i]);
        //            return (maxLeft + minRight) / 2.0;
        //        }
        //    }

        //    return 0.0;


        //}

        public static double FindMedianSortedArrays(int[] a, int[] b)
        {
            int m = a.Length;
            int n = b.Length;
            if (m>n)
            {
                int[] temp = a;
                a = b;
                b = temp;
                int tmp = m;
                m = n;
                n = tmp;
            }

            int iMin = 0, iMax = m, halfLen = (m + n + 1) / 2;
            while (iMin<=iMax)
            {
                int i = (iMin + iMax) / 2;
                int j = halfLen - i;

                if (i > iMin && a[i-1]>b[j])
                {
                    iMax = i - 1;
                    
                }
                else if (i < iMax && b[j - 1] > a[i])
                {
                    iMin = i + 1;
                    
                }
                else
                {
                    int maxLeft = 0;
                    if (i == 0) maxLeft = b[j - 1];
                    else if (j == 0) maxLeft = a[i - 1];
                    else maxLeft = Math.Max(a[i - 1], b[j - 1]);


                    int minRight = 0;
                    if (i == m) minRight = b[j];
                    else if (j == n) minRight = a[i];
                    else minRight = Math.Min(a[i], b[j]);

                    if ((m+n)%2==1)
                    {
                        return maxLeft;
                    }
                    else
                    {
                            return (maxLeft+minRight) / 2.0;
                    }
                }

            }

            return 0.0;
        }

        
    }
}
