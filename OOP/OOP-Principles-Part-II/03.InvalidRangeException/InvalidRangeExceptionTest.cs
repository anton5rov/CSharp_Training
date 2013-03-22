using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InvalidRangeException
{
    class InvalidRangeExceptionTest
    {
        static void Main()
        {
            int start = 0;
            int end = 100;

            //-------------------- Int in the range
            int inRange = 15;            
            try
            {
                if(CheckRange<int>(start, end, inRange))
                Console.WriteLine("{0} is in the specified range!", inRange);
            }
            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine(e.Message); 
            }

            //-------------------- Int out of the range
            Console.WriteLine();
            int notInRange = 101;
            try
            {
                if (CheckRange<int>(start, end, notInRange))
                    Console.WriteLine("{0} is in the specified range!", notInRange);
            }
            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine(e.Message);
            }

            //------------------- Date in the range
            Console.WriteLine();
            DateTime before = new DateTime(1980, 1, 1);
            DateTime after = new DateTime(2013, 12, 31);
            DateTime dateinRange = new DateTime(2010, 1, 1);
            try
            {
                if (CheckRange<DateTime>(before, after, dateinRange))
                    Console.WriteLine("{0:D} is in the specified range!", dateinRange);
            }
            catch (InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e.Message);
            }

            //------------------- Date out of the range
            Console.WriteLine();            
            DateTime dateNotInRange = new DateTime(2014, 3, 1);
            try
            {
                if (CheckRange<DateTime>(before, after, dateNotInRange))
                    Console.WriteLine("{0:D} is in the specified range!", dateNotInRange);
            }
            catch (InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static bool CheckRange<T>(T start, T end, T element)
            where T:IComparable<T>
        {
            if (element.CompareTo(start) <= 0 || element.CompareTo(end) >= 0)
            {
                throw new InvalidRangeException<T>(start, end);
            }
            return true;            
        }
    }
}
