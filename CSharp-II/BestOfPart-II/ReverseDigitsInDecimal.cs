//Task: Write a method that reverses the digits of given decimal number. Example: 256 -> 652

//Solution with a given number. Works for positive and negative numbers. Note how decimal.Parse works with "123-"

using System;
using System.Text;

class ReverseDigitsInDecimal
{
    static void Main()
    {
        decimal decNumber = -12345.67M;
        decimal decReversed = ReverseDecimal(decNumber);
        Console.WriteLine(decReversed);        
    }

    private static decimal ReverseDecimal(decimal decNumber)
    {
        string tempStr = Convert.ToString(decNumber);
        char[] reversed = new char[tempStr.Length];
        for (int index = 0; index < tempStr.Length; index++)
        {
            reversed[index] = tempStr[tempStr.Length - 1 - index];
        }
        string str = new string(reversed);
        return decimal.Parse(str);
    }
}

