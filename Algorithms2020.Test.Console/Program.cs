using Algorithms2020.BinaryTree;
using Algorithms2020.CustomHeap;
using Algorithms2020.CustomLists;
using Algorithms2020.CustomQueue;
using FibonacciDynamic;
using GraphDataStructure;
using System;

namespace Algorithms2020.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //TopologicalSortAlgorithm();

            //TestBinaryTreeTraversal();
            TestBinarySearchTree();
            System.Console.ReadLine();
        }
        static void TestBinarySearchTree()
        {
            BinarySearchTree<int> binarySearchTree = new BinarySearchTree<int>();
            binarySearchTree.Insert(8);
            binarySearchTree.Insert(3);
            binarySearchTree.Insert(1);
            binarySearchTree.Insert(6);
            binarySearchTree.Insert(7);
            binarySearchTree.Insert(10);
            binarySearchTree.Insert(14);
            binarySearchTree.Insert(4);
            System.Console.WriteLine("inorder traversal");
            var s1=binarySearchTree.InorderTraversal();
            System.Console.WriteLine("inorder traversal completed");
            binarySearchTree.DeleteKey(10);
            System.Console.WriteLine("inorder traversal");
            var s2 = binarySearchTree.InorderTraversal();
            System.Console.WriteLine("inorder traversal completed");
        }
        static void TestBinaryTreeTraversal()
        {
            BinaryTree<int> btree = new BinaryTree<int>();
            btree.Root = new TreeNode<int>(1);
            btree.Root.Left = new TreeNode<int>(12);
            btree.Root.Right = new TreeNode<int>(9);
            btree.Root.Left.Left = new TreeNode<int>(5);
            btree.Root.Left.Right = new TreeNode<int>(6);
            //add the following node to make it a complete tree
            btree.Root.Right.Left = new TreeNode<int>(6);
            System.Console.WriteLine("inorder traversal");
            btree.InOrder(btree.Root);
            System.Console.WriteLine();
            System.Console.WriteLine("pre-order traversal");
            btree.PreOrder(btree.Root);
            System.Console.WriteLine();
            System.Console.WriteLine("post-order traversal");
            btree.PostOrder(btree.Root);
            System.Console.WriteLine();
            System.Console.WriteLine($"The Height of tree from root is: {btree.GetHeight(btree.Root)}");
            System.Console.WriteLine($"The Depth of root is: {btree.Depth(btree.Root)}");
            var numNodes = btree.CountNodes(btree.Root);
            System.Console.WriteLine($"The total number of nodes is: {numNodes}");
            System.Console.WriteLine($"The binary tree is a complete binary tree: {btree.CheckComplete(btree.Root, 0, numNodes)}");
            Height height = new Height();
            System.Console.WriteLine($"Check if tree is balanced: {btree.IsBalanced(btree.Root, height)}");
        }
        static void TopologicalSortAlgorithm()
        {
            Graph g = new Graph(5);
            g.AddVertex("A");
            g.AddVertex("B");
            g.AddVertex("C");
            g.AddVertex("D");
            g.AddVertex("E");
            g.AddEdge(0, 1);
            g.AddEdge(1, 2);
            g.AddEdge(2, 3);
            g.AddEdge(3, 4);

            g.PrintTopologicalSort();

        }
        static void PreviousTests()
        {
            Fibonacci fibonacci = new Fibonacci(9);
            System.Console.WriteLine($"Fib 9 is :{Fibonacci.Fib(9)}");
            System.Console.WriteLine($"Fib 9 is :{fibonacci.ComputeFib()}");
            SimpleQueueGeneric<string> simpleQueue = new SimpleQueueGeneric<string>(2, 2);
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

        }
    }
}
