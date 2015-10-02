using System;
using System.Linq;

class Gambling
{
    public static void Main()
    {
        const int totalPossibleHands = 28561;
        double cash = double.Parse(Console.ReadLine());
        string[] houseHand = Console.ReadLine().Split().ToArray();
        int myHandPower = CalcWeight(houseHand);
        int counter = 0;
        for (int card1 = 2; card1 <= 14; card1++)
        {
            for (int card2 = 2; card2 <= 14; card2++)
            {
                for (int card3 = 2; card3 <= 14; card3++)
                {
                    for (int card4 = 2; card4 <= 14; card4++)
                    {
                        if (card1 + card2 + card3 + card4 > myHandPower)
                        {
                            counter++;
                        }
                    }
                }
            }
        }
        double probility = ((double)counter / totalPossibleHands) * 100;
        string decision;
        double pot = ((cash*2)*probility)/100;
        if (probility < 50)
        {
            decision = "FOLD";
        }
        else
        {
            decision = "DRAW";
        }
        Console.WriteLine("{0}\r\n{1:0.00}",decision,pot);
    }

    private static int CalcWeight(string[] hand)
    {
        int strenght = 0;
        foreach (var card in hand)
        {
            if (card == "J")
            {
                strenght += 11;
            }
            else if (card == "Q")
            {
                strenght += 12;
            }
            else if (card == "K")
            {
                strenght += 13;
            }
            else if (card == "A")
            {
                strenght += 14;
            }
            else
            {
                strenght += Convert.ToInt32(card);
            }
        }
        return strenght;
    }
}