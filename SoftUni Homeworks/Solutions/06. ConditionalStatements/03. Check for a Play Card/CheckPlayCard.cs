using System;
class CheckPlayCard
{
    static void Main()
    {
        Console.Write("Enter card: ");
        string input = Console.ReadLine();
        bool isValidCard = false;
        switch (input)
        {
            case "2":
                isValidCard = true;
                break;
            case "3":
                isValidCard = true;
                break;
            case "4":
                isValidCard = true;
                break;
            case "5":
                isValidCard = true;
                break;
            case "6":
                isValidCard = true;
                break;
            case "7":
                isValidCard = true;
                break;
            case "8":
                isValidCard = true;
                break;
            case "9":
                isValidCard = true;
                break;
            case "10":
                isValidCard = true;
                break;
            case "J":
                isValidCard = true;
                break;
            case "Q":
                isValidCard = true;
                break;
            case "K":
                isValidCard = true;
                break;
            case "A":
                isValidCard = true;
                break;
        }
        Console.WriteLine(isValidCard);
    }
}