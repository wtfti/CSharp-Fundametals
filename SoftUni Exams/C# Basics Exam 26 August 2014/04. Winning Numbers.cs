using System;

class WinningNumbers
{
    public static void Main()
    {
        string input = Console.ReadLine();
        int sumOfLetters = 0;
        bool foundResult = false;
        foreach (var letter in input)
        {
            if (letter >= 'A' && letter <= 'Z')
            {
                sumOfLetters += (letter - '@');
            }
            else if (letter >= 'a' && letter <= 'z')
            {
                sumOfLetters += (letter - '`');
            }
            else
            {
                sumOfLetters += letter;
            }
        }

        for (int a1 = 0; a1 <= 9; a1++)
        {
            for (int a2 = 0; a2 <= 9; a2++)
            {
                for (int a3 = 0; a3 <= 9; a3++)
                {
                    for (int a4 = 0; a4<= 9; a4++)
                    {
                        for (int a5 = 0; a5 <= 9; a5++)
                        {
                            for (int a6 = 0; a6 <= 9; a6++)
                            {
                                if ((a1 * a2 * a3) == (a4 * a5 * a6) && (a1 * a2 * a3) == sumOfLetters)
                                {
                                    Console.WriteLine("{0}{1}{2}-{3}{4}{5}",a1,a2,a3,a4,a5,a6);
                                    foundResult = true;
                                }
                            }
                        }
                    }
                }
            }
        }
        if (!foundResult)
        {
            Console.WriteLine("No");
        }
    }
}