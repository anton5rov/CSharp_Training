using System;

public class FillMatrixes
{
    public static void Main()
    {
        Console.Write("Input n: ");
        int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        // Task a)
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                matrix[row, col] = (n * col) + row + 1;
            }
        }

        Console.WriteLine("Task a): ");
        PrintMatrix(matrix);
        Console.WriteLine();

        // Task b)
        matrix = new int[n, n];
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            int direction = col % 2;
            int value = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                switch (direction)
                {
                    case 0: 
                        { 
                            value = (n * col) + row + 1; 
                            break; 
                        }

                    case 1: 
                        { 
                            value = (n * col) + 1 - row; 
                            break; 
                        }
                }

                matrix[row, col] = value;
            }
        }

        Console.WriteLine("Task b): ");
        PrintMatrix(matrix);
        Console.WriteLine();

        // Task c)
        matrix = new int[n, n];
        int startRow = n - 1;

        for (int count = 1; count <= n * n;)
        {
            int startColumn = (startRow >= 0) ? 0 : -startRow;
            int endColumn = Math.Min(n - 1 - startRow, n - 1);

            for (int col = startColumn; col <= endColumn; col++)
            {
                matrix[startRow + col, col] = count++;
            }

            startRow--;
        }

        Console.WriteLine("Task c): ");
        PrintMatrix(matrix);
        Console.WriteLine();

        // Task d)
        matrix = new int[n, n];
        int round = 0;
        for (int count = 1; count <= n * n;)
        {
            for (int row = round; row < n - round; row++)
            {
                matrix[row, round] = count++;
            }

            for (int col = round + 1; col < n - round; col++)
            {
                matrix[n - round - 1, col] = count++;
            }

            for (int row = n - round - 2; row >= round; row--)
            {
                matrix[row, n - round - 1] = count++;
            }

            for (int col = n - round - 2; col > round; col--)
            {
                matrix[round, col] = count++;
            }

            round++;
        }

        Console.WriteLine("Task d): ");
        PrintMatrix(matrix);
        Console.WriteLine();
    }

    private static void PrintMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(1); row++)
        {
            for (int col = 0; col < matrix.GetLength(0); col++)
            {
                Console.Write("{0,3} ", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }
}