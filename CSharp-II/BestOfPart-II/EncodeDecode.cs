// Task: Write a program that encodes and decodes a string using given encryption key (cipher). 
// The key consists of a sequence of characters. The encoding/decoding is done by performing 
// XOR (exclusive or) operation over the first letter of the string with the first of the key, 
// the second – with the second, etc. When the last key character is reached, the next is the first.



using System;
using System.Text;
class EncodeDecode
{
    static void Main()
    {
        string key = "secretkey";
        Console.Write("Input a text: ");
        string text = Console.ReadLine();
        string encodedText = Encode_Decode(text, key);
        Console.WriteLine("Encoded text:");
        Console.WriteLine(encodedText);        
        text = Encode_Decode(encodedText, key);        
        Console.WriteLine("\nDecoded text:");
        Console.WriteLine(text);
    }
    //-------------------------
    private static string Encode_Decode(string text, string key)
    {
        StringBuilder encoded = new StringBuilder();
        for (int i = 0; i < text.Length; i++)
        {
            encoded.Append((char)(text[i] ^ key[i % key.Length]));
        }
        return encoded.ToString();
    }
}
