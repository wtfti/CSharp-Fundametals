using System;

class DNA
{
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        char startLetter = char.Parse(Console.ReadLine());
        int dotCount = 3;
        bool middleReached = false;
        while (size > 0)
        {
            if (!middleReached)
            {
                if (dotCount == 4)
                {
                    dotCount--;
                }
                Console.Write(new string('.', dotCount));
                startLetter = PrintLetters(startLetter, dotCount);
                Console.WriteLine(new string('.', dotCount));
                dotCount--;
                size--; 
            }
            else
            {
                if (dotCount == 3)
                {
                    middleReached = false;
                }
                Console.Write(new string('.', dotCount));
                startLetter = PrintLetters(startLetter, dotCount);
                Console.WriteLine(new string('.', dotCount));

                dotCount++;
                size--;
            }
            if (dotCount < 0)
            {
                dotCount = 1;
                middleReached = true;
            }
        }
    }

    private static char PrintLetters(char currentChar,int dots)
    {
        for (int i = 0; i < 7-dots*2; i++)
        {
            if (currentChar > 'G')
            {
                currentChar = 'A';
            }
            Console.Write(new string(currentChar, 1));
            currentChar++;
        }
        return currentChar;
    }
}
