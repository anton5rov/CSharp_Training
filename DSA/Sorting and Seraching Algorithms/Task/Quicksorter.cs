namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            Quicksort(collection, 0, collection.Count - 1);
        }

        public static void Quicksort(IList<T> collection, int leftStart, int rightStart)
        {
            if (leftStart >= rightStart)
            {
                return;
            }

            int l = leftStart;
            int r = rightStart;
            int pivotIndex = l + (r - l) / 2;
            T pivotValue = collection[pivotIndex];

            while (l < r)
            {
                while (collection[l].CompareTo(pivotValue) < 0 && l < pivotIndex)
                {
                    l++;
                }

                while (collection[r].CompareTo(pivotValue) > 0 && r > pivotIndex)
                {
                    r--;
                }

                if (l < r)
                {
                    Swap(collection, l, r);

                    if (l == pivotIndex)
                    {
                        pivotIndex = r;
                        r--;
                    }

                    if (r == pivotIndex)
                    {
                        pivotIndex = l;
                        l++;
                    }
                }
                l++; r--;
            }

            // Recursive calls
            Quicksort(collection, leftStart, pivotIndex - 1);
            Quicksort(collection, pivotIndex + 1, rightStart);
        }

        private static void Swap(IList<T> collection, int leftIndex, int rightIndex)
        {
            T tmp = collection[leftIndex];
            collection[leftIndex] = collection[rightIndex];
            collection[rightIndex] = tmp;
        }
    }
}
