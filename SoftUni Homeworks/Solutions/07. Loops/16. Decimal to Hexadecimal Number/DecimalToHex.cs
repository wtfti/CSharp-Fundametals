using System;
class DecimalToHex
{
    static void Main()
    {
        Console.Write("number: ");
        long number = long.Parse(Console.ReadLine());
        string result = "";

        while (number > 0)
        {
            switch (number % 16)
            {
                case 10:
                    result = 'A' + result;
                    break;   
                case 11:     
                    result = 'B' + result;
                    break;   
                case 12:     
                    result = 'C' + result;
                    break;   
                case 13:     
                    result = 'D' + result;
                    break;   
                case 14:     
                    result = 'E' + result;
                    break;   
                case 15:     
                    result = 'F' + result;
                    break;
                default:
                    result = number % 16 + result;
                    break;
            }
            number /= 16;
        }
        Console.WriteLine(result);
    }
}