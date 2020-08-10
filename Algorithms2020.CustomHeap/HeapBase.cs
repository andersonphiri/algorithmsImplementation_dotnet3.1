using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Algorithms2020.CustomHeap
{
    public  class HeapBase<T> where T: IComparable<T>
    {
        protected readonly int _d = 2;
        protected int heapSize;
        protected T[] heap;
        protected ArrayList heap2 = new ArrayList();

        public HeapBase(int size)
        {
            heap = new T[size + 1];
            heapSize = 0;

        }


        public HeapBase(T [] items)
        {
            
        }

        public HeapBase(ReadOnlySpan<T> items)
        {
            
        }

        protected virtual void CreateHeapfiedFromArray(T[] mayOrMayNotBeHeapiefiedArray)
        {
            throw new NotImplementedException($"Error: Subclass did not implement this method: {nameof(CreateHeapfiedFromArray)}. Please Check");
        }

        public virtual void InsertItem(T item)
        {
            throw new NotImplementedException($"Error: Subclass did not implement this method: {nameof(InsertItem)}. Please Check");

        }

        public virtual T DeleteItem(int index)
        {
            throw new NotImplementedException($"Error: Subclass did not implement this method: {nameof(DeleteItem)}. Please Check");

        }


        public bool IsEmpty() => heapSize == 0;
        public bool IsFull() => heapSize == heap.Length;
        public int GetHeapCount() => heapSize;
        protected int ParentIndex(int currentIndex) => (currentIndex - 1) / _d;
        protected int KthChild(int curentIndex, int k) => _d * curentIndex + k;

        public void PrintHeap()
        {
            Console.WriteLine();
            if (IsEmpty())
            {
                Console.WriteLine("No elemets to print, your heap is empty");
            }
            else
            {
                for (int i = 0; i < heapSize; i++)
                {
                    Console.Write($"{heap[i]}   ");
                }
            }
            Console.WriteLine();
        }

        public T[] GetAllElements() => heap;
        protected int CheckThisIndex(int index) => (index < heapSize, index >= 0) switch
        {
            (true, true) => index,
            (_, _) => throw new IndexOutOfRangeException($"Error: your index value of {index} is not in accepted range"),

        };



    }
}
