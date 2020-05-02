using System;
using System.Linq.Expressions;

namespace SearchA2DMatrixII
{
    /*
     240. 搜索二维矩阵 II
       编写一个高效的算法来搜索 m x n 矩阵 matrix 中的一个目标值 target。该矩阵具有以下特性：
       
       每行的元素从左到右升序排列。
       每列的元素从上到下升序排列。
       示例:
       
       现有矩阵 matrix 如下：
       [
       [1,   4,  7, 11, 15],
       [2,   5,  8, 12, 19],
       [3,   6,  9, 16, 22],
       [10, 13, 14, 17, 24],
       [18, 21, 23, 26, 30]
       ]
       给定 target = 5，返回 true。
       
       给定 target = 20，返回 false。
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[,] x =
            {
                {1, 4, 7, 11, 15},
                {2, 5, 8, 12, 19},
                {3, 6, 9, 16, 22},
                {10, 13, 14, 17, 24},
                {18, 21, 23, 26, 30}
            };
            int[,] y = {{}};
            Console.WriteLine(SearchMatrix(y,-5));
            Console.WriteLine(SearchMatrix(x,5));
            Console.WriteLine(SearchMatrix(x, 20));

        }

        public static bool SearchMatrix(int[,] matrix, int target)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            if (m==0&&n==0)
            {
                return false;
            }
            for (int i = 0; i < m; i++)
            {
                if (target>matrix[i,n-1])
                {
                    continue;
                }

                if (target<matrix[i,0])
                {
                    break;
                }

                if (target==matrix[i,0])
                {
                    return true;
                }
                int res = BinarySearch(matrix, target, i);
                if (res!=-1)
                {
                    return true;
                }
            }
            return false;
        }

        public static int BinarySearch(int[,] matrix, int target, int i)
        {
            int m = matrix.GetLength(0);
            int n = matrix.GetLength(1);
            int res=-1;
            int low = 0;
            int high = n - 1;
            while (low<=high)
            {
                int halflen = (low + high) / 2;
                if (matrix[i,halflen]<target)
                {
                    low = halflen + 1;
                }
                else if (matrix[i,halflen]>target)
                {
                    high = halflen - 1;
                }
                else
                {
                    res = halflen;
                    break;
                }
            }
            return res;
        }
        
    }
}
