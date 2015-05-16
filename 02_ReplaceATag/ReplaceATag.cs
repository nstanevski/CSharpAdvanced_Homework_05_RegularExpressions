using System;
using System.Text;
using System.Text.RegularExpressions;

/*
 * Write a program that replaces in a HTML document given as string all the tags 
 * <a href="…">…</a> with corresponding tags [URL href=…]…[/URL]. 
 * Print the result on the console.
 */
class ReplaceATag
{
    static void Main()
    {
        StringBuilder builder = new StringBuilder();
        string input = Console.ReadLine();
        while (input.TrimEnd().Length > 0)
        {
            builder.Append(input);
            input = Console.ReadLine();
        }
            
        input = builder.ToString();

        string pattern = @"<a\s+href=([^>]+)>([^<]+)</a>";
        Regex regex = new Regex(pattern);
        string replacement = "[URL href=$1]$2[/URL]";
        string result = Regex.Replace(input, pattern, replacement);
        Console.WriteLine(result);
    }
}