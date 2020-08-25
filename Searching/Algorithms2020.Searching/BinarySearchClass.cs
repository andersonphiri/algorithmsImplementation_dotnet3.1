using System;


namespace Algorithms2020.Searching
{
    /// <summary>
    /// Time comlexity is O(logN)
    /// </summary>
    public static class BinarySearchClass 
    {
        public static int BinarySearchRecursive<T>(this T[] inputArray, T key) where T : IComparable<T> => BinarySearchUtil(inputArray, 0, inputArray.Length, key);
        private static int BinarySearchUtil<T>(T[] input, int start, int end, T key) where T : IComparable<T>
        {
            if (start > end) return -1;
            int middle = (end + start) / 2;
            if (key.CompareTo(input[middle]) < 0)
            {
                return BinarySearchUtil(input, start, middle - 1, key);
            }
            else if (key.CompareTo(input[middle]) > 0)
            {
                return BinarySearchUtil(input, middle + 1, end, key);
            }
            return middle;
        }

        public static int BinarySearchIterative<T>(this T[] input, T key) where T : IComparable<T>
        {
            int start = 0;
            int end = input.Length - 1;
            while (start <=end)
            {
                int middle = (end + start) / 2;
                if (key.CompareTo(input[middle]) < 0)
                {
                    end = middle - 1;
                }
                else if (key.CompareTo(input[middle]) > 0)
                {
                    start = middle + 1;
                }
                else
                {
                    return middle;
                }
               
            }
            return -1;
        }
    }
}
