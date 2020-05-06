using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace K_Closest_Points_to_Origin
{
    class Program
    {
        /*
            973. 最接近原点的 K 个点
            我们有一个由平面上的点组成的列表 points。需要从中找出 K 个距离原点 (0, 0) 最近的点。
            
            （这里，平面上两点之间的距离是欧几里德距离。）
            
            你可以按任何顺序返回答案。除了点坐标的顺序之外，答案确保是唯一的。
           
            示例 1：
            
            输入：points = [[1,3],[-2,2]], K = 1
            输出：[[-2,2]]
            解释： 
            (1, 3) 和原点之间的距离为 sqrt(10)，
            (-2, 2) 和原点之间的距离为 sqrt(8)，
            由于 sqrt(8) < sqrt(10)，(-2, 2) 离原点更近。
            我们只需要距离原点最近的 K = 1 个点，所以答案就是 [[-2,2]]。
            示例 2：
            
            输入：points = [[3,3],[5,-1],[-2,4]], K = 2
            输出：[[3,3],[-2,4]]
            （答案 [[-2,4],[3,3]] 也会被接受。）
                        
            提示：           
            1 <= K <= points.length <= 10000
            -10000 < points[i][0] < 10000
            -10000 < points[i][1] < 10000
         */
        static void Main(string[] args)
        {
            int[][] x = { new int[] { 1, 3 }, new int[] { -2, 2 } };
            int[][] y = { new int[] { 3, 3 }, new int[] { 5, -1 }, new int[] { -2, 4 } };
            int[][] z = {new int[] {0, 1}, new int[] {1, 0}};
            int kx = 1, ky = 2, kz=2;
            int[][] res1 = KClosest(x, kx);
            int[][] res2 = KClosest(y, ky);
            int[][] res3 = KClosest(z, kz);
            foreach(var point   in res1)
            {
                Console.Write("[");
                foreach (var item in point)
                {
                    Console.Write(item + ",");
                }
                Console.Write("]");
            }

            Console.WriteLine();
            foreach (var point in res2)
            {
                Console.Write("[");
                foreach (var item in point)
                {
                    Console.Write(item + ",");
                }
                Console.Write("]");
            }

            Console.WriteLine();

            Console.WriteLine("-------------------------");
            foreach (var point in res3)
            {
                Console.Write("[");
                foreach (var item in point)
                {
                    Console.Write(item+",");
                }
                Console.Write("]");
            }
        }

        public static  int[][] points;
        public static int[][] KClosest(int[][] points, int K)
        {
            Program.points = points;
            int[][] res=new int[K][];
            Work(0,Program.points.Length-1,K);
            Array.ConstrainedCopy(Program.points,0,res,0,K);
            return res;
        }

        public static void Work(int i, int j, int K)
        {
            if (i>=j)
            {
                return;
            }
            Random r=new Random();
            int oi = i, oj = j;
            double pivot = EuclideanDistance(r.Next(i, j));

            while (i<j)
            {
                while (i<j&&EuclideanDistance(i)<pivot)
                {
                    i++;
                }

                while (i<j&&EuclideanDistance(j)>pivot)
                {
                    j--;
                }
                //官方分治法未考虑存在距离相同但不一致的点，经调试及评论区提醒修改
                if (EuclideanDistance(i)==pivot&&EuclideanDistance(j)==pivot)
                {
                    break;
                }
                Swap(i,j);
            }

            if (K<=i-oi+1)
            {
                Work(oi,i,K);
            }
            else
            {
                Work(i+1,oj,K-(i-oi+1));
            }
        }

        public static double EuclideanDistance(int i)
        {
            return Math.Sqrt(points[i][0] * points[i][0] + points[i][1] * points[i][1]);
        }

        public static void Swap(int i, int j)
        {
            int t0 = points[i][0], t1 = points[i][1];
            points[i][0] = points[j][0];
            points[i][1] = points[j][1];
            points[j][0] = t0;
            points[j][1] = t1;
        }
    }
}
