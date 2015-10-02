using System;
class Program
{
    static void Main()
    {
        Console.Write("Number: ");
        int number = int.Parse(Console.ReadLine());
        int get3rdNumber = (number/100)%10;
        bool numberIs7 = get3rdNumber == 7;
        Console.WriteLine("Third digit is 7? {0}", numberIs7);
    }
}
