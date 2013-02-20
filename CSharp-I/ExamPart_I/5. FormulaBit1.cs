using System;
struct position
{
    public int X;
    public int Y;
}
class FormulaBit1
{
    static int countSteps = 0;
    static int countTurns = 0;
    static byte[,] grid = new byte[8, 8];
    static void Main()
    {        
        position position = new position();
        position.X = 7;
        position.Y = -1;        
        bool canMove = true;        
        int horMove = 0, vertMove = 0;
        turnTo(countTurns, ref horMove, ref vertMove);
        bool turnFlag = false;
        inputGrid();
        while (canMove && !((position.X == 0) && (position.Y == 7)))
        {            
            canMove = checkMove(ref position, horMove, vertMove);
            if (canMove)
            {
                moveTo(ref position, horMove, vertMove);
                countSteps++;
                turnFlag = false;
            }
            else if (turnFlag == false)
            {
                countTurns++;                
                turnTo(countTurns, ref horMove, ref vertMove);
                turnFlag = true;
                canMove = true;
            }
            else canMove = false;
        }
        if ((position.X == 0) && (position.Y == 7))
        {
            Console.Write(countSteps + " ");
            Console.WriteLine(countTurns);
        }
        else
        {
            Console.Write("No ");
            Console.WriteLine(countSteps); 
        }        
    }
    private static void inputGrid()
    {
        for (int row = 0; row < 8; row++)
        {
            byte tempInput = byte.Parse(Console.ReadLine());
            for (int column = 0; column < 8; column++)
            {
                if ((tempInput & (1 << column)) != 0)
                {
                    grid[row, 7 - column] = 1;
                }
            }
        }
    }
    private static bool checkMove(ref position position, int horMove, int vertMove)
    {
        bool result = false;
        if (position.X + horMove >= 0 && position.Y + vertMove >= 0 && position.Y + vertMove < 8)
        {
            if (grid[(position.Y + vertMove), (position.X + horMove)] == 0) result = true;            
        }
        return result;
    }
    private static void moveTo(ref position position, int horMove, int vertMove)
    {
        position.X += horMove;
        position.Y += vertMove;
    }
    private static void turnTo(int countTurns, ref int horMove, ref int vertMove)
    {
        horMove = ((countTurns % 4) % 2) * (-1);
        switch (countTurns % 4)
        {
            case 0: vertMove = 1; break;
            case 1:
            case 3: vertMove = 0; break;
            case 2: vertMove = -1; break;
        }
    }
}