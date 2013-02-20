// Write a program that calculates for given N how many trailing zeros present at the end of the number N!. Examples:
	// N = 10 -> N! = 3628800 -> 2
	// N = 20 -> N! = 2432902008176640000 -> 4
	// Does your program work for N = 50 000?
// Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5.

using System;
using System.Collections;
class TrailingZerosIn_N_Factorial
{
    static void Main()
    {
        int N = 50;
        int zeros = 0;        
        for (int counter = 1; counter <= N; counter++)
        {
            int tempNumber = counter;
            int divider = 2;
            while (tempNumber > 1) //search for dividers of counter
            {
                if (tempNumber % divider == 0)
                {
                    tempNumber /= divider;
                    if (divider % 5 == 0) zeros++;
                    divider = 2;                    
                }
                else divider++;
            }   
        }
        Console.WriteLine(zeros);        
    }
}
