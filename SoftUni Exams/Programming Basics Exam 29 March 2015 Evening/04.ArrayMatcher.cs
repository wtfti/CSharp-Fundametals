using System;
using System.Collections.Generic;
using System.Linq;

class ArrayMatcher
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split('\\').ToArray();
        char[] firstArray = input[0].ToCharArray();
        char[] secondArray = input[1].ToCharArray();
        string command = input[2];

        switch (command)
        {
            case "join":
                IEnumerable<char> join = firstArray.Intersect(secondArray);
                char[] joinResult = join.ToArray();
                Array.Sort(joinResult);
                foreach (var ch in joinResult)
                {
                    Console.Write(ch);
                }
                Console.WriteLine();
                break;
            case "right exclude":
                IEnumerable<char> rightExclude = firstArray.Except(secondArray);
                char[] rightResult = rightExclude.ToArray();
                Array.Sort(rightResult);
                foreach (var ch in rightResult)
                {
                    Console.Write(ch);
                }
                Console.WriteLine();
                break;
            case "left exclude":
                IEnumerable<char> leftExclude = secondArray.Except(firstArray);
                char[] leftResult = leftExclude.ToArray();
                Array.Sort(leftResult);
                foreach (var ch in leftResult)
                {
                    Console.Write(ch);
                }
                Console.WriteLine();
                break;
        }
    }
}