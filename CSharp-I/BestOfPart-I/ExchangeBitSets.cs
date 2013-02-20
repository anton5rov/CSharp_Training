//Task: Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} of given 32-bit unsigned integer.


using System;
using System.Diagnostics;

//Remark: If two sets of bits overlap, result is not defined!

class ExchangeBitSets
{
    static void Main()
    {
        Stopwatch sw = new Stopwatch();
        uint number, set1, set2;
        byte startSet1, startSet2, setLength;
        Console.Write("Input an uint number: "); number = uint.Parse(Console.ReadLine());
        Console.Write("Input set length: "); setLength = byte.Parse(Console.ReadLine());
        Console.Write("Input start bit for set1 (from 0 to 31): "); startSet1 = byte.Parse(Console.ReadLine());
        Console.Write("Input start bit for set2 (from 0 to 31): "); startSet2 = byte.Parse(Console.ReadLine());
        sw.Start();
        set1 = (number >> startSet1) & ((1U<<setLength)-1); //get first set bits
        set2 = (number >> startSet2) & ((1U << setLength) - 1); //get second set bits
        Console.WriteLine("The number in binary: " + Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.WriteLine("set1 bits are: " + Convert.ToString(set1, 2).PadLeft(setLength, '0'));
        Console.WriteLine("set2 bits are: " + Convert.ToString(set2, 2).PadLeft(setLength, '0'));
        number = (number & ~(((1U << setLength) - 1) << startSet1))
                         & ~(((1U << setLength) - 1) << startSet2); // Adjust set's bits to '0'
        number = (number | (set1 << startSet2)) | (set2 << startSet1); //Puts set's bits to the new position
        Console.WriteLine("Bits exchanged:       " + Convert.ToString(number, 2).PadLeft(32, '0'));
        sw.Stop();
        Console.WriteLine(sw.Elapsed);
    }
}
