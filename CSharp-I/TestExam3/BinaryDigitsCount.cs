using System;
class BinaryDigitsCount
{
    static int mask = int.MinValue;
    static void Main()
    {
        int B = Console.Read();        
        Console.ReadLine();
        B -= '0';
        int N = int.Parse(Console.ReadLine());
        byte[] searchedDigits = new byte[N];
        for (int i = 0; i < N; i++)
        {
            uint input = uint.Parse(Console.ReadLine());
            int leading0 = 0;
            for (int j = 0; j < 32; j++)
            {
                if ((input & mask) == 0) leading0++;
                else break;
                input = input << 1;
            }
            if (B==1) searchedDigits[i] = checkDigits(input, leading0);
            else searchedDigits[i] = checkDigits(~input, leading0);
        }
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine(searchedDigits[i]);
        }        
    }
    private static byte checkDigits(uint N, int leading0)
    {
        byte count = 0;
        for (int i = 0; i < 32 - leading0; i++)
        {
            if ((N & mask) != 0) count++;
            N = N << 1;
        }
        return(count);
    }
}
