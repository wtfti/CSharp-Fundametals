using System;

class LettersSymbolsNumbers
{
    public static void Main()
    {
        int numberOfStrings = int.Parse(Console.ReadLine());
        int sumLetters = 0;
        int sumNumbers = 0;
        int sumSymbols = 0;
        while (numberOfStrings > 0)
        {
            string currentString = Console.ReadLine();

            foreach (var symbol in currentString)
            {
                if (symbol >= 'A' && symbol <= 'Z')
                {
                    sumLetters += 10 * (symbol - '@');
                }
                else if (symbol >= 'a' && symbol <= 'z')
                {
                    sumLetters += 10 * (symbol - '`');
                }
                else if (symbol >= '0' && symbol <= '9')
                {
                    sumNumbers += Convert.ToInt32(symbol.ToString())*20;
                }
                else if (!char.IsWhiteSpace(symbol))
                {
                    sumSymbols += 200;
                }
            }
            numberOfStrings--;
        }
        Console.WriteLine("{0}\r\n{1}\r\n{2}", sumLetters, sumNumbers, sumSymbols);
    }
}