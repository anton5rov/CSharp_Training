using System;
class ForestRoad
{
    static void Main()
    {
        byte N = byte.Parse(Console.ReadLine());
        for (int i = 1; i <= N; i++)
        {
            for (int j = 1; j <= N; j++)
			{
                if (j == i) Console.Write('*');
                else Console.Write('.');
			}
            Console.WriteLine();
        }
        for (int i = 1; i < N; i++)
        {
            for (int j = 1; j <= N; j++)
            {
                if (j == N-i) Console.Write('*');
                else Console.Write('.');
            }
            Console.WriteLine();
        }
    }
}