using System;
class IntDoubleString
{
    static void Main()
    {
        Console.WriteLine("Please choose a type:");
        Console.WriteLine("1 --> int");
        Console.WriteLine("2 --> double");
        Console.WriteLine("3 --> string");
        int userChoice = int.Parse(Console.ReadLine());
        switch (userChoice)
        {
            case 1:
                Console.WriteLine("Please enter a int:");
                int numberInt = int.Parse(Console.ReadLine());
                Console.WriteLine(++numberInt);
                break;
            case 2:
                Console.WriteLine("Please enter a double:");
                double numberDouble = double.Parse(Console.ReadLine());
                Console.WriteLine(++numberDouble);
                break;
            case 3:
                Console.WriteLine("Please enter a string:");
                string text = Console.ReadLine();
                text += "*";
                Console.WriteLine(text);
                break;
        }
    }
}