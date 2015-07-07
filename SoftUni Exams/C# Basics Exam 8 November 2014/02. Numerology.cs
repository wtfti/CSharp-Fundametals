using System;
using System.Linq;

class Numerology
{
    public static void Main()
    {
        string[] input = Console.ReadLine().Split(new char[] {' ', '.'}).ToArray();
        long multiply = Convert.ToInt32(input[0])*Convert.ToInt32(input[1])*Convert.ToInt32(input[2]);
        if (Convert.ToInt32(input[1]) % 2 != 0)
        {
            multiply *= multiply;
        }
        int sum = 0;
        foreach (var letter in input[3])
        {
            if (letter >= 'A' && letter <= 'Z')
            {
                sum += 2*(letter - '@');
            }
            else if (letter >= 'a' && letter <= 'z')
            {
                sum += (letter - '`');
            }
            else
            {
                sum += Convert.ToInt32(letter.ToString());
            }
        }
        multiply += sum;
        long celestialNumber = multiply;
        if (multiply > 13)
        {
            celestialNumber = 0;
            string currentNumber = multiply.ToString();
            while (true)
            {
                for (int eachDigit = 0; eachDigit < currentNumber.Length; eachDigit++)
                {
                    celestialNumber += Convert.ToInt32(currentNumber[eachDigit].ToString());
                }
                if (celestialNumber <= 13)
                {
                    break;
                }
                currentNumber = celestialNumber.ToString();
                celestialNumber = 0;
            }
        }
        Console.WriteLine(celestialNumber);
    }
}