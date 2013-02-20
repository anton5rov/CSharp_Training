using System;
class SandGlass
{
    static void Main()
    {
        byte N = byte.Parse(Console.ReadLine());
        for (int row = 1; row <= N/2 +1 ; row++)
        {
            for (int symbols = 1; symbols <= N; symbols++)
            {
                if ((symbols < row) || (symbols > N-row + 1)) Console.Write(".");
                else Console.Write("*");
            }
            Console.WriteLine();            
        }
        for (int row = N/2 + 2; row <= N; row++)
        {
            for (int symbols = 1; symbols <= N; symbols++)
            {
                if ((symbols < N - row +1 ) || (symbols > row) ) Console.Write(".");
                else Console.Write("*");
            }
            Console.WriteLine();
        }
    }
}