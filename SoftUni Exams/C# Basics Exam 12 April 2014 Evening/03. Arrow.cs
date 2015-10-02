using System;

class Arrow
{
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int dotsBefore = size/2;
        int middleDots = size-2;

        for (int i = 0; i < size-1; i++)
        {
            if (i == 0)
            {
                Console.Write(new string('.', dotsBefore));
                Console.Write(new string('#', size));
                Console.WriteLine(new string('.', dotsBefore));
            }
            else
            {
                Console.Write(new string('.', dotsBefore));
                Console.Write(new string('#', 1));
                Console.Write(new string('.', middleDots));
                Console.Write(new string('#', 1));
                Console.WriteLine(new string('.', dotsBefore));
            }
        }
        dotsBefore++;
        Console.Write(new string('#', dotsBefore));
        Console.Write(new string('.', middleDots));
        Console.WriteLine(new string('#', dotsBefore));
        dotsBefore = 1;
        middleDots = middleDots + ((size/2))*2-2;
        for (int i = 0; i < size-1; i++)
        {
            Console.Write(new string('.', dotsBefore));
            Console.Write(new string('#', 1));
            if (middleDots >= 0)
            {
                Console.Write(new string('.', middleDots));
                Console.Write(new string('#', 1));
            }
            Console.WriteLine(new string('.', dotsBefore));
            dotsBefore++;
            middleDots -= 2;
        }
    }
}
