using System;
class PrintDeck
{
    static void Main()
    {
        for (int cards = 2; cards <= 14; cards++)
        {
            for (int kind = 0; kind < 4; kind++)
            {
                switch (cards)
                {
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                        Console.Write(cards);
                        break;
                    case 11:
                        Console.Write("J");
                        break;
                    case 12:
                        Console.Write("Q");
                        break;
                    case 13:
                        Console.Write("K");
                        break;
                    case 14:
                        Console.Write("A");
                        break;
                }
                if (kind == 0)
                {
                    Console.Write("♣ ");
                }
                else if (kind == 1)
                {
                    Console.Write("♦ ");
                }
                else if (kind == 2)
                {
                    Console.Write("♥ ");
                }
                else
                {
                    Console.Write("♠");
                }
            }
            Console.WriteLine();
        }
    }
}