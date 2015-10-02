using System;
class HexToDecimal
{
    static void Main()
    {
        Console.Write("hex: ");
        string input = Console.ReadLine();
        int currentNumber = 0;
        long result = 0;

        for (int i = 0; i < input.Length; i++)
        {
            switch (input[i])
            {
                case 'A':
                    currentNumber = 10;
                    break;
                case 'B':
                    currentNumber = 11;
                    break;
                case 'C':
                    currentNumber = 12;
                    break;
                case 'D':
                    currentNumber = 13;
                    break;
                case 'E':
                    currentNumber = 14;
                    break;
                case 'F':
                    currentNumber = 15;
                    break;
                default:
                    currentNumber = Convert.ToInt16(input[i].ToString());
                    break;

            }
            result += currentNumber*(long)Math.Pow(16, input.Length-(1+i));
        }
        Console.WriteLine(result);
    }
}