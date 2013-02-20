// Task: We are given a string containing a list of forbidden words 
// and a text containing some of these words. 
// Write a program that replaces the forbidden words with asterisks.

//Solution with Regex.


using System;
using System.Text.RegularExpressions;
class ForbidenWords
{
    static void Main()
    {
        string text = "Microsoft announced its next generation PHP compiler today. " +
                      "It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";        
        Regex regex = new Regex(@"Microsoft|PHP|CLR");
        Match match = regex.Match(text);         
        while (match.Success)
        {
            text = ConvertMatched(text, match);
            match = match.NextMatch();
        }
        Console.WriteLine(text);
    }

    private static string ConvertMatched(string text, Match match)
    {
        string asterics = new String('*', match.Length);
        string newText = text.Replace(match.Value.ToString(), asterics);
        return newText;
    }
}