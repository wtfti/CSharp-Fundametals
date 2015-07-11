using System;

class Dumbell
{
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());

        int dotsBefore = size/2;
        int symbols = ((size*3) - (dotsBefore*2 + size))/2;

        Console.Write(new string('.', dotsBefore));
        Console.Write(new string('&', symbols));
        Console.Write(new string('.', size));
        Console.Write(new string('&', symbols));
        Console.WriteLine(new string('.', dotsBefore));
        symbols--;
        dotsBefore--;
        while (dotsBefore >= 0)
        {
            Console.Write(new string('.', dotsBefore));
            Console.Write(new string('&', 1));
            Console.Write(new string('*', symbols));
            Console.Write(new string('&', 1));
            if (dotsBefore > 0)
            {
                Console.Write(new string('.', size));
            }
            else
            {
                Console.Write(new string('=', size));
            }
            Console.Write(new string('&', 1));
            Console.Write(new string('*', symbols));
            Console.Write(new string('&', 1));
            Console.WriteLine(new string('.', dotsBefore));
            symbols++;
            dotsBefore--;
        }
        dotsBefore++;
        symbols--;
        while (dotsBefore < size/2)
        {
            dotsBefore++;
            symbols--;
            Console.Write(new string('.', dotsBefore));
            if (dotsBefore <= size/2-1)
            {
                Console.Write(new string('&', 1));
                Console.Write(new string('*', symbols));
                Console.Write(new string('&', 1));
                Console.Write(new string('.', size));
                Console.Write(new string('&', 1));
                Console.Write(new string('*', symbols));
                Console.Write(new string('&', 1));
            }
            else
            {
                Console.Write(new string('&', ((size*3) - (dotsBefore*2 + size))/2));
                Console.Write(new string('.', size));
                Console.Write(new string('&', ((size*3) - (dotsBefore*2 + size))/2));
            }
            Console.WriteLine(new string('.', dotsBefore));
            
        }

    }
}