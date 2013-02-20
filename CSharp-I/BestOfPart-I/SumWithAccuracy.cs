// Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

using System;
class SumWithAccuracy
{
    static void Main()
    {
        decimal sum=1, prevSum;
        int step = 2;
        do
        {
            prevSum = sum;
            if (step % 2 != 0) sum += -1M / step;
            else sum += 1M / step;
            step++;            
        }
        while (Math.Abs(sum - prevSum) > 0.001M);
        Console.WriteLine(sum);
    }
}