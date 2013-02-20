//Task: Write a program that sorts an array of integers using the merge sort algorithm


//Solution with iterative bottom-up algorithm
using System;
class MergeSort
{
    static void Main()
    {
        int[] arr = { 2, 1, 8, 0, 1, 3, 7, -5, 15 };
        // in each iteration sort blocks with (2^(iteration-1)) length, e.g. 1, 2, 4 etc.  
        for (int iteration = 1; iteration < arr.Length; iteration *= 2)
        {
            int[] tempArr = new int[arr.Length];
            //fills tempArr with sorted iteration-long blocks
            //at first iteration sorts {(2 with 1), (8 with 0), ...}
            for (int j = 0; j < arr.Length; j+=2*iteration)
            {
                MergeSortedPartsOfArray(arr, j, Math.Min(j + iteration, arr.Length), Math.Min(j + 2 * iteration, arr.Length), tempArr);
            }
            arr = tempArr;// arr takes sorted result each time
            //end of first iteration: {(1, 2), (0, 8), (1, 3), (-5, 7), 15}
            //end of second iteration: {(0, 1, 2, 8), (-5, 1, 3, 7), 15} etc.
        }
        //print result
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + "  ");
        }
        Console.WriteLine( );
    }
    //-------------------
    private static void MergeSortedPartsOfArray(int[] arr1, int leftStart, int rightStart, int rightEnd, int[] result)
    {
        int resultIndex;        
        int leftEnd = rightStart-1;
        for (resultIndex = leftStart; resultIndex < rightEnd; resultIndex++)
        {
            if (leftStart <= leftEnd && (rightStart >= rightEnd || arr1[leftStart] <= arr1[rightStart]))
            {
                result[resultIndex] = arr1[leftStart];
                leftStart++;
            }
            else
            {
                result[resultIndex] = arr1[rightStart];
                rightStart++;
            }
        }        
    }
}
