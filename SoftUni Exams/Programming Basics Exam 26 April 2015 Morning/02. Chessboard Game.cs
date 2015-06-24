using System;

class Chessboard
{
    public static void Main()
    {
        int sizeBoard = int.Parse(Console.ReadLine());
        string word = Console.ReadLine();
        bool blackTeam = true;
        int blackTeamScore = 0;
        int whiteTeamScore = 0;
        int countLetter = 0;
        int currentLetter;

        for (int row = 0; row < sizeBoard*sizeBoard; row++)
        {
            if (countLetter >= word.Length)
            {
                continue;
            }
            if (char.IsLetterOrDigit(word[countLetter]))
            {
                currentLetter = word[countLetter];
                if (char.IsUpper(word[countLetter]))
                {
                    blackTeam = !blackTeam;
                }
                if (blackTeam)
                {
                    blackTeamScore += currentLetter;
                    if (!char.IsUpper(word[countLetter]))
                    {
                        blackTeam = !blackTeam;
                    }
                }
                else
                {
                    whiteTeamScore += currentLetter;
                    if (!char.IsUpper(word[countLetter]))
                    {
                        blackTeam = !blackTeam;
                    }
                }
            }
            else
            {
                blackTeam = !blackTeam;
            }
            countLetter++;
        }

        if (blackTeamScore > whiteTeamScore)
        {
            Console.WriteLine("The winner is: black team\r\n{0}",blackTeamScore-whiteTeamScore);
        }
        else if (blackTeamScore < whiteTeamScore)
        {
            Console.WriteLine("The winner is: white team\r\n{0}", whiteTeamScore-blackTeamScore);
        }
        else
        {
            Console.WriteLine("Equal result: {0}",blackTeamScore);
        }
    }
}