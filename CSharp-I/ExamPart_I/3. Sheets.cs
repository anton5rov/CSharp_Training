using System;
class Sheets
{
    static void Main()
    {
        string[] formats = new string[11];
        for (int i = 0; i <= 10; i++)
        {
            formats[i] = ("A" + i);
        }
        int N = int.Parse(Console.ReadLine());
        for (int i = 10; i >= 0; i--)
        {
            if (((1 << i) & N) > 0)
            {
                formats[10-i] = "used";
            }
        }
        for (int i = 0; i <= 10; i++)
        {
            if (formats[i] != "used") Console.WriteLine(formats[i]);            
        }
    }
}
