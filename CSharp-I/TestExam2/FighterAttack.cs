using System;
class FighterAttack
{
    static void Main()
    {
        int pX1 = int.Parse(Console.ReadLine());
        int pY1 = int.Parse(Console.ReadLine());
        int pX2 = int.Parse(Console.ReadLine());
        int pY2 = int.Parse(Console.ReadLine());
        int fX = int.Parse(Console.ReadLine());
        int fY = int.Parse(Console.ReadLine());
        int D = int.Parse(Console.ReadLine());

        int pLeft = Math.Min(pX1, pX2);
        int pRight = Math.Max(pX1, pX2);
        int pTop = Math.Max(pY1, pY2);
        int pBottom = Math.Min(pY1, pY2);
        int hitX = fX + D;
        int hitY = fY;
        int damage = 0;
        
        if ((hitX >= pLeft) && (hitX <= pRight) && (hitY <= pTop) && (hitY >= pBottom)) damage += 100;
        if ((hitX +1 >= pLeft) && (hitX +1 <= pRight) && (hitY <= pTop) && (hitY >= pBottom)) damage += 75;
        if ((hitX >= pLeft) && (hitX <= pRight) && (hitY +1 <= pTop) && (hitY +1 >= pBottom)) damage += 50;
        if ((hitX >= pLeft) && (hitX <= pRight) && (hitY -1 <= pTop) && (hitY -1 >= pBottom)) damage += 50;

        Console.WriteLine(damage + "%");
    }
}