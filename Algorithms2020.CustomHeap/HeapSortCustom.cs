using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms2020.CustomHeap
{
    public class HeapSortCustom<T> where T: IComparable<T>, new()
    {
        
        private HeapBase<T> _heap;
        private HeapType _heapType;
        public HeapSortCustom(HeapBase<T> heap)
        {
            _heap = heap;
        }

        public HeapSortCustom(T[] itemsToSort, HeapType heapType)
        {

            SetProperties(itemsToSort, heapType);
        }
        private void SetProperties(T[] itemsToSort, HeapType heapType)
        {
            _heapType = heapType;
            switch (_heapType)
            {
                case HeapType.MaxHeap:
                    _heap = new MaxHeap<T>(itemsToSort);
                    break;

                case HeapType.MinHeap:
                    _heap = new MinHeap<T>(itemsToSort);
                    break;

                default:
                    break;
            }
        }


        public static T[] SortDescending(T[] unsortedArray)
        {
            var heap = new MaxHeap<T>(unsortedArray);
            return SortFromMaxHeapDescending(heap);
        }

        public static T[] SortDescending(ReadOnlySpan<T> unsortedArray)
        {
            var heap = new MaxHeap<T>(unsortedArray);
            return SortFromMaxHeapDescending(heap);
        }

        public static T[] SortAscending(T[] unsortedArray)
        {
            var minHeap = new MinHeap<T>(unsortedArray);
            return SortFromMinHeapAscending(minHeap);
        }

        public static T[] SortAscending(ReadOnlySpan<T> unsortedArray)
        {
            var minHeap = new MinHeap<T>(unsortedArray);
            return SortFromMinHeapAscending(minHeap);
        }

        /// <summary>
        /// Sort Ascending then find media. Haha!!!
        /// </summary>
        /// <returns></returns>
        //public static T FindMedian(T[] inputArray)
        //{

        //}


        private static T[] SortFromMaxHeapDescending(MaxHeap<T> maxHeap)
        {
            T[] elementsToSort =  new T[maxHeap.GetHeapCount()] ;
            
            int startIndex = 0;
            while (!maxHeap.IsEmpty())
            {
                elementsToSort[startIndex] = maxHeap.DeleteItem(0);
                startIndex++;
            }

            return elementsToSort;
        }

       

        private static T[] SortFromMinHeapAscending(MinHeap<T> minHeap)
        {
            T[] elementsToSort = new T[minHeap.GetHeapCount()];

            int startIndex = 0;
            while (!minHeap.IsEmpty())
            {
                elementsToSort[startIndex] = minHeap.DeleteItem(0);
                startIndex++;
            }

            return elementsToSort;
        }
    }
}
