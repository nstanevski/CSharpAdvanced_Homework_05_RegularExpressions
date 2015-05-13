using System;
using System.Text.RegularExpressions;

class SeriesOfLetters
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"(\w)\1+";
        string replacement = "$1";
        string result = Regex.Replace(input, pattern, replacement);
        Console.WriteLine(result);
    }
}