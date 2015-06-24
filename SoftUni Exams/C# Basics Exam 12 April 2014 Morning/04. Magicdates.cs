using System;

class Magic
{
    private static bool FoundResult;
    static void Main()
    {
        int startYear = int.Parse(Console.ReadLine());
        int endYear = int.Parse(Console.ReadLine());
        int magic = int.Parse(Console.ReadLine());

        MagicWeight(startYear,endYear,magic);
        if (!FoundResult)
        {
            Console.WriteLine("No");
        }
    }

    private static void CalcDate(DateTime date, int magicNumber)
    {
        string dateString = date.ToString("dd-MM-yyyy");
        int[] numbers = new int[8];
        int sum = 0;
        int count = 0;
        for (int i = 0; i < dateString.Length; i++)
        {
            if (char.IsDigit(dateString[i]))
            {
                numbers[count] = Convert.ToInt32(dateString[i].ToString());
                count++;
            }
        }
        for (int numbersCount = 0; numbersCount < numbers.Length; numbersCount++)
        {
            for (int number = numbersCount+1; number < numbers.Length; number++)
            {
                sum += (numbers[numbersCount] * numbers[number]);
            }
        }
        if (sum == magicNumber)
        {
            Console.WriteLine(dateString);
            FoundResult = true;
        }
    }

    private static void MagicWeight(int startYear, int endYear, int magicNumber)
    {
        DateTime firstJanuar = new DateTime(startYear, 1, 1);
        DateTime endDecember = new DateTime(endYear, 12, 31);
        for (DateTime date = firstJanuar.Date; date <= endDecember.Date; date = date.AddDays(1))
        {
            CalcDate(date, magicNumber);
        }
    }
}