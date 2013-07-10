using System;

public class MaximalSum
{
    public static void Main()
    {
        Console.Write("Input N (N >= 3): ");
        int row = int.Parse(Console.ReadLine());

        Console.Write("Input M (M >= 3): ");
        int col = int.Parse(Console.ReadLine());

        if (row < 3 || col < 3)
        {
            Console.WriteLine("Invalid input! Try again");
            Main();
        }
        else
        {
            int[,] matrix = new int[row, col];
            int maxRowStart = 0;
            int maxColStart = 0;
            InputMatrix(matrix);
            FindMax3x3SubMatrix(matrix, ref maxRowStart, ref maxColStart);
            Console.WriteLine("Maximal submatrix is:");
            PrintMatrix(matrix, maxRowStart, maxColStart, 3, 3);
        }
    }

    private static void InputMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            Console.WriteLine("Input {0} numbers for row {1} separated with space: ",
                matrix.GetLength(1), row + 1);
            string inputStr = Console.ReadLine();
            string[] numbers = inputStr.Split(' ');

            for (int col = 0; col < numbers.Length; col++)
            {
                matrix[row, col] = int.Parse(numbers[col]);
            }

            Console.WriteLine();
        }
    }

    private static void FindMax3x3SubMatrix(int[,] matrix, ref int maxRowStart, ref int maxColStart)
    {
        int maxSum = int.MinValue;

        for (int row = 0; row <= matrix.GetLength(0) - 3; row++)
        {
            for (int col = 0; col <= matrix.GetLength(1) - 3; col++)
            {
                int tempSum = Find3x3Sum(matrix, row, col);

                if (tempSum > maxSum)
                {
                    maxSum = tempSum;
                    maxRowStart = row;
                    maxColStart = col;
                }
            }
        }
    }

    private static int Find3x3Sum(int[,] matrix, int startRow, int startCol)
    {
        int sum = 0;
        for (int rowIncrement = 0; rowIncrement < 3; rowIncrement++)
        {
            for (int colIncrement = 0; colIncrement < 3; colIncrement++)
            {
                sum += matrix[startRow + rowIncrement, startCol + colIncrement];
            }
        }

        return sum;
    }

    private static void PrintMatrix(int[,] matrix, int startRow, int startCol, int rowLength, int colLength)
    {
        for (int row = startRow; row < startRow + rowLength; row++)
        {
            for (int col = startCol; col < startCol + colLength; col++)
            {
                Console.Write("{0,3} ", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }
}