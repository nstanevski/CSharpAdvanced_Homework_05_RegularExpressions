using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


class QuerryMess
{
    private static Dictionary<string, List<string>> dict =
        new Dictionary<string, List<string>>();

    private static void ProcessQuery(string line)
    {
        string url = @"^[^>?]+\?"; //catch and remove leading part, up to '?'
        Regex urlRegex = new Regex(url);
        string res = urlRegex.Replace(line, "");

        string[] pairsStr = res.Split('&');
        foreach (string pairStr in pairsStr)
        {
            //replace encoded spaces with literal ones:
            string spaceEnc = @"(\+|%20)";
            res = Regex.Replace(pairStr, spaceEnc, " ");
            string[] keyValueAttr = res.Split('=');
            string key = keyValueAttr[0].Trim();
            string value = keyValueAttr[1].Trim();
            if (dict.ContainsKey(key))
                dict[key].Add(value);
            else
            {
                List<string> values = new List<string>();
                values.Add(value);
                dict[key] = values;
            }
        }

    }

    static void Main()
    {
        string line;
        do{
            line = Console.ReadLine();
            if (line == "END")
                break;
            ProcessQuery(line);
            foreach (KeyValuePair<string, List<string>> pair in dict)
            {
                string valueStr = string.Join(", ", pair.Value.ToArray());
                Console.Write("{0}=[{1}]", pair.Key, valueStr);
            }
            dict.Clear();
            Console.WriteLine();

        }while(true);
    } 
}