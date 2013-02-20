using System;
class TribonacciTriangle
{
    static void Main()
    {
        long tr1 = long.Parse(Console.ReadLine());
        long tr2 = long.Parse(Console.ReadLine());
        long tr3 = long.Parse(Console.ReadLine());
        int L = int.Parse(Console.ReadLine());
        int sumL = CalcSigma(L);
        long[] TribonacciNumbers = new long[sumL];        
        TribonacciNumbers[0] = tr1;
        TribonacciNumbers [1]= tr2;
        TribonacciNumbers[2] = tr3;
        for (int i = 3; i < sumL; i++)
        {
            TribonacciNumbers[i] = tr3 + tr2 + tr1;
            tr1 = tr2;
            tr2 = tr3;
            tr3 = TribonacciNumbers[i];
        }
        int startPrint = 0;        
        for (int i = 0; i < L; i++)
        {
            for (int j = startPrint; j <= startPrint+i; j++)
            {
                Console.Write(TribonacciNumbers[j]);
                if (j < startPrint + i) Console.Write(" ");
            }
            startPrint += i+1;
            Console.WriteLine();
        }        
    }

    private static int CalcSigma(int L)
    {
        int sum = 0;
        for (int i = 1; i <= L; i++)
        {
            sum += i;
        }
        return sum;
    }
}
