using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Principal;

namespace DataStructLibrary
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int x)
        {
            val = x;
        }
    }

    public enum HeapType
    {
        MinHeap,
        MaxHeap
    }

    public class BinaryHeap<T> where T : IComparable<T>
    {
        private List<T> items;

        public HeapType HType { get; private set; }

        public T Root
        {
            get { return items[0]; }
        }

        public BinaryHeap(HeapType type)
        {
            items = new List<T>();
            this.HType = type;
        }

        public void Push(T item)
        {
            items.Add(item);
            int i = items.Count - 1;
            bool flag = HType == HeapType.MinHeap;

            while (i > 0)
            {
                if ((items[i].CompareTo(items[(i - 1) / 2]) > 0) ^ flag)
                {
                    T temp = items[i];
                    items[i] = items[(i - 1) / 2];
                    items[(i - 1) / 2] = temp;
                    i = (i - 1) / 2;
                }
                else
                {
                    break;
                }
            }
        }

        private void DeleteRoot()
        {
            int i = items.Count - 1;

            items[0] = items[i];
            items.RemoveAt(i);

            i = 0;

            bool flag = HType == HeapType.MinHeap;

            while (true)
            {
                int leftInd = 2 * i + 1;
                int rightInd = 2 * i + 2;
                int largest = i;

                if (leftInd<items.Count)
                {
                    if ((items[leftInd].CompareTo(items[largest]) > 0) ^ flag)
                    {
                        largest = leftInd;
                    }
                }

                if (rightInd < items.Count)
                {
                    if ((items[rightInd].CompareTo(items[largest]) > 0) ^ flag)
                    {
                        largest = rightInd;
                    }
                }

                if (largest!=i)
                {
                    T temp = items[largest];
                    items[largest] = items[i];
                    items[i] = temp;
                    i = largest;
                }
                else
                {
                    break;
                }
            }
        }

        public T PopRoot()
        {
            T result = items[0];
            DeleteRoot();
            return result;
        }
    }

    public class PriorityQueue<T>
    {
        private IComparer<T> comparer;
        private T[] heap;

        public int Count { get; private set; }

        public PriorityQueue() : this(null) { }

        public PriorityQueue(int capacity) : this(capacity, null) { }

        public PriorityQueue(IComparer<T> comparer) : this(16, comparer) { }

        public PriorityQueue(int capacity, IComparer<T> comparer)
        {
            this.comparer = (comparer == null) ? Comparer<T>.Default : comparer;
            this.heap = new T[capacity];
        }

        public void Push(T v)
        {
            if (Count>=heap.Length)
            {
                Array.Resize(ref heap, Count * 2);
                heap[Count] = v;
                SiftUp(Count++);
            }
        }

        public T Pop()
        {
            var v = Top();
            heap[0] = heap[--Count];
            if (Count>0)
            {
                SiftDown(0);
            }

            return v;
        }

        public T Top()
        {
            if (Count>0)
            {
                return heap[0];
            }
            throw new InvalidOperationException("PriorityQueue is empty");
        }

        void SiftUp(int n)
        {
            var v = heap[n];
            for (var n2 = n / 2; n > 0 && comparer.Compare(v, heap[n2]) > 0; n = n2, n2 /= 2)
            {
                heap[n] = heap[n2];
            }

            heap[n] = v;
        }

        void SiftDown(int n)
        {
            var v = heap[n];
            for (var n2 = n * 2; n2 < Count; n = n2, n2 *= 2)
            {
                if (n2 + 1 < Count && comparer.Compare(heap[n2 + 1], heap[n2]) > 0)
                {
                    n2++;
                }

                if (comparer.Compare(v, heap[n2]) >= 0) 
                {
                    break;
                }

                heap[n] = heap[n2];
            }

            heap[n] = v;
        }
    }
}
