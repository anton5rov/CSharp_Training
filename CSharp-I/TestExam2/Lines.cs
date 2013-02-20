using System;
class Lines
{
    static void Main()
    {
        int[] numbers = new int [8];
        int maxLine = 0;
        int maxLineCount = 0;
        string bigString = "0";
        // add binary represented numbers to big string, separated by '0'
        for (int i = 0; i < 8; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
            bigString += (Convert.ToString(numbers[i], 2) + "0");
        }
        // add bit groups (columns) separated by '0'
        for (int bit = 0; bit < 8; bit++)
        {
            string bitGroup = "";
            for (int num = 0; num < 8; num++)
            {
                bitGroup += ((numbers[num] >> bit) & 1);
            }
            bigString += (bitGroup + "0");
        }
        //split to groups, separated by '0'
        string[] split = bigString.Split('0');
        for (int i = 0; i < split.Length; i++)
        {
            if (split[i].Length > maxLine) maxLine = split[i].Length; // find biggest line
        }        
        for (int i = 0; i < split.Length; i++) // count biggest lines
        {
            if (split[i].Length == maxLine) maxLineCount++;
        }
        Console.WriteLine(maxLine);
        if (maxLine == 1) maxLineCount /= 2;
        Console.WriteLine(maxLineCount);        
    }
}