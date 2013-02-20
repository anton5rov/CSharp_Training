// Write a program that reads a number N and generates and prints all the permutations of the numbers [1 … N]. 
// Example: n = 3  {1, 2, 3}, {1, 3, 2}, {2, 1, 3}, {2, 3, 1}, {3, 1, 2}, {3, 2, 1}


//Solution:
//Implementation of iterative SEPA algorithm: http://www.quickperm.org/soda_submit.php
//Starts in ascending order and finishes in descending order, e.g. start "1 2 3 4", finish "4 3 2 1"
//It finds next permutation from current in three steps:
//1. Find the key element. That is the first element from right to left, which is less than the right one.
//   E.g. in "2 1 4 3" it is "1". Elements with indexes from key+1 to n form his "tail".
//2. Swap key element with less element in his tail, greater than key. 
//   E.g. in "2 1 4 3" swap "1" with "3". Result: "2 3 4 1"
//3. Sort the "tail" in ascending order. Result "2 3 1 4"
//So if we start with "2 1 4 3", we have result "2 3 1 4", which is the next permutation.

using System;
class Permutations
{
    static void Main()
    {
        Console.Write("Input N:");
        int n = int.Parse(Console.ReadLine());        
        int key = n-1;// initial key index
        int[] currentPermutation = new int[n];
        for (int i = 0; i < n; i++)//initialise array with numbers from 1 to n
        {
            currentPermutation[i] = i+1;            
        }
        myPrint(currentPermutation);//print first permutation
        while (true)
        {
            key = FindKey(currentPermutation);//find new key
            if (key >= 0)//if key is less than 0, final permutation found
            {
                SwapKey(currentPermutation, key);
                Array.Sort(currentPermutation, key + 1, n - key - 1);//sort tail
                myPrint(currentPermutation);
            }
            else break;            
        }
    }
    //----------
    private static void myPrint(int[] currentPerm)
    {
        for (int i = 0; i < currentPerm.Length; i++)
        {
            Console.Write(currentPerm[i] + " ");
        }        
        Console.WriteLine();
    }
    //----------
    private static void SwapKey(int[]arr, int key)
    {
        int tempNum;
        for (int i = arr.Length-1; i>=key ; i--)
        {
            if (arr[i] > arr[key])//find first value from right to left, greater than key
            {
                tempNum = arr[key];
                arr[key] = arr[i];
                arr[i] = tempNum;                
                return;
            }
        }
    }
    //----------
    private static int FindKey(int[] currentPerm)
    {
        for (int i = currentPerm.Length-2; i >=0 ; i--)
        {
            if (currentPerm[i]<currentPerm[i+1]) return i;
        }
        return -1;
    }      
}