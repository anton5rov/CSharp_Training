// Write a program that reads two positive integer numbers and prints how many 
// numbers p exist between them such that 
// the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.

using System;
class DivBy5Numbers
{
    static void Main()
    {
        int firstNum, secondNum, result=0;
        string consoleLine;
        // Input
        Console.WriteLine("Input two integers:");
        consoleLine = Console.ReadLine();
        firstNum = int.Parse(consoleLine);
        consoleLine = Console.ReadLine();
        secondNum = int.Parse(consoleLine);
        // check for two negative integers
        if ((firstNum <= 0) && (secondNum <= 0))
        {firstNum *= -1; secondNum *= -1;}
        //main calculation
        if ((Math.Min(firstNum, secondNum) % 5 == 0))result = 1;
        result += Math.Abs((firstNum / 5) - (secondNum) / 5);
        Console.WriteLine("The count of the numbers \n" +
                          "in the given interval that devides by 5 are: {0}\n", result);
    }
}