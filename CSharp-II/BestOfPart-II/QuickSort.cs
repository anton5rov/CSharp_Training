using System;

public class QuickSort
{
    public static void Main()
    {
        Console.Write("Input the length of the array: ");
        int length = int.Parse(Console.ReadLine());

        string[] array = new string[length];
        ReadArray(array);

        QuickSortArray(array, 0, array.Length - 1);

        PrintArray(array);
    }

    private static void ReadArray(string[] array)
    {
        Console.WriteLine("Input {0} strings on separate lines:", array.Length);
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Console.ReadLine();
        }
    }

    private static void QuickSortArray(string[] array, int fromIndex, int toIndex)
    {
        int blockToSortLength = toIndex - fromIndex + 1;
        if (blockToSortLength == 0 || blockToSortLength == 1)
        {
            return;
        }

        int pivotIndex = (fromIndex + toIndex) / 2;

        string pivot = array[pivotIndex];

        // Move the pivot to the end of the block.
        Swap(array, pivotIndex, toIndex);
        pivotIndex = toIndex;

        // Search from left element, greater than pivot, to swap.
        int greaterElementIndex = 0;

        // Search from right element, lower than pivot, to swap.
        int lowerElementIndex = toIndex;

        while (greaterElementIndex < lowerElementIndex)
        {
            for (int i = greaterElementIndex; i < toIndex; i++)
            {
                if (array[i].CompareTo(pivot) <= 0)
                {
                    greaterElementIndex++;
                }
                else
                {
                    break;
                }
            }

            // A this point greaterElementIndex holds the greater element index or pivot index itself.

            for (int i = lowerElementIndex; i > greaterElementIndex; i--)
            {
                if (array[i].CompareTo(pivot) >= 0)
                {
                    lowerElementIndex--;
                }
                else 
                {
                    break;
                }
            }

            Swap(array, greaterElementIndex, lowerElementIndex);
        }

        // At this point greaterElementIndex holds final position of the pivot.
        pivotIndex = greaterElementIndex;

        Swap(array, pivotIndex, toIndex);

        // Recursive calls for left and right subarrays.
        QuickSortArray(array, 0, pivotIndex - 1);
        QuickSortArray(array, pivotIndex + 1, toIndex);
    }

    private static void Swap(string[] array, int firstIndex, int secondIndex)
    {
        // Swap only if indices and values not match.
        if (firstIndex != secondIndex && array[firstIndex] != array[secondIndex])
        {
            string buff = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = buff;
        }
    }

    private static void PrintArray(string[] array)
    {
        Console.WriteLine(string.Join(", ", array));
    }
}