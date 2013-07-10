using System;

public class SortStringsArrayByLength
{
    public static void Main()
    {
        string[] strArray = { "abcd", "abc", "abb", "ab", "b" };
        int[] keysCount = new int[strArray.Length];
        for (int i = 0; i < strArray.Length; i++)
        {            
            keysCount[i] = strArray[i].Length;
        }

        Array.Sort(keysCount, strArray);

        for (int i = 0; i < strArray.Length; i++)
        {
            Console.Write("{0} ", strArray[i]);
        }

        Console.WriteLine();
    }
}