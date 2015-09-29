using System;

class LongestAreaInArray
{
    static void Main()
    {
        int size = int.Parse(Console.ReadLine());
        string[] words = new string[size];
        int repeatedTimes = 0;
        string longestElement = "";

        string currentString = "";
        int repeat = 0;
        int countLongestArea = 0;
        for (int index = 0; index < size; index++)
        {
            words[index] = Console.ReadLine();
        }
        int countNumbers = 0;
        for (int index = 0; index < size; index++)
        {
            int count = 0;
            for (int indexY = 0; indexY < size; indexY++)
            {
                if (words[index] == words[indexY])
                    count = count + 1;
            }
            if (repeatedTimes == 0 && longestElement == "") // first time
            {
                repeatedTimes = count;
                longestElement = words[index];
            }
            else if (words[index].Length <= longestElement.Length && count > repeatedTimes)
            {
                repeatedTimes = count;
                longestElement = words[index];
            }
            if (count > 1 )
            {
                index += count-1;
            }
        }
        Console.WriteLine(repeatedTimes);
        while (repeatedTimes > 0)
        {
            Console.WriteLine(longestElement);
            repeatedTimes--;
        }
    }
}