using System;
class SeqEqualStrings
{
    static void Main()
    {
        string[] elements = Console.ReadLine().Split();

        for (int count = 0; count < elements.Length; count++)
        {
            Console.Write(elements[count]);
            for (int currentString = count + 1; currentString < elements.Length; currentString++)
            {
                if (elements[count] == elements[currentString])
                {
                    Console.Write(" {0}", elements[currentString]);
                    count++;
                }
            }
            Console.WriteLine();
        }
    }
}