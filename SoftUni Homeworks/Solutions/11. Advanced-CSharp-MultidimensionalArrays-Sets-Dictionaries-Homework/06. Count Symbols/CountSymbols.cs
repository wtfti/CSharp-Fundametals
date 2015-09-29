using System;
using System.Linq;

class CountSymbols
    {
        static void Main()
        {
            string text = Console.ReadLine();
            char[] sortedText = text.Distinct().ToArray();
            Array.Sort(sortedText, StringComparer.Ordinal);
            int[] charCounts = new int[sortedText.Length];

            for (int currentChar = 0; currentChar < sortedText.Length; currentChar++)
            {
                int count = text.Count(a => a == sortedText[currentChar]);
                charCounts[currentChar] = count;
            }

            for (int i = 0; i < charCounts.Length; i++)
            {
                Console.WriteLine("{0}: {1} time/s", sortedText[i], charCounts[i]);
            }
        }
    }