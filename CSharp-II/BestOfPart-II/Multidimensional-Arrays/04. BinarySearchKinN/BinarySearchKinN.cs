using System;

public class BinarySearchKinN
{
    public static void Main()
    {
        Console.Write("Input N: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Input {0} integers, separated wih space: ", n);
        string inputStr = Console.ReadLine();
        string[] numbers = inputStr.Split(' ');
        int[] array = new int[n];

        for (int index = 0; index < n; index++)
        {
            array[index] = int.Parse(numbers[index]);
        }

        Array.Sort(array);

        Console.WriteLine("Input K: ");
        int k = int.Parse(Console.ReadLine());

        int position = Array.BinarySearch(array, k);

        // If position >= 0, K found at this position.
        // If position < 0, K not found. It should be
        // at (~position) index and element <= K is at (~position - 1)
        // So, if position is -1, K should be
        // at index 0 and no element is <= than K.
        if (position < -1 || -1 < position)
        {
            Console.WriteLine(
                "The biggest element in the array <= than K is: {0}",
                (0 <= position) ? array[position] : array[(~position) - 1]);
        }
        else if (position == -1)
        {
            Console.WriteLine("No element in the array which is <= {0}", k);
        }
    }
}