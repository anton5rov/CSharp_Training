// Task: Write a program that finds the index of given element 
// in a sorted array of integers by using the binary search algorithm


using System;
class BinarySearch
{
    static void Main()
    {
        int[] arr = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        int element = 5;
        int index = -1;
        int searchStart = 0;
        int searchEnd = arr.Length-1;
        BinSearch(arr, element, ref index, ref searchStart, ref searchEnd);
        if (index >= 0) Console.WriteLine("The element is at {0} position", index);
        else Console.WriteLine("No such element in the array!");
    }
    //--------------
    private static void BinSearch(int[] arr, int element, ref int index, ref int searchStart, ref int searchEnd)
    {
        if ((element > arr[searchEnd]) || (element < arr[searchStart]))
        {
             index = -1;
             return;
        } 
        if (element == arr[searchEnd])
        {
            index = searchEnd;
            return;
        }
        else if (element == arr[searchStart])
        {
            index = searchStart;
            return;
        }
        else if (element >= (arr[searchStart + (searchEnd - searchStart) / 2]))
        {
            searchStart = searchStart + (searchEnd - searchStart) / 2;
            BinSearch(arr, element, ref index, ref searchStart, ref searchEnd);
        }
        else if (element <= (searchStart + (searchEnd - searchStart) / 2))
        {
            searchEnd = searchStart + (searchEnd - searchStart)/2;
            BinSearch(arr, element, ref index, ref searchStart, ref searchEnd);
        }
    }
}
