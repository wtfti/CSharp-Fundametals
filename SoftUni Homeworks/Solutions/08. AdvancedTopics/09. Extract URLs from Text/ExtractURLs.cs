using System;
using System.Text.RegularExpressions;

class ExtractURLs
{
    private static void Main()
    {
        //Version 1 using LINQ
        //string rawString = Console.ReadLine();
        //var links = rawString.Split("\t\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        //    .Where(s => s.StartsWith("http://") || s.StartsWith("www.") || s.StartsWith("https://"));
        //foreach (string s in links)
        //{
        //    Console.WriteLine(s);
        //}

        //Version 2 using Regex                                                                                       // \b       -matches a word boundary (spaces, periods..etc)
        Regex linkParser = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase); // (?:      -define the beginning of a group, the ?: specifies not to capture the data within this group.                                                                                        
        string rawString = Console.ReadLine();                                                                        // https?://  - Match http or https (the '?' after the "s" makes it optional)
        foreach (Match m in linkParser.Matches(rawString))                                                            // |        -OR
        {                                                                                                             // www\.    -literal string, match www. (the \. means a literal ".")
            Console.WriteLine(m.Value);                                                                               // )        -end group
        }                                                                                                             // \S+      -match a series of non-whitespace characters.
    }                                                                                                                 // \b       -match the closing word boundary.
}