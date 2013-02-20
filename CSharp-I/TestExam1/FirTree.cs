using System;
class FirTree
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int rows = 1; rows <= n-1; rows++)
        {
            for (int symbol = 1; symbol < 2*n - 2; symbol++)
            {
                if ((symbol >=(n-rows)) && (symbol <= (n-2+rows))) Console.Write("*");
                else Console.Write(".");
            }
            Console.WriteLine();            
        }
        for (int symbol = 1; symbol < 2 * n - 2; symbol++)
        {
            if (symbol == (n - 1)) Console.Write("*");
            else Console.Write(".");
        }
    }
}
