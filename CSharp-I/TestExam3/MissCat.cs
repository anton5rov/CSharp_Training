using System;
class MissCat
{
    static void Main()
    {
        int[] scores = new int[11];
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
		{
            int TempNum = int.Parse(Console.ReadLine());
            scores[TempNum]++;            			 
		}
        int winner = 1;
        for (int i = 1; i <= 10; i++)
        {
            if (scores[i] > scores[winner]) winner = i;
        }
        Console.WriteLine(winner);
    }
}