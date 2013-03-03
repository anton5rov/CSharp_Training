using System;
using GenericClass;

class TestGenericClass
{
    static void Main()
    {
        GenericList<int> intList = new GenericList<int>(10);        
        //check Add
        for (int i = 0; i < 5; i++)
        {
            intList.Add(i);
        }
        Console.WriteLine("Count: {0}, Capacity: {1}", intList.Count, intList.Capacity);
        Console.WriteLine();

        //check indexer
        intList[2] = 222;
        Console.WriteLine("The element with index 2 is: {0}", intList[2]);
        Console.WriteLine();

        //check ExtendCapacity
        for (int i = 0; i < 10; i++)
        {
            intList.Add(intList.Count);
        }
        Console.WriteLine("Add more 10 elements:");
        Console.WriteLine(intList);
        Console.WriteLine("Count: {0}, Capacity: {1}", intList.Count, intList.Capacity);
        Console.WriteLine();
        
        //check Remove
        intList.Remove(3);
        Console.WriteLine("Remove element at index 3:");
        Console.WriteLine(intList);
        Console.WriteLine("Count: {0}, Capacity: {1}", intList.Count, intList.Capacity);
        Console.WriteLine();

        //check Insert        
        intList.Insert(333, 3);
        Console.WriteLine("Insert 333 at index 3:");
        Console.WriteLine(intList);
        Console.WriteLine("Count: {0}, Capacity: {1}", intList.Count, intList.Capacity);
        Console.WriteLine();

        //check Min and Exception handling
        try
        {
            int min = GenericList<int>.Min(intList[13], intList[15]);
            Console.WriteLine(min);
        }
        catch (IndexOutOfRangeException err)
        {
            ExceptionHandling(err);
        }

        //check Max
        int max = GenericList<int>.Max(intList[3], intList[4]);
        Console.WriteLine(max);
        Console.WriteLine();
    
        //check string type
        Console.WriteLine("String type test:");
        GenericList<string> strList = new GenericList<string>(5);
        strList.Add("aaa");
        strList.Add("bbb");
        strList.Add("Aab");
        strList.Insert("ccc", 2);
        Console.WriteLine(strList);
        Console.WriteLine(GenericList<string>.Max(strList[1], strList[2]));
    }

    //exception handling
    private static void ExceptionHandling(Exception err)
    {
        if (err is IndexOutOfRangeException)
        {
            Console.WriteLine("Index not in range!");
        }
        else throw new NotImplementedException();
    }
}