using System;

class GameOfBits
{
    public static void Main()
    {
        uint number = uint.Parse(Console.ReadLine());
        string command = Console.ReadLine();
        uint currentNumber = 0;
        int currentNumberCount = 0;
        int count = 0;

        while (command != "Game Over!")
        {
            int positions = Convert.ToString(number, 2).Length;
            if (command == "Odd")
            {
                for (int pos = 0; pos < positions; pos++)
                {
                    if (pos % 2 == 0)
                    {
                        uint mask = (number >> pos) & 1;
                        if (mask == 1)
                        {
                            currentNumber |= ((uint)1 << currentNumberCount);
                        }
                        currentNumberCount++;
                    }
                }
                number = currentNumber;
                currentNumber = 0;
                currentNumberCount = 0;
            }
            else if (command == "Even")
            {
                for (int pos = 0; pos < positions; pos++)
                {
                    if (pos % 2 != 0)
                    {
                        uint mask = (number >> pos) & 1;
                        if (mask == 1)
                        {
                            currentNumber |= ((uint)1 << currentNumberCount);
                        }
                        currentNumberCount++;
                    }
                }
                number = currentNumber;
                currentNumber = 0;
                currentNumberCount = 0;
            }
            
            command = Console.ReadLine();
        }
        for (int pos = 0; pos < Convert.ToString(number, 2).Length; pos++)
        {
            uint mask = (number >> pos) & 1;
            if (mask == 1)
            {
                count++;
            }
        }
        Console.WriteLine("{0} -> {1}", number, count);
    }
}