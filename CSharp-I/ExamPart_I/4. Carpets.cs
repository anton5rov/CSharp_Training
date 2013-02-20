using System;
class Carpets
{
    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        for (int row = 0; row < N/2; row++)
        {
            for (int col = 0; col < N; col++)
            {
                if (col < N/2-row-1 || col > N/2 + row ) Console.Write('.');
                else
                {
                    if ((N / 2) % 2 != 0)
                    {
                        if (((col - row) % 2 == 0) && (col < N/2)) Console.Write('/');
                        else if (((col - row) % 2 != 0) && (col >= N/2)) Console.Write('\\');
                        else Console.Write(' ');
                    }
                    else
                    {
                        if (((col - row) % 2 != 0) && (col < N / 2)) Console.Write('/');
                        else if (((col - row) % 2 == 0) && (col >= N / 2)) Console.Write('\\');
                        else Console.Write(' ');
                    }
                }                
            }           
            Console.WriteLine();            
        }

        for (int row = N/2; row < N; row++)
        {
            for (int col = 0; col < N; col++)
            {
                if (col < row - N / 2 || col >= N / 2 + N - row) Console.Write('.');
                else
                {
                    if ((N / 2) % 2 != 0)
                    {
                        if (((col - row) % 2 != 0) && (col < N / 2)) Console.Write('\\');
                        else if (((col - row) % 2 == 0) && (col >= N / 2)) Console.Write('/');
                        else Console.Write(' ');
                    }
                    else
                    {
                        if (((col - row) % 2 == 0) && (col < N / 2)) Console.Write('\\');
                        else if (((col - row) % 2 != 0) && (col >= N / 2)) Console.Write('/');
                        else Console.Write(' ');
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
