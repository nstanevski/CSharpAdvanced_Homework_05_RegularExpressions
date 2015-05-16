using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

//https://judge.softuni.bg/Contests/Practice/Index/34#2

class ValidUsernames
{
    static void Main()
    {
        string line = Console.ReadLine().Trim();
        string[] usernames = Regex.Split(line, @"[\s/\\\(\)]+");
        List<string> validUsernames = new List<string>();

        //store only valid usernames in the list
        string validUsernamePat = @"^[A-Za-z]\w+$";
        foreach (string username in usernames)
        {
            if (username.Length >= 3 && username.Length <= 25
                && Regex.IsMatch(username, validUsernamePat))
                validUsernames.Add(username);
        }

        //find 2 consecutive ones with the max sum of their lengths:
        int maxSumLen = -1, currentSumLen = -1, maxSumLenIndex = -1;
        for (int i = 0; i < validUsernames.Count - 1; i++)
        {
            currentSumLen = validUsernames[i].Length + validUsernames[i + 1].Length;
            if (currentSumLen > maxSumLen)
            {
                maxSumLen = currentSumLen;
                maxSumLenIndex = i;
            }
        }

        Console.WriteLine("{0}\n{1}", validUsernames[maxSumLenIndex],
            validUsernames[maxSumLenIndex + 1]);
    }
}