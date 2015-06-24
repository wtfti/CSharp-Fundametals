using System;

class Wine
{
    public static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        int asterixes = size - 2;
        int dots = 1;
        bool wineHasWritten = false;

        for (int i = 0; i < size-1; i++)
        {
            if (!wineHasWritten)
            {
                Console.Write(new string('\\', 1));
                Console.Write(new string('*', asterixes));
                Console.WriteLine(new string('/', 1));
                asterixes -= 2;
                while (asterixes >= 0)
                {
                    Console.Write(new string('.', dots));
                    Console.Write(new string('\\', 1));
                    Console.Write(new string('*', asterixes));
                    Console.Write(new string('/', 1));
                    Console.WriteLine(new string('.', dots));
                    asterixes -= 2;
                    dots++;
                    i++;
                }
                int stemCount;
                dots--;
                if (size >= 12)
                {
                    stemCount = size/2 - 2;
                }
                else
                {
                    stemCount = size/2 - 1;
                }
                for (int j = 0; j < stemCount; j++)
                {
                    Console.Write(new string('.', dots));
                    Console.Write(new string('|', 2));
                    Console.WriteLine(new string('.', dots));
                    i++;
                }
                wineHasWritten = true;
            }
            Console.WriteLine(new string('-', size));
        }
    }
}
