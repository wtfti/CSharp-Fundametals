using System;
using System.Linq;

class OddEvenCounter
{
    public static void Main()
    {
        int sets = int.Parse(Console.ReadLine());
        int countNumbers = int.Parse(Console.ReadLine());
        int[,] numbers = new int[sets, countNumbers];
        int[] countOddOrEven = new int[sets];
        string oddOrEven = Console.ReadLine();
        int devider = 0;
        if (oddOrEven == "odd")
        {
            devider = 1;
        }

        for (int row = 0; row < sets; row++)
        {
            for (int col = 0; col < countNumbers; col++)
            {
                numbers[row, col] = int.Parse(Console.ReadLine());
                if (numbers[row,col] % 2 == devider)
                {
                    countOddOrEven[row]++;
                }
            }
        }
        string rowAsWord = "";
        int oddOrEvenMax = countOddOrEven.Max();
        if (oddOrEvenMax != 0)
        {
            switch (Array.IndexOf(countOddOrEven, oddOrEvenMax) + 1)
            {
                case 1:
                    rowAsWord = "First";
                    break;
                case 2:
                    rowAsWord = "Second";
                    break;
                case 3:
                    rowAsWord = "Third";
                    break;
                case 4:
                    rowAsWord = "Fourth";
                    break;
                case 5:
                    rowAsWord = "Fifth";
                    break;
                case 6:
                    rowAsWord = "Sixth";
                    break;
                case 7:
                    rowAsWord = "Seventh";
                    break;
                case 8:
                    rowAsWord = "Eighth";
                    break;
                case 9:
                    rowAsWord = "Ninth";
                    break;
                case 10:
                    rowAsWord = "Tenth";
                    break;
            }
            Console.WriteLine("{0} set has the most {1} numbers: {2}", rowAsWord, oddOrEven, countOddOrEven.Max());
        }
        else
        {
            Console.WriteLine("No");
        }
       
    }
}