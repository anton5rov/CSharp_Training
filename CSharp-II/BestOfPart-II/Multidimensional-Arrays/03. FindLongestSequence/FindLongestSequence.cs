using System;

public struct Direction
{
    public sbyte X;
    public sbyte Y;

    public Direction(sbyte x, sbyte y)
    {
        this.X = x;
        this.Y = y;
    }
}

public class Directions
{
    // "0" - right, 
    // "1" - south-east diagonal, 
    // "2" - down, 
    // "3" - south-west diagonal.
    private Direction[] directionsArray = new Direction[4];

    public Directions()
    {
        this.directionsArray[0] = new Direction(1, 0);
        this.directionsArray[1] = new Direction(1, 1);
        this.directionsArray[2] = new Direction(0, 1);
        this.directionsArray[3] = new Direction(-1, 1);
    }

    public Direction[] DirectionsArray
    {
        get
        {
            return this.directionsArray;
        }
    }
}

public class FindLongestSequence
{
    public static void Main()
    {
        Directions directions = new Directions();

        Console.Write("Input N (N >= 1): ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Input M (M >= 1): ");
        int cols = int.Parse(Console.ReadLine());

        int maxSequenceLength = 0;

        int maxElementRow = 0;

        int maxElementCol = 0;

        Direction maxElementDirection = directions.DirectionsArray[0];
        string[,] matrix = new string[rows, cols];

        InputMatrix(matrix);

        Console.WriteLine("The Matrix:");

        PrintMatrix(matrix, 0, 0, rows, cols);

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Direction direction = directions.DirectionsArray[0];

                int tempMaxLength = FindMaxSequenceWithCurrent(matrix, row, col, ref direction);

                if (tempMaxLength > maxSequenceLength)
                {
                    maxSequenceLength = tempMaxLength;
                    maxElementRow = row;
                    maxElementCol = col;
                    maxElementDirection = direction;
                }
            }
        }

        string[] maxSequenceFound = new string[maxSequenceLength];

        FillSequence(matrix, maxSequenceFound, maxElementRow, maxElementCol, maxElementDirection);

        Console.WriteLine();
        Console.WriteLine("The longest sequence: ");
        PrintSequence(maxSequenceFound);
    }

    private static void InputMatrix(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            Console.WriteLine("Input {0} strings for row {1} separated with 1 space: ",
                matrix.GetLength(1), row + 1);
            string inputStr = Console.ReadLine();
            string[] elements = inputStr.Split(' ');

            for (int col = 0; col < elements.Length; col++)
            {
                matrix[row, col] = elements[col];
            }

            Console.WriteLine();
        }
    }

    private static void PrintMatrix(
        string[,] matrix,
        int startRow,
        int startCol,
        int rowLength,
        int colLength)
    {
        for (int row = startRow; row < startRow + rowLength; row++)
        {
            for (int col = startCol; col < startCol + colLength; col++)
            {
                Console.Write("{0, -5} ", matrix[row, col]);
            }

            Console.WriteLine();
        }
    }

    private static int FindMaxSequenceWithCurrent(
        string[,] matrix,
        int startRow,
        int startCol,
        ref Direction direction)
    {
        Directions directions = new Directions();
        int maxLength = 0;
        for (int dir = 0; dir <= 3; dir++)
        {
            int r = startRow;
            int c = startCol;
            Direction tempDirection = directions.DirectionsArray[dir];
            int tempLength = 1;

            while (
                r + tempDirection.Y <= matrix.GetLength(0) &&
                c + tempDirection.X <= matrix.GetLength(1))
            {
                if (r + tempDirection.Y >= matrix.GetLength(0) ||
                    c + tempDirection.X >= matrix.GetLength(1) ||
                    c + tempDirection.X < 0 ||
                    matrix[r + tempDirection.Y, c + tempDirection.X] != matrix[r, c])
                {
                    break;
                }
                else
                {
                    r += tempDirection.Y;
                    c += tempDirection.X;
                    tempLength++;
                }
            }

            if (tempLength > maxLength)
            {
                maxLength = tempLength;
                direction.X = tempDirection.X;
                direction.Y = tempDirection.Y;
            }
        }

        return maxLength;
    }

    private static void FillSequence(
        string[,] matrix,
        string[] maxSequenceFound,
        int maxElementRow,
        int maxElementCol,
        Direction maxElementDirection)
    {
        maxSequenceFound[0] = matrix[maxElementRow, maxElementCol];

        for (int count = 1; count < maxSequenceFound.Length; count++)
        {
            maxSequenceFound[count] = matrix[
                maxElementRow + maxElementDirection.Y,
                maxElementCol + maxElementDirection.X];
        }
    }

    private static void PrintSequence(string[] array)
    {
        for (int count = 0; count < array.Length - 1; count++)
        {
            Console.Write("{0}, ", array[count]);
        }

        Console.WriteLine(array[array.Length - 1]);
    }
}