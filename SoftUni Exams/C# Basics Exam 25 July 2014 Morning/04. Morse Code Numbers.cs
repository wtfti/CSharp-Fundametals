using System;

class MorseCodeNumbers
{
    public static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        int sum = 0;
        while (number > 0)
        {
            sum += number % 10;
            number /= 10;
        }
        bool foundResult = false;

        for (int a1 = 0; a1 <= 5; a1++)
        {
            for (int a2 = 0; a2 <= 5; a2++)
            {
                for (int a3 = 0; a3 <= 5; a3++)
                {
                    for (int a4 = 0; a4 <= 5; a4++)
                    {
                        for (int a5 = 0; a5 <= 5; a5++)
                        {
                            for (int a6 = 0; a6 <= 5; a6++)
                            {
                                if (a1*a2*a3*a4*a5*a6 == sum)
                                {
                                    foundResult = true;
                                    MorseGenerator(new[] {a1,a2,a3,a4,a5,a6});
                                }
                            }
                        }
                    }
                }
            }
        }
        if (!foundResult)
        {
            Console.WriteLine("No");
        }
    }

    private static void MorseGenerator(int[] data)
    {
        for (int index = 0; index <= 5; index++)
        {
            switch (data[index])
            {
                case 0:
                    Console.Write("-----|");
                    break;
                case 1:
                    Console.Write(".----|");
                    break;
                case 2:
                    Console.Write("..---|");
                    break;
                case 3:
                    Console.Write("...--|");
                    break;
                case 4:
                    Console.Write("....-|");
                    break;
                case 5:
                    Console.Write(".....|");
                    break;
            }
        }
        Console.WriteLine();
    }
}