using System;
using System.Linq;

class NumberCalc
{
    static void Main()
    {
        Console.Write("Decimals: ");
        decimal[] decimalNumbers = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
        Console.WriteLine("Min: {0}\r\nMax: {1}\r\nAvg: {2}\r\nSum: {3}\r\nProduct: {4}\r\n\r\n", 
            Min(decimalNumbers), Max(decimalNumbers), Avg(decimalNumbers), Sum(decimalNumbers), Product(decimalNumbers));
        Console.Write("Double: ");
        double[] doubleNumbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
        Console.WriteLine("Min: {0}\r\nMax: {1}\r\nAvg: {2}\r\nSum: {3}\r\nProduct: {4}",
            Min(doubleNumbers), Max(doubleNumbers), Avg(doubleNumbers), Sum(doubleNumbers), Product(doubleNumbers));
    }

    private static decimal Min(decimal[] numbersCollection)
    {
        decimal minNumber = decimal.MaxValue;

        foreach (var num in numbersCollection)
        {
            if (num < minNumber)
            {
                minNumber = num;
            }
        }
        return minNumber;
    }

    private static double Min(double[] numbersCollection)
    {
        double minNumber = double.MaxValue;

        foreach (var num in numbersCollection)
        {
            if (num < minNumber)
            {
                minNumber = num;
            }
        }
        return minNumber;
    }

    private static decimal Max(decimal[] numbersCollection)
    {
        decimal maxNumber = decimal.MinValue;

        foreach (var num in numbersCollection)
        {
            if (num > maxNumber)
            {
                maxNumber = num;
            }
        }
        return maxNumber;
    }

    private static double Max(double[] numbersCollection)
    {
        double maxNumber = double.MinValue;

        foreach (var num in numbersCollection)
        {
            if (num > maxNumber)
            {
                maxNumber = num;
            }
        }
        return maxNumber;
    }
    private static double Avg(decimal[] numbersCollection)
    {
        decimal average = 0;
        Array.ForEach(numbersCollection, a => average += a);
        average /= numbersCollection.Length;
        return (double)(average / numbersCollection.Length);
    }

    private static double Avg(double[] numbersCollection)
    {
        double average = 0;
        Array.ForEach(numbersCollection, a => average += a);
        average /= numbersCollection.Length;
        return average / numbersCollection.Length;
    }
    private static decimal Sum(decimal[] numbersCollection)
    {
        decimal sum = 0;
        Array.ForEach(numbersCollection, a => sum += a);
        return sum;
    }

    private static double Sum(double[] numbersCollection)
    {
        double sum = 0;
        Array.ForEach(numbersCollection, a => sum += a);
        return sum;
    }

    private static decimal Product(decimal[] numbersCollection)
    {
        decimal product = 1;
        Array.ForEach(numbersCollection, a => product *= a);
        return product;
    }

    private static double Product(double[] numbersCollection)
    {
        double product = 1;
        Array.ForEach(numbersCollection, a => product *= a);
        return product;
    }
}