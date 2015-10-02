using System;
class LastDigitNumber
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine(LastDigitNumberAsWord(number));
    }

    static string LastDigitNumberAsWord(int number)
    {
        byte lastDigit = (byte)(number%10);

        switch (lastDigit)
        {
            case 0:
                return "zero";
            case 1:
                return "one";
            case 2:
                return "two";
            case 3:
                return "three";
            case 4:
                return "four";
            case 5:
                return "five";
            case 6:
                return "six";
            case 7:
                return "seven";
            case 8:
                return "eight";
            default:
                return "nine";
        }
    }
}