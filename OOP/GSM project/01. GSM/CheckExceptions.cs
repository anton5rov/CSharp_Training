using System;

namespace GSM
{
    static class CheckExceptions
    {
        public static bool CheckPositive(string parameter, int value)
        {
            if (value <= 0) throw new ArgumentException(parameter + " should be positive!");
            return true;
 
        }
        public static bool CheckNonNegative(string parameter, int value)
        {
            if (value < 0) throw new ArgumentException(parameter + " shouldn't be negative!");
            return true;

        }
    }
}
