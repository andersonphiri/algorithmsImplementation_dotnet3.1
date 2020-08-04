using System;

namespace Algorithms2020.CustomStack
{
    public class MyCustomStack
    {
        private int _top;
        private int _size;
        private int[] arr;
        public MyCustomStack(int size)
        {
            _size = size;
            arr = new int[_size];
            _top = -1;
        }

        //public MyCustomStack()
        //{
        //    _size = 10;
        //    arr = new int[_size];
        //    _top = -1;
        //}
        public int Size()
        {
            return _top + 1;
        }
        public bool IsEmpty()
        {
            return _top == -1;
        }
        public bool IsFull()
        {
            return _size == _top + 1;
        }

        public void Push(int value)
        {
            if (IsFull())
                return;

            arr[++_top] = value;
        }

        public int Peek()
        {
            return arr[_top];
        }
        public int Pop()
        {
            if (IsEmpty())
            {
                throw new System.InvalidOperationException();
            }
            var topValue = arr[_top--];
            return topValue;

        }

        //this one to be used with dynamic array MyCustomStack<T>()
        private void CheckSize()
        {
            if (_size > _top + 1)
            {
                return;
            }
            if (_size == _top + 1)
                _size = 2 * 1;
            int[] arrTemp = new int[_size];
            Array.Copy(arr, arrTemp, arr.Length);
            arr = new int[_size];
            Array.Copy(arrTemp, arr, arr.Length);
            arrTemp = null;
        }
    }
}
