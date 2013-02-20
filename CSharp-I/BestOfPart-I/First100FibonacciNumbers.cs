// Write a program to print the first 100 members 
// of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

//First solution uses an iteractive method

using System;
using System.Numerics;
class Fibonacci100
{
    public static void Main()
    {
        BigInteger a = 0;
        BigInteger b = 1;
        BigInteger temp;
        for (int i = 0; i < 100; i++)
        {
            Console.Write("F({0}) = {1}; ", i+1, a);
            temp = a;
            a = b;
            b = temp + b;
        }
    }
}

// Following is the recursive method. Too slow for i=20 and above;

//using System;
//public class Fibonacci100
//{
//   public static void Main()
//   {
//       for (int i = 0; i < 10; i++)
//           Console.WriteLine(Fibonacci(i));       
//   }
//    static int Fibonacci(int x)
//    {
//        if (x == 1) return 1;
//        else if (x == 0) return 0;
//        return Fibonacci(x - 1) + Fibonacci(x - 2);
//    }
//}