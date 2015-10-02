using System;
using System.Collections.Generic;

class MagicCarNumbers
{
    public static void Main()
    {
        int magicNumber = int.Parse(Console.ReadLine());
        char[] letters = new[] { 'A', 'B', 'C', 'E', 'H', 'K', 'M', 'P', 'T', 'X' };
        int counter = 0;
        List<string> carNumbers = new List<string>();

        for (int num1 = 0; num1 <= 9; num1++)
        {
            for (int num2 = 0; num2 <= 9; num2++)
            {
                for (int letterX = 0; letterX < letters.Length; letterX++)
                {
                    for (int letterY = 0; letterY < letters.Length; letterY++)
                    {
                        int currentCarWeight = 40;
                        currentCarWeight = CalcWeight(new char[] { letters[letterX], letters[letterY] }, currentCarWeight);
                        if (num2*3 + num1 + currentCarWeight == magicNumber)
                        {
                            //Console.WriteLine("{0}{1}{2}{3}{4}{5}", num2, num2, num2, num1, letters[letterX], letters[letterY]);
                            counter++;
                        }
                        else if (num1 * 3 + num2 + currentCarWeight == magicNumber)
                        {
                            //Console.WriteLine("{0}{1}{2}{3}{4}{5}", num1, num1, num1, num2, letters[letterX], letters[letterY]);
                            counter++;
                        }
                        else if ((num1 * 2) + (num2 * 2) + currentCarWeight == magicNumber)
                        {
                            //Console.WriteLine("{0}{1}{2}{3}{4}{5}", num1, num1, num2, num2, letters[letterX], letters[letterY]);
                            counter++;
                        }
                        else if ((num2 + num1 + num2 + num1) + currentCarWeight == magicNumber)
                        {
                            //Console.WriteLine("{0}{1}{2}{3}{4}{5}", num1, num1, num1, num1, letters[letterX], letters[letterY]);
                            counter++;
                        }
                    }
                }
            }
        }
        Console.WriteLine(counter);
    }

    private static int CalcWeight(char[] keys, int sum)
    {
        for (int i = 0; i < keys.Length; i++)
        {
            switch (keys[i])
            {
                case 'A':
                    sum += 10;
                    break;
                case 'B':
                    sum += 20;
                    break;
                case 'C':
                    sum += 30;
                    break;
                case 'E':
                    sum += 50;
                    break;
                case 'H':
                    sum += 80;
                    break;
                case 'K':
                    sum += 110;
                    break;
                case 'M':
                    sum += 130;
                    break;
                case 'P':
                    sum += 160;
                    break;
                case 'T':
                    sum += 200;
                    break;
                case 'X':
                    sum += 240;
                    break;
            }
        }
        return sum;
    }
}
