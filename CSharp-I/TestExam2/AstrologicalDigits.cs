using System;
class AstrologicalDigits
{
    static void Main()
    {
        string N = Console.ReadLine();
        byte tempSum = 0;
        char? tempChar = null;
        for (int digits = 0; digits < N.Length; digits++)
        {
            tempChar = N[digits];
            if ((tempChar != '-') && (tempChar != '.'))
            {
                byte tempDigit = byte.Parse(tempChar.ToString());
                if ((tempDigit) > 0)
                {
                    tempSum += tempDigit;
                    if (tempSum % 9 == 0) tempSum = 9;
                    else tempSum %= 9;
                }
            }            
        }
        N = (tempSum + "");
        Console.WriteLine(N);
    }
}
