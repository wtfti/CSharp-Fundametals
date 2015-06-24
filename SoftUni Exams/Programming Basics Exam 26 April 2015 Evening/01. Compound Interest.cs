using System;

class CompoundInterest
{
    public static void Main()
    {
        double priceTV = double.Parse(Console.ReadLine());
        int yearsPayBank = int.Parse(Console.ReadLine());
        double bankInterest = double.Parse(Console.ReadLine());
        double friendInterest = double.Parse(Console.ReadLine());

        double bankLoan = priceTV*Math.Pow((1 + bankInterest), yearsPayBank);
        double friendLoan = priceTV * (1 + friendInterest);
        if (friendLoan <= bankLoan)
        {
            Console.WriteLine("{0:f2} Friend", friendLoan);
        }
        else
        {
            Console.WriteLine("{0:f2} Bank", bankLoan);
        }
    }
}