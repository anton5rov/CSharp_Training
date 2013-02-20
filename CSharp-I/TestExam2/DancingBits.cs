using System;
class DancingBits
{
    static void Main()
    {
        short K = short.Parse(Console.ReadLine());
        short N = short.Parse(Console.ReadLine());
        string bigString = "";
        // read and concatenate all numbers as strings from the console
        for (short counter = 0; counter < N; counter++)
        {
            bigString += Convert.ToString(int.Parse(Console.ReadLine()), 2);
        }     
        int countDancingBits = 0;                
        // find groups of K same bits
        int startPosition = 0;                        
        while (startPosition < bigString.Length)
        {
            int bitsGroupCount = 0;
            int step = 0;
            while (((startPosition + step)< bigString.Length) && (bigString[startPosition] == bigString[startPosition + step]))
            {
                bitsGroupCount++;
                step++;
            }
            if (bitsGroupCount == K) countDancingBits++;
            startPosition += step;
        }
        Console.WriteLine(countDancingBits);
    }    
}