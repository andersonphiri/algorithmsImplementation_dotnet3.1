using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms2020.CustomHeap
{
    /// <summary>
    /// Max heap property: the root node is greater or equal to any leaf below
    /// Start with the element, i given by the index n/2 - 1, and the left value is given by 2i+1, and the right child is 2i+2
    /// if left child is greater than element at index i, set largestElement= left child
    /// else if right child is greater than element at index i, set largest = right chils
    /// 
    /// </summary>
  

    public class MaxHeap<T> : HeapBase<T> where T : IComparable<T>, new()
    {
        public MaxHeap(int size) : base(size)
        {
        }

        public MaxHeap(ReadOnlySpan<T> items) : base(items)
        {
            CreateHeapfiedFromArray(items.ToArray());
        }

        public MaxHeap(T[] mayOrMayNotBeHeapiefiedArray) : base(mayOrMayNotBeHeapiefiedArray)
        {
            heapSize = 0;
            this.CreateHeapfiedFromArray(mayOrMayNotBeHeapiefiedArray);
        }
        public void CreatHeapFromArray(T[] inputArray)
        {
            CreateHeapfiedFromArray(inputArray);
        }

        protected override  void CreateHeapfiedFromArray(T[] mayOrMayNotBeHeapiefiedArray)
        {
            heap = new T[mayOrMayNotBeHeapiefiedArray.Length+ 1];
            for (int i = 0; i < mayOrMayNotBeHeapiefiedArray.Length; i++)
            {
                InsertItem(mayOrMayNotBeHeapiefiedArray[i]);
            }
        }

        

        //public static bool operator >(MaxHeap<T> left, MaxHeap<T> right) => Comparer<MaxHeap<T>>.Default.Compare(left, right) > 0;
        //public static bool operator <(MaxHeap<T> left, MaxHeap<T> right) => Comparer<MaxHeap<T>>.Default.Compare(left, right) < 0;

        //public override static bool operator >=(MinHeap<T> left, MinHeap<T> right) => Comparer<MinHeap<T>>.Default.Compare(left, right) >= 0;
        //public static bool operator <=(MinHeap<T> left, MinHeap<T> right) => Comparer<MinHeap<T>>.Default.Compare(left, right) <= 0;

        ///public static bool operator ==(MaxHeap<T> left, MaxHeap<T> right) => Comparer<MaxHeap<T>>.Default.Compare(left, right) == 0;
        //public static bool operator !=(MaxHeap<T> left, MaxHeap<T> right) => Comparer<MaxHeap<T>>.Default.Compare(left, right) != 0;


        /// <summary>
        /// This method is used when inserting an element
        /// </summary>
        /// <param name="index"></param>
        protected virtual void HeapifyUp(int index)
        {
            T temp = heap[index];

            //if current node value is not root node and current node value is greater than Parent node value
            // then swap this with parent i.e this node becomes parent and parent becomes this node
            while (index > 0 && temp.CompareTo(heap[ParentIndex(index)]) >= 0)
            {
                heap[index] = heap[ParentIndex(index)];
                index = ParentIndex(index);

            }
            heap[index] = temp;
        }

        /// <summary>
        /// use this method when deleting an element
        /// </summary>
        /// <param name="index"></param>
        protected virtual void HeapifyDown(int index)
        {
            int maxChildIndex;
            T temp = heap[index];
            while (KthChild(index, 1) < heapSize)
            {
                maxChildIndex = MaxChildIndex(index);

                // if current node is less that any of its children. then swap this node with that child 
                // therefore this is a max heap property
                if (temp.CompareTo(heap[maxChildIndex]) < 0)
                {
                    heap[index] = heap[maxChildIndex];
                }
                else
                {
                    break;
                }
                //then go to the next max chil and make it parent
                index = maxChildIndex;
            }
            heap[index] = temp;

        }

        protected int MaxChildIndex(int currentIndex)
        {
            int leftChildIndex = KthChild(currentIndex, 1);
            int rightChildIndex = KthChild(currentIndex, 2);
            return heap[leftChildIndex].CompareTo(heap[rightChildIndex]) >= 0 ? leftChildIndex : rightChildIndex;
        }


        public override void InsertItem(T item)
        {
            if (IsFull())
            {
                throw new ImpossibleOperationException("operation is impossible because the heap is full. Kind regards");
            }
            heap[heapSize++] = item;
            HeapifyUp(heapSize - 1);
        }

        public override T DeleteItem(int index)
        {
            if (IsEmpty())
            {
                throw new ImpossibleOperationException("Error!!!. this heap is empty. ");
            }
             index = CheckThisIndex(index);
            T itemToBeDeleted = heap[index];
            // replace this node with the last node
            heap[index] = heap[heapSize-1];
            heapSize--;
            HeapifyDown(index);


            return itemToBeDeleted;

        }

        public T GetMaxElement() => heap[0];


        

    }


}
