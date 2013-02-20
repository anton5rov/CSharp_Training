using System;
class Pillars
{
    static void Main()
    {
        byte[] numbers = new byte[8];
        for (int i = 0; i < 8; i++)
        {
            numbers[i] = byte.Parse(Console.ReadLine());
        }
        if (sumElements(numbers, 0, 7) == 0)
        {
            Console.WriteLine(7);
            Console.WriteLine(0);
        }
        else
        {
            for (int movePillarRight = 7; movePillarRight >= 0 ; movePillarRight--)
            {
                int sumLeft = sumElements(numbers, movePillarRight + 1, 7);
                int sumRight = sumElements(numbers, 0, movePillarRight - 1);
                if (sumLeft == sumRight)
                {
                    Console.WriteLine(movePillarRight);
                    Console.WriteLine(sumLeft);
                    break;
                }
                else if (movePillarRight == 0) Console.WriteLine("No");
            }
        }        
    }

    private static int sumElements(byte[] numbers, int rightColumn, int leftColumn)
    {
        int sum = 0;
        for (int i = rightColumn; i <= leftColumn; i++)
        {
            for (int row = 0; row < 8; row++)
            {
                if (((numbers[row] >> i) & 1) > 0) sum++;                
            }            
        }
        return sum;
    }
}
