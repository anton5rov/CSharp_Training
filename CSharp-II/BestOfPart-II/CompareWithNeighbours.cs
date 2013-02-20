//Task: Write a method that checks if the element at given position 
//in given array of integers is bigger than its two neighbors (when such exist).

//Solution assuming, that number is bigger than absent neighbors

using System;

namespace Methods
{
    public class CompareWithNeighbours
    {
        static void Main()
        {
            int[] arr = { 55, 23, 783, 66, 12, 10 };
            int position = 0;
            bool result = CheckNeighbours(arr, position);
            Console.WriteLine(result);
        }
        //------------------------
        public static bool CheckNeighbours(int[] arr, int position)
        //Returns true if element is first or last in the array and is bigger than the other neighbour.
        {
            if (position > 0 && arr[position - 1] > arr[position]) return false;
            if (position < arr.Length - 1 && arr[position + 1] > arr[position]) return false;
            else return true;        
        }
    }
}
