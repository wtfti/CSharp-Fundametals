using System;
using System.Linq;

class LongestWord
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] { ' ', '.' }).ToArray();
        Array.Sort(input, (x, y) => y.Length.CompareTo(x.Length));
        Console.WriteLine(input[0]);
    }
}