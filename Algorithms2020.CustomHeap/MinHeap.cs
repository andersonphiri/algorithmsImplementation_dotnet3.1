using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms2020.CustomHeap
{
    public class MinHeap<T>  : HeapBase<T> where T : IComparable<T>, new ()
    {
        
        public MinHeap(int size) : base(size)
        {
            heap = new T[size + 1];
            heapSize = 0;
        }
        public MinHeap(T [] items) : base(items)
        {
            heapSize = 0;
            heap = null;
            CreateHeapfiedFromArray(items);
        }

        public MinHeap(ReadOnlySpan<T> items):base(items)
        {
            heapSize = 0;
            heap = null;
            CreateHeapfiedFromArray(items.ToArray());
        }

        protected override void CreateHeapfiedFromArray(T[] mayOrMayNotBeHeapiefiedArray)
        {
            heap = new T[mayOrMayNotBeHeapiefiedArray.Length + 1];
            for (int i = 0; i < mayOrMayNotBeHeapiefiedArray.Length; i++)
            {
                InsertItem(mayOrMayNotBeHeapiefiedArray[i]);
            }
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

        public override  T DeleteItem(int index)
        {
            if (IsEmpty())
            {
                throw new ImpossibleOperationException("Error!!!. this heap is empty. ");
            }
            index = CheckThisIndex(index);
            T itemToBeDeleted = heap[index];
            // replace this node with the last node
            heap[index] = heap[heapSize - 1];
            heapSize--;
            HeapifyDown(index);


            return itemToBeDeleted;

        }


        /// <summary>
        /// use this method when deleting from the heap because when deleting 
        /// you swap current index with the last index in the array
        /// </summary>
        /// <param name="index"></param>
        protected  void HeapifyDown(int index)
        {
            T currentNode = heap[index];
            int minChildIndex ;
            while (KthChild(index,1) < heapSize
                //index<heapSize&&currentNode.CompareTo(heap[minChildIndex])>0
                )
            {

                minChildIndex = MinChildIndex(index);
                if (currentNode.CompareTo(heap[minChildIndex]) > 0)
                {
                    //then swap the two
                    heap[index] = heap[minChildIndex];
                }
                else
                {
                    break;
                }
                
               
                index = minChildIndex;
            }
            // this is the last index down the heap after successive swapping
            heap[index] = currentNode;
        }
       
        /// <summary>
        /// Run this method with Insert since you insert at the end of the array
        /// </summary>
        /// <param name="index"></param>
        protected  void HeapifyUp(int index)
        {
            T temp = heap[index];
            //keep swapping going up until as long as this node is lessa than the parent
            while (index > 0 && temp.CompareTo(heap[ParentIndex(index)]) < 0)
            {
                heap[index] = heap[ParentIndex(index)];
                index = ParentIndex(index);
            }

            heap[index] = temp;
        }
        protected int MinChildIndex(int currentIndex)
        {
            int leftChildIndex = KthChild(currentIndex, 1);
            int rightChildIndex = KthChild(currentIndex, 2);

            return heap[leftChildIndex].CompareTo(heap[rightChildIndex]) < 0 ? leftChildIndex : rightChildIndex;
        }
        public T GetMinElement() => heap[0];

    
    }
    

}
