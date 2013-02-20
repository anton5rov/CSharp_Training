//We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. 
//Example: 3, -2, 1, 1, 8 -> 1+1-2=0.

//Solution checks all subsets' sums, using byte mask for 5 numbers


using System;
class SubsetSumZero
{
    static void Main()
    {
        bool sum0Found = false;
        decimal sum;
        int a = 3, b = -2, c = 1, d = 1, e = 8;
        byte mask = 0;
        for (mask = 1; mask <= 31; mask++)
        {
            sum = (getByte(mask, 5) * a) + (getByte(mask, 4) * b) + (getByte(mask, 3) * c) + (getByte(mask, 2) * d) + (getByte(mask, 1) * e);            
            if (sum == 0) sum0Found = true;
        }
        Console.WriteLine("Sum equal to 0 found is: {0}", sum0Found);
    }
    private static int getByte(byte mask, int position)
    {        
        return (mask & (1<<(position-1))) >> position-1;
    }
}
