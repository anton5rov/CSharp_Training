using System;
class _Ship_Damage
{
    static void Main()
    {
        int Sx1, Sy1, Sx2, Sy2;
        int H;
        int Cx1, Cy1, Cx2, Cy2, Cx3, Cy3;
        int damage = 0;
        Sx1 = int.Parse(Console.ReadLine());
        Sy1 = int.Parse(Console.ReadLine());
        Sx2 = int.Parse(Console.ReadLine());
        Sy2 = int.Parse(Console.ReadLine());
        H = int.Parse(Console.ReadLine());
        Cx1 = int.Parse(Console.ReadLine());
        Cy1 = int.Parse(Console.ReadLine());
        Cx2 = int.Parse(Console.ReadLine());
        Cy2 = int.Parse(Console.ReadLine());
        Cx3 = int.Parse(Console.ReadLine());
        Cy3 = int.Parse(Console.ReadLine());
        int shipLeft = Sx1;
        int shipRight = Sx2;
        if (Sx2 < Sx1) { shipLeft = Sx2; shipRight = Sx1; }
        int shipTop = Sy1;
        int shipBottom = Sy2;
        if (Sy1 < Sy2) { shipTop = Sy2; shipBottom = Sy1; }

        damage += checkDamage(Cx1, Cy1, shipLeft, shipRight, shipTop, shipBottom, H);
        damage += checkDamage(Cx2, Cy2, shipLeft, shipRight, shipTop, shipBottom, H);
        damage += checkDamage(Cx3, Cy3, shipLeft, shipRight, shipTop, shipBottom, H);        
        Console.WriteLine(damage + "%");
    }

    private static int checkDamage(int X, int Y, int shipLeft, int shipRight, int shipTop, int shipBottom, int H)
    {
        if ((X == shipLeft) || (X == shipRight))
        {
            if ((2 * H - Y == shipTop) || (2 * H - Y == shipBottom)) return 25;
            else if ((2 * H - Y < shipTop) && (2 * H - Y > shipBottom)) return 50;
        }
        else if ((X > shipLeft) && (X < shipRight))
        {
            if ((2 * H - Y == shipTop) || (2 * H - Y == shipBottom)) return 50;
            else if ((2 * H - Y < shipTop) && (2 * H - Y > shipBottom)) return 100;
        }
        return 0;
    }
}
