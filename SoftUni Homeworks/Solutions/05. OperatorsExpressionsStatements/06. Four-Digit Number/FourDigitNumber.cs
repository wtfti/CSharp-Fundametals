using System;
class FourDigitNumber
{
    private static void Main()
    {
        Console.Write("Number: ");
        int number = int.Parse(Console.ReadLine());
        int sum = 0;
        string numberString = number.ToString();
        while (number <= 1000 && number >= 9999)
        {
            Console.WriteLine("Invalid Number! Number must be between 1000-9999");
            number = int.Parse(Console.ReadLine());
        }
        for (int i = 0; i < numberString.Length; i++)
        {
            sum += Convert.ToInt32(numberString[i].ToString());
        }
        Console.WriteLine("Sum digits: {0}", sum);
        Console.WriteLine("Reversed: {0}",ReverseString(numberString));
        string lastDigitInFront = numberString[3].ToString() + numberString[0] + numberString[1] + numberString[2];
        Console.WriteLine("last digit in front: {0}", lastDigitInFront);
        string secondThirdDigitsExchanged = numberString[0].ToString() + numberString[2] + numberString[1] + numberString[3];
        Console.WriteLine("second and third digits exchanged: {0}", secondThirdDigitsExchanged);
    }

    public static string ReverseString(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
}
