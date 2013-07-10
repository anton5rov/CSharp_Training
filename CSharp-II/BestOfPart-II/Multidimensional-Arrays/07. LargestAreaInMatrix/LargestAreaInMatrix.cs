namespace LargestAreaInMatrix
{
    using System;
    using System.Text;
    
    public class LargestAreaInMatrix
    {
        public static void Main()
        {   
            Console.Write("Input N: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Input M: ");
            int m = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, m];
            ReadMatrix(matrix);

            bool[,] visitedCells = new bool[n, m];

            int maxArea = 0;
            int visitedCounter = 0;

            while (visitedCounter < n * m)
            {
                try
                {
                    Position startPosition = FindFirstUnvisitedCell(visitedCells);
                    int areaCount = 0;
                    MarkArea(matrix, startPosition, visitedCells, ref areaCount, ref visitedCounter);
                    if (areaCount > maxArea)
                    {
                        maxArea = areaCount;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("The matrix:");
            PrintMatrix(matrix);
            Console.WriteLine("Largest area number of elements:");
            Console.WriteLine(maxArea);
        }

        private static void MarkArea(
            int[,] matrix, 
            Position startPosition, 
            bool[,] visitedCells,
            ref int areaCount,
            ref int visitedCounter)
        {
            visitedCells[startPosition.Y, startPosition.X] = true;
            visitedCounter++;
            areaCount++;

            Directions directions = new Directions();

            for (int i = 0; i < 4; i++)
            {
                Position newPosition = new Position(
                    (byte)(startPosition.X + directions.DirectionsArray[i].X),
                    (byte)(startPosition.Y + directions.DirectionsArray[i].Y));
                if (ChekPosition(newPosition, matrix, visitedCells))
                {
                    if (matrix[newPosition.Y, newPosition.X] == matrix[startPosition.Y, startPosition.X])
                    {
                        MarkArea(matrix, newPosition, visitedCells, ref areaCount, ref visitedCounter);
                    }
                }
            }
        }

        private static bool ChekPosition(Position newPosition, int[,] matrix, bool[,] visitedCells)
        {
            if (
                0 <= newPosition.X && newPosition.X < matrix.GetLength(1) &&
                0 <= newPosition.Y && newPosition.Y < matrix.GetLength(0) &&
                visitedCells[newPosition.Y, newPosition.X] == false)
            {
                return true;
            }
            else 
            {
                return false;
            }
        }

        private static Position FindFirstUnvisitedCell(bool[,] visitedCells)
        {
            Position position = new Position(0, 0);
            for (byte row = 0; row < visitedCells.GetLength(0); row++)
            {
                for (byte col = 0; col < visitedCells.GetLength(1); col++)
                {
                    if (visitedCells[row, col] == false)
                    {
                        position.X = col;
                        position.Y = row; 
                        return position;
                    }
                }
            }

            throw new Exception("All cells are visited!");
        }

        private static void ReadMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine("Input {0} numbers in a line, separated with \", \"", matrix.GetLength(1));
                string inputString = Console.ReadLine();
                string[] split = inputString.Split(
                    new string[] { ",", " " }, 
                    StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = int.Parse(split[col]);
                }
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sb.AppendFormat("{0} ", matrix[row, col]);
                }

                sb.Append(Environment.NewLine);
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}

// 5
// 6
// 1, 3, 2, 2, 2, 4
// 3, 3, 3, 2, 4, 4
// 4, 3, 1, 2, 3, 3
// 4, 3, 1, 3, 3, 1
// 4, 3, 3, 3, 1, 1
