using System;
using System.Collections.Generic;
using System.Text;
namespace Algorithms2020.Sorting
{
    /// <summary>
    /// time complexity O(n^2)
    /// </summary>
    public static class SelectionSort
    {
        public static T[] SelectionSortOperation<T>(this T[] sourceArray) where T : IComparable<T>
        {
            T[] array = sourceArray.CreateCopy();
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int  j = i+1;  j < array.Length;  j++)
                {
                    if (array[j].CompareTo(array[min]) <= 0) min = j;
                }
                if (min == i) continue;
                array.Swap(i, min);
            }

            return array;
        }
    }
}
