namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int startUnsortedPartIndex = 0;
            for (; startUnsortedPartIndex < collection.Count; startUnsortedPartIndex++)
            {
                int minElementSoFarIndex = startUnsortedPartIndex;
                for (int i = startUnsortedPartIndex + 1; i < collection.Count; i++)
                {
                    if (collection[minElementSoFarIndex].CompareTo(collection[i]) > 0)
                    {
                        minElementSoFarIndex = i;
                    }                    
                }
                if (collection[startUnsortedPartIndex].CompareTo(collection[minElementSoFarIndex]) > 0)
                {
                    SwapElements(collection, startUnsortedPartIndex, minElementSoFarIndex);
                }
                
            }
        }

        private void SwapElements(IList<T> collection, int firstIndex, int secondIndex)
        {
            T temp = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = temp;
        }
    }
}
