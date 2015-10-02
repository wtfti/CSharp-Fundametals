using System;

class SpyHard
{
    public static void Main()
    {
        int baseSystem = int.Parse(Console.ReadLine());
        string message = Console.ReadLine();

        int messageSum = CalcMessage(message);
        Console.WriteLine(baseSystem.ToString() + message.Length + IntegerToAnyNumeralSystem(messageSum,baseSystem));
    }

    private static string IntegerToAnyNumeralSystem(int number, int system)
    {
        string result = "";
        while (number > 0)
        {
            result = number%system + result;
            number /= system;
        }
        return result;
    }

    private static int CalcMessage(string msg)
    {
        int sum = 0;
        foreach (var letter in msg)
        {
            if (letter >= 'A' && letter <= 'Z')
            {
                sum += (letter - '@');
            }
            else if (letter >= 'a' && letter <= 'z')
            {
                sum += (letter - '`');
            }
            else
            {
                sum += letter;
            }
        }

        return sum;
    }
}