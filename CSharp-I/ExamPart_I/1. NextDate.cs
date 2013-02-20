using System;
//using System.Threading;
//using System.Globalization;
class NextDate
{
    static void Main()
    {
        System.Globalization.CultureInfo ci = null;
        ci = System.Globalization.CultureInfo.CreateSpecificCulture("de-DE");
        string day = Console.ReadLine();
        string month = Console.ReadLine();
        string year = Console.ReadLine();
        DateTime date = new DateTime();        
        
        date = DateTime.Parse(day + "." + month + "." + year, ci);
        Console.WriteLine("{0:d.M.yyyy}", date.AddDays(1));        
    }
}