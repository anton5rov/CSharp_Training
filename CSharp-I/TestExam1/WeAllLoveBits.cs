using System;
class WeAllLoveBits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] list = new int[n];
        for (int counter = 0; counter < n; counter++)
        {
            list[counter] = int.Parse(Console.ReadLine());
            int newNumber = 0;            
            while (list[counter]>0)
            {
                newNumber = (newNumber << 1) | (list[counter] & 1);
                list[counter] >>= 1;
            }
            list[counter] = newNumber;
        }
        for (int counter = 0; counter < n; counter++)
        {
            Console.WriteLine(list[counter]);            
        }        
    }
}
