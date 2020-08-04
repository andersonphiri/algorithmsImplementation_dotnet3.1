using System;
using System.Collections;
using System.Drawing;

namespace Algorithms2020.CustomQueue
{
    public class SimpleQueueGeneric
    {
        private int _front;
        private int _rear;
        private static readonly int _size = 10;
        private int[] items = new int[_size];
        public SimpleQueueGeneric()
        {
            _front = -1;
            _rear = -1;
        }
        public bool IsEmpty() => _front == -1;

        public bool IsFull() => _front == 0 && _rear == _size - 1;
        
        public void Enqueue(int num)
        {
            if (IsFull())
            {
                throw new InvalidOperationException("Your Queue is full");

            }
            if (_front == -1)
                _front = 0;
            items[++_rear] = num;
        }

        /// <summary>
        /// returns a tuple of (index and value) (-1,-1) means empty queue
        /// </summary>
        /// <returns></returns>
        public (int,int) Dequeue()
        {
            int element;
            if (IsEmpty())
                return (-1,-1);
            if (_front >= _rear)
            {
                _front = -1;
                _rear = -1;
            }
            int index = _front;
            element = items[_front++];
            return (index, element);
        }
    }
    /// <summary>
    /// running time O(1)
    /// </summary>
    public class SimpleQueueGeneric<T>  //where T:  class, new()
    {
        protected int _front;
        protected int _rear;
        protected int _size = 3;
        protected int _growthFactor = 2;
        protected T[] items ;
        protected int _currentSize = 0;
        public SimpleQueueGeneric(int size, int growthFactor)
        {
            _size = size;
            _growthFactor = growthFactor;
            items = new T[_size];
            _front = -1;
            _rear = -1;
        }
        public SimpleQueueGeneric()
        {
            items = new T[_size];
            _front = -1;
            _rear = -1;
        }
        public int Length => _currentSize;

        public bool IsEmpty() => _front == -1; 

        public bool IsFull() => _front == 0 && _rear == _size - 1 || _currentSize==items.Length;
        protected void IncreaseCapacity()
        {
            this._rear = _size - 1;
            _size = _size * _growthFactor;
            T[] newArray = new T[_size];

            Array.Copy(items, newArray, items.Length);
            items = newArray;
            this._front = 0;
        }

        protected void IncreaseCapacity2()
        {
            _size = _size * _growthFactor;
            T[] newArray = new T[_size];
            int tempFront = _front;
            int index = -1;
            while (true)
            {
                newArray[++index] = items[++tempFront];// front is either -1 or 0
                if (tempFront==this.items.Length)
                {
                    tempFront = 0;
                }
                if (index+1==_currentSize)
                {
                    break;
                }
            }
            items = newArray;
            _front = 0;
            _rear = index;

        }
        public void PrintQueue()
        {
            System.Console.WriteLine();
            if (IsEmpty())
            {
                System.Console.WriteLine("Your queue is empty");
                return;
            }
            foreach (var item in items)
            {
                System.Console.WriteLine(item);
            }

            System.Console.WriteLine($"Rear: {_rear}, Front: {_front}, Rear value: {items[_rear]}, Front Value: {items[_front]}");
            System.Console.WriteLine();
        }
        public void Enqueue(T item)
        {
            if (IsFull())
                IncreaseCapacity(); // either  IncreaseCapacity2(); works
            ++this._rear;
            if (_front<0)
            {
                _front = 0;
            }
            items[_rear] = item;
            _currentSize++;
        }
        public (int,T) DequeueTuple()
        {
            T t = (T)new object();
            if (IsEmpty())
            {
                return (-1, t);
            }
            var (index,item) = (_front,items[_front]);
            if (_front>=_rear)
            {
                _front = -1;
                _rear = -1;
            }
            else
            {
                _front++;
            }
            return (index, item);
        }
        public T Dequeue()
        {
            if (this.IsEmpty())
            {
                throw new System.InvalidOperationException("Your queue is empty");
            }
            
            T element = items[_front];
            if (_front >= _rear)
            {
                _front = -1;
                _rear = -1;
            }
            else
            {
                _front++;
            }
            return element;
        }
   
    
    }

    /// <summary>
    /// running time O(1)
    /// </summary>
    public class SimpleQueueGenericCircular<T> : SimpleQueueGeneric<T>
    {
        public SimpleQueueGenericCircular(): base()
        {

        }
        public SimpleQueueGenericCircular(int size, int growthFactor): base(size,growthFactor)
        {

        }
        public new void Enqueue(T item)
        {
            if (IsFull())
                IncreaseCapacity(); // either  IncreaseCapacity2(); works
            this._rear = (this._rear+1)%_size;
            if (_front < 0)
            {
                _front = 0;
            }
            items[_rear] = item;
            _currentSize++;
        }

       public new T Dequeue()
       {
            if (this.IsEmpty())
            {
                throw new System.InvalidOperationException("Your queue is empty");
            }

            T element = items[_front];
            if (_front >= _rear)
            {
                _front = -1;
                _rear = -1;
            }
            else
            {
                _front = (_front+1)%_size;
            }
            return element;
        }

    }

}
