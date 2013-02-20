using System;
class SubsetSums
{
    static void Main()
    {
        long S = long.Parse(Console.ReadLine());
        byte N = byte.Parse(Console.ReadLine());
        long[] numbers = new long[N];
        ushort counter = 0;
        for (int i = 0; i < N; i++)
        {
            numbers[i] = long.Parse(Console.ReadLine());
        }
        for (int i = 1; i < Math.Pow(2,(double)N); i++)
        {
            long tempSum = 0;
            for (int j = 0; j < N; j++)
            {
                tempSum += ((i >> j) & 1) * numbers[j];
            }
            if (tempSum == S) counter++;
        }
        Console.WriteLine(counter);
    }
}
