using System;
using System.Numerics;

class Tribonaci
{
    static void Main()
    {
        BigInteger tr1 = BigInteger.Parse(Console.ReadLine());
        BigInteger tr2 = BigInteger.Parse(Console.ReadLine());
        BigInteger tr3 = BigInteger.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        BigInteger trN = 0;
        if (N == 1) trN = tr1;
        else if (N == 2) trN = tr2;
        else if (N == 3) trN = tr3;
        else 
        {
            for (int i = 4; i <= N; i++)
            {
                trN = tr3 + tr2 + tr1;
                tr1 = tr2;
                tr2 = tr3;
                tr3 = trN;
            }
        }
        Console.WriteLine(trN);
    }
}
