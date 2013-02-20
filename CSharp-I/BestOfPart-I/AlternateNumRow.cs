//Task: Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...
//Solution based on fact, that ~i = -(i+1)

using System;
class AlternateNumRow
{
    static void Main()
    {
        for (int i = 2; i < 11; i++)
        {
            Console.Write(i + ", " + ~i++);
            if (i < 10) Console.Write(", ");
            else Console.WriteLine();
        }        
    }
}
