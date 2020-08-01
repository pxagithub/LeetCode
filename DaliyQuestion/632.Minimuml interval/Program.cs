using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _632.Minimuml_interval
{
    class Program
    {
        /*632. 最小区间
           你有 k 个升序排列的整数数组。找到一个最小区间，使得 k 个列表中的每个列表至少有一个数包含在其中。
           我们定义如果 b-a < d-c 或者在 b-a == d-c 时 a < c，则区间 [a,b] 比 [c,d] 小。
           示例 1:
           输入:[[4,10,15,24,26], [0,9,12,20], [5,18,22,30]]
           输出: [20,24]
           解释: 
           列表 1：[4, 10, 15, 24, 26]，24 在区间 [20,24] 中。
           列表 2：[0, 9, 12, 20]，20 在区间 [20,24] 中。
           列表 3：[5, 18, 22, 30]，22 在区间 [20,24] 中。
           注意:
           给定的列表可能包含重复元素，所以在这里升序表示 >= 。
           1 <= k <= 3500
           -105 <= 元素的值 <= 105
           对于使用Java的用户，请注意传入类型已修改为List<List<Integer>>。重置代码模板后可以看到这项改动。*/
        static void Main(string[] args)
        {
            IList<IList<int>> x = new List<IList<int>>()
            {
                new List<int>() {4, 10, 15, 24, 26},
                new List<int>() {0, 9, 12, 20},
                new List<int>() {5, 18, 22, 30}
            };
            IList<IList<int>> y = new List<IList<int>>()
            {
                new List<int>() {1,2,3},
                new List<int>() {1,2,3},
                new List<int>() {1,2,3}
            };
            Console.WriteLine(string.Join(",", SmallestRange(x)));
            Console.WriteLine(string.Join(",", SmallestRange(y)));

        }
        //暴力解法超时
        public static int[] SmallestRange(IList<IList<int>> nums)
        {
            Dictionary<int,int[]> dic=new Dictionary<int, int[]>();
            int min=Int32.MaxValue;
            int[] length=new int[nums.Count];
            int[] index=new int[nums.Count];
            for (int i = 0; i < nums.Count; i++)
            {
                length[i] = nums[i].Count - 1;
            }
            List<int> range=new List<int>(nums.Count);
            for (int i = 0; i < nums.Count; i++)
            {
                range.Add(nums[i][index[i]]);
            }
            int guard = 0;
            while (true)
            {
                int extremum = range.Max() - range.Min();
                
                if (extremum<min)
                {
                    dic.Add(extremum,new []{range.Min(),range.Max()});
                    min = extremum;
                }
                
                int temp = range.FindIndex(value => value.Equals(range.Min()));
                index[temp] += 1;
                if (index[temp] > length[temp]) break;
                range[temp] = nums[temp][index[temp]];
                
            }

            return dic[min];

        }
       
        
        /// <summary>
        /// 堆+优先队列
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] Heap(IList<IList<int>> nums)
        {
            //定义临时最小值最大值
            int minx = 0, miny = Int32.MaxValue, max = Int32.MinValue;
            //存放每个数组指针进行到的位数
            int[] next = new int[nums.Count];
            //控制跳出循环
            bool flag = true;
            //优先队列
            PriorityQueue<Int32> min_queue = new PriorityQueue<int>(new CP<int>((i, j) => nums[j][next[j]] - nums[i][next[i]]));

            for (int i = 0; i < nums.Count; i++)
            {
                min_queue.Push(i);
                max = Math.Max(max, nums[i][0]);
            }

            for (int i = 0; i < nums.Count && flag; i++)
            {
                for (int j = 0; j < nums[i].Count; j++)
                {
                    //从优先队列中取出最小值对应的序列号
                    int min_i = min_queue.Pop();
                    //如果差值小于miny-minx，则更新miny和minx的值
                    if (miny - minx > max - nums[min_i][next[min_i]])
                    {

                        minx = nums[min_i][next[min_i]];
                        miny = max;
                    }
                    //最小值所在的数组右移一位
                    next[min_i]++;
                    //右移之后如果超出数组长度则跳出循环
                    if (next[min_i] == nums[min_i].Count)
                    {
                        flag = false;
                        break;
                    }

                    min_queue.Push(min_i);
                    max = Math.Max(max, nums[min_i][next[min_i]]);

                }
            }
            return new int[] { minx, miny };
        }


        /// <summary>
        /// 哈希+滑动窗口
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public static int[] HashAndSlideTable(IList<IList<int>> nums)
        {
            int len = nums.Count;
            Dictionary<int, List<int>> indices=new Dictionary<int, List<int>>();

            int xMin = Int32.MaxValue, xMax = Int32.MinValue;
            for (int i = 0; i < len; i++)
            {
                foreach (var x in nums[i])
                {
                    List<int> list = indices.GetValueOrDefault(x, new List<int>());
                    list.Add(i);
                    if (!indices.ContainsKey(x))
                    {
                        indices.Add(x, list);
                    }
                    xMin = Math.Min(xMin, x);
                    xMax = Math.Max(xMax, x);
                }
            }

            int[] freq = new int[len];
            int inside = 0;
            int left = xMin, right = xMin - 1;
            int bestLeft = xMin, bestRight = xMax;

            while (right<xMax)
            {
                right++;
                if (indices.ContainsKey(right))
                {
                    foreach (var x in indices[right])
                    {
                        freq[x]++;
                        if (freq[x]==1)
                        {
                            inside++;
                        }
                    }

                    while (inside==len)
                    {
                        if (right-left<bestRight-bestLeft)
                        {
                            bestRight = right;
                            bestLeft = left;
                        }

                        if (indices.ContainsKey(left))
                        {
                            foreach (var x in indices[left])
                            {
                                freq[x]--;
                                if (freq[x]==0)
                                {
                                    inside--;
                                }
                            }
                        }

                        left++;
                    }
                }
            }
            return new int[]{bestLeft,bestRight};
        }

    }
    class CP<T> : IComparer<T>
    {
        Comparison<T> a;
        public CP(Comparison<T> _temp)
        {
            a = _temp;
        }
        public int Compare(T x, T y)
        {
            return a(x, y);
        }
    }


    class PriorityQueue<T>
    {
        IComparer<T> comparer;
        T[] heap;

        public int Count { get; private set; }

        public PriorityQueue() : this(null) { }
        public PriorityQueue(int capacity) : this(capacity, null) { }
        // public PriorityQueue(IComparer<T> comparer) : this(3500, comparer) { }
        public PriorityQueue(IComparer<T> comparer) : this(3500, comparer) { }

        public PriorityQueue(int capacity, IComparer<T> comparer)
        {
            this.comparer = (comparer == null) ? Comparer<T>.Default : comparer;
            this.heap = new T[capacity];
        }

        public void Push(T v)
        {
            if (Count >= heap.Length) Array.Resize(ref heap, Count * 2);
            heap[Count] = v;
            SiftUp(Count++);
        }

        public T Pop()
        {
            var v = Top();
            heap[0] = heap[--Count];
            if (Count > 0) SiftDown(0);
            return v;
        }

        public T Top()
        {
            if (Count > 0) return heap[0];
            throw new InvalidOperationException("优先队列为空");
        }

        void SiftUp(int n)
        {
            var v = heap[n];
            for (var n2 = n / 2; n > 0 && comparer.Compare(v, heap[n2]) > 0; n = n2, n2 /= 2) heap[n] = heap[n2];
            heap[n] = v;
        }

        void SiftDown(int n)
        {
            var v = heap[n];
            for (var n2 = n * 2; n2 < Count; n = n2, n2 *= 2)
            {
                if (n2 + 1 < Count && comparer.Compare(heap[n2 + 1], heap[n2]) > 0) n2++;
                if (comparer.Compare(v, heap[n2]) >= 0) break;
                heap[n] = heap[n2];
            }
            heap[n] = v;
        }
    }



}
