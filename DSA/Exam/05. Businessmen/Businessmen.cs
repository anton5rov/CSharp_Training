using System;

namespace Exam
{
    class Businessmen
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            long[] memo = new long[71]; 
            
            for (int i = 0; i <= 70; i++)
            {
                memo[i] = 0;
            }

            memo[0] = 1;
            memo[2] = 1;

            for (int i = 4; i <= n; i+=2)
            {
                memo[i] = Calc(memo,i);
                
            }

            Console.WriteLine(memo[n]);
        }

        private static long Calc(long[] memo, int n)
        {
            long result = 0;
            for (int i = 0; i < n; i+=2)
            {
                result += memo[i] * memo[n - 2 - i];
            }
            return result;
        }
    }
}