using System;
using System.Linq;
using System.Collections.Generic;


class IntsDevisableBy7and3
{
    static void Main()
    {
        int[] arr = new int[100];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i;
        }

        var devNumbers = arr.Where(x => x % 21 == 0);
        PrintElements(devNumbers);

        devNumbers =
            from num in arr
            where num % 21 == 0
            select num;
        PrintElements(devNumbers);
    }

    private static void PrintElements(IEnumerable<int> devNumbers)
    {
        foreach (var item in devNumbers)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }
}
