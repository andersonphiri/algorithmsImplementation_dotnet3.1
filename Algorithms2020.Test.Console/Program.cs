using Algorithms2020.CustomHeap;
using Algorithms2020.CustomLists;
using Algorithms2020.CustomQueue;
using FibonacciDynamic;
using System;

namespace Algorithms2020.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci fibonacci = new Fibonacci(9);
            System.Console.WriteLine($"Fib 9 is :{Fibonacci.Fib(9)}");
            System.Console.WriteLine($"Fib 9 is :{fibonacci.ComputeFib()}");
            SimpleQueueGeneric<string> simpleQueue = new SimpleQueueGeneric<string>(2,2);
            simpleQueue.Enqueue("item1");
            simpleQueue.Enqueue("item2");
            simpleQueue.Enqueue("item3");
            simpleQueue.Enqueue("item4");
            simpleQueue.Enqueue("item5");
            simpleQueue.Enqueue("item6");
            simpleQueue.PrintQueue();
            var item = simpleQueue.Dequeue();
            System.Console.WriteLine($"Dequeued item is: {item}");
            SingleLinkedListCustom<int> single = new SingleLinkedListCustom<int>();
            single.InsertDefault(20);
            single.InsertBegining(25);
            single.PrintLinkedList();
            var heapTestArray = new int[] { 4, 9, 1, 7, 5, 3 };
            MaxHeap<int> heap = new CustomHeap.MaxHeap<int>(heapTestArray);
            System.Console.WriteLine($"The Max Heap is:");
            heap.PrintHeap();
            heap.DeleteItem(0);
            heap.PrintHeap();
            MinHeap<int> minHeap = new MinHeap<int>(heapTestArray);
            System.Console.WriteLine($"The Min Heap is:");
            minHeap.PrintHeap();
            minHeap.DeleteItem(0);
            minHeap.PrintHeap();

            var sortedAscending = HeapSortCustom<int>.SortAscending(heapTestArray);
            var sortDesc = HeapSortCustom<int>.SortDescending(heapTestArray);

            var sortedAscendingFromSpan = HeapSortCustom<int>.SortAscending(heapTestArray.AsSpan());
            var sortDescFromSpan = HeapSortCustom<int>.SortDescending(heapTestArray.AsSpan());

            var sortedName = HeapSortCustom<char>.SortDescending("aanderson");

            

            System.Console.ReadLine();
        }
    }
}
