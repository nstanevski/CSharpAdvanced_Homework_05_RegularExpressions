using System;
using System.Text.RegularExpressions;

/*
 * Write a program that reads a keyword and some text from the console and prints
 * all sentences from the text, containing that word. A sentence is any sequence
 * of words ending with '.', '!' or '?'. 
 */

class SentenceExtractor
{
    static void Main()
    {
        string keyword = Console.ReadLine().Trim();
        keyword = @"\b"+keyword+@"\b";
        string text = Console.ReadLine();

        // \u2019 and \u2013 are en-dash and apostrophy
        string sentencePattern = @"[A-Z][A-Za-z\s\-\,\:\'\u2019\u2013]*[\.\?\!]";
        Regex sentenceRegex = new Regex(sentencePattern);
        MatchCollection matches = sentenceRegex.Matches(text);
        foreach (Match match in matches)
        {
            string sentence = match.Value;
            if (Regex.IsMatch(sentence, keyword))
                Console.WriteLine(sentence);
        }
    }
}