using System;

class OddEvenJumps
{
    public static void Main()
    {
        string input = Console.ReadLine().ToLower();
        input = input.Replace(" ", "");
        int oddJump = int.Parse(Console.ReadLine());
        int evenJump = int.Parse(Console.ReadLine());

        string oddLetters = "";
        string evenLetters = "";
        long oddSum = 0;
        long evenSum = 0;

        for (int letter = 0; letter < input.Length; letter++)
        {
            if (letter % 2 == 0 && input[letter] != ' ')
            {
                oddLetters += input[letter];
            }
            else if (letter%2 != 0 && input[letter] != ' ')
            {
                evenLetters += input[letter];
            }
        }

        for (int index = 0, counter = 1; index < oddLetters.Length; index++)
        {
            if (counter < oddJump)
            {
                oddSum += oddLetters[index];
                counter++;
            }
            else
            {
                counter = 1;
                oddSum *= oddLetters[index];
            }
        }
        for (int index = 0, counter = 1; index < evenLetters.Length; index++)
        {
            if (counter < evenJump)
            {
                evenSum += evenLetters[index];
                counter++;
            }
            else
            {
                counter = 1;
                evenSum *= evenLetters[index];
            }
        }
        Console.WriteLine("Odd: {0}\r\nEven: {1}",oddSum.ToString("X"),evenSum.ToString("X"));
    }
}