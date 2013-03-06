using System;
using System.Collections;
using System.Collections.Generic;

public static class IEnumerableExtensions
{
    private static T GetElement<T>(IEnumerable<T> someList, int position) where T : IComparable<T>
    {
        IEnumerator<T> myEnumerator = someList.GetEnumerator();
        myEnumerator.Reset();
        for (int i = 0; i <= position; i++)
        {
            myEnumerator.MoveNext();
        }        
        return myEnumerator.Current;
    }
    public static T Min<T>(this IEnumerable<T> someList)
        where T: IComparable<T>
    {
        T min = GetElement<T>(someList, 0);
        foreach (var item in someList)
        {
            if (min.CompareTo(item) > 0)
                min = item;
        }
        return min;
    }
    public static T Max<T>(this IEnumerable<T> someList)
        where T : IComparable<T>
    {
        T max = GetElement<T>(someList, 0);
        foreach (var item in someList)
        {
            if (max.CompareTo(item) < 0)
                max = item;
        }
        return max;
    }
    public static T Sum<T>(this IEnumerable<T> someList)
        where T : IComparable<T>
    {
        dynamic sum = default(T);
        foreach (var item in someList)
        {
            sum += item;
        }
        return (T)sum;
    }
    public static T Product<T>(this IEnumerable<T> someList)
        where T : struct, IComparable<T>
    {
        T product = (dynamic)default(T) + 1;
        foreach (var item in someList)
        {
            product = (dynamic)product * item;
        }
        return product;
    }
    public static decimal Average<T>(this IEnumerable<T> someList)
        where T : struct, IComparable<T>
    {
        ICollection<T> tempColl = someList as ICollection<T>;
        decimal average = Convert.ToDecimal(someList.Sum()) / (tempColl.Count);
        return average;
    }
}

class IEnumerableExtentions_Test
{
    static void Main()
    {
        string[] strElements = {"abcdef", "ccc"};        
        Console.WriteLine(strElements.Max());
        Console.WriteLine(strElements.Min());
        Console.WriteLine(strElements.Sum());        
        
        int[] intElements = { 10, 1, 2, 3, 4, 3, 2};
        Console.WriteLine(intElements.Max());
        Console.WriteLine(intElements.Min());
        Console.WriteLine(intElements.Sum());
        Console.WriteLine(intElements.Product());
        Console.WriteLine(intElements.Average());
    }
}
