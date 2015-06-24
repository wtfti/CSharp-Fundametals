using System;
using System.Numerics;

class PetarGame
{
    public static void Main()
    {
        ulong startingNumber = ulong.Parse(Console.ReadLine());
        ulong endNumber = ulong.Parse(Console.ReadLine());
        string replacementString = Console.ReadLine();
        BigInteger sum = 0;

        for (ulong i = startingNumber; i < endNumber; i++)
        {
            if (i % 5 == 0)
            {
                sum += i;
            }
            else
            {
                sum += i%5;
            }
        }
        
        string sumToString = sum.ToString();
        string result = "";
        if (sum % 2 == 0)
        {
            int firstDigit = sumToString[0];
            for (int i = 0; i < sumToString.Length; i++)
            {
                if (sumToString[i] != firstDigit)
                {
                    result = result + sumToString[i];
                }
                else
                {
                    result = result + replacementString;
                }
            }
        }
        else
        {
            int lastDigit = sumToString[sumToString.Length - 1];
            for (int i = 0; i < sumToString.Length; i++)
            {
                if (sumToString[i] != lastDigit)
                {
                    result = result + sumToString[i];
                }
                else
                {
                    result = result + replacementString;
                }
            }
        }

        Console.WriteLine(result);
    }
}