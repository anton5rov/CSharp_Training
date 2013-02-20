//Task: Write a program that extracts from a given text all sentences containing given word.

//Solution with Regex. Searching string "in".

using System;
using System.Text.RegularExpressions;
class SentencesWithGivenWord
{
    static void Main()
    {
        string text = "We are living in a yellow submarine. We don't have anything else. " +
                      "Inside the submarine is very tight. " +
                      "So we are drinking all the day. We will move out of it in 5 days.";
        string target = "in";
        Regex regex = new Regex(@"[A-Z][\w ,']+ " + target + @"\s*[\w ,']*[\.!?]+");
        Match match = regex.Match(text);
        while (match.Success)
        {
            Console.WriteLine(match);
            match = match.NextMatch();            
        }        
    }
}
