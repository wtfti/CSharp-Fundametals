using System;

class BasketBattle
{
    public static void Main()
    {
        int nakovPoints = 0;
        int simeonPoints = 0;

        string currentShooter = Console.ReadLine();
        int rounds = int.Parse(Console.ReadLine());
        int currentRound = 0;

        while (nakovPoints < 500 && simeonPoints < 500 && currentRound < rounds)
        {
            currentRound++;
            for (int shoots = 0; shoots < 2; shoots++)
            {
                int pointsToScore = int.Parse(Console.ReadLine());
                string successOrFail = Console.ReadLine();
                if (successOrFail == "success")
                {
                    if (currentShooter == "Simeon" && simeonPoints + pointsToScore <= 500)
                    {
                        simeonPoints += pointsToScore;
                    }
                    else if (nakovPoints + pointsToScore <= 500)
                    {
                        nakovPoints += pointsToScore;
                    }
                }
                Console.WriteLine(currentShooter);
                if (currentShooter == "Simeon")
                {
                    currentShooter = "Nakov";
                }
                else
                {
                    currentShooter = "Simeon";
                }
                if (simeonPoints == 500 || nakovPoints == 500)
                {
                    break;
                }
            }
            if (currentShooter == "Simeon")
            {
                currentShooter = "Nakov";
            }
            else
            {
                currentShooter = "Simeon";
            } 
        }
        if (simeonPoints == 500 || nakovPoints == 500)
        {
            Console.WriteLine("{0}\r\n{1}\r\n{2}", (simeonPoints == 500) ? "Simeon" : "Nakov",currentRound, (simeonPoints == 500) ? nakovPoints : simeonPoints);
        }
        else if (simeonPoints == nakovPoints)
        {
            Console.WriteLine("DRAW\r\n{0}",nakovPoints);
        }
        else
        {
            Console.WriteLine("{0}\r\n{1}", (simeonPoints > nakovPoints) ? "Simeon" : "Nakov", (simeonPoints > nakovPoints) ? simeonPoints-nakovPoints : nakovPoints - simeonPoints);
        }
    }
}