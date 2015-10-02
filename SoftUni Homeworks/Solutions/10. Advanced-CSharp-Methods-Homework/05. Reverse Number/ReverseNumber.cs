using System;
using System.Globalization;

class ReverseNumber
{
    static void Main()
    {
        double reversedNumber = GetReverseNumber(double.Parse(Console.ReadLine()));
        Console.WriteLine(reversedNumber);
    }

    private static double GetReverseNumber(double number)
    {
        string[] LeftRightSides = number.ToString(CultureInfo.InvariantCulture).Split('.');
        string result;
        Array.Reverse(LeftRightSides);
        if (LeftRightSides.Length > 1 && LeftRightSides[1] != "0")
        {
            result = string.Format("{0}.{1}", ReverseString(LeftRightSides[0]),ReverseString(LeftRightSides[1])); // dot/comma - depends on Culture
        }
        else
        {
            result = string.Format("{0}", ReverseString(LeftRightSides[0]));
        }
        return Convert.ToDouble(result);
    }

    private static string ReverseString(string text)
    {
        char[] charArray = text.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}