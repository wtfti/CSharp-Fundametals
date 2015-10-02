using System;
using System.Linq;

class Program
{
    public static void Main()
    {
        int sizeOfBoard = int.Parse(Console.ReadLine());
        int[] bitMatrix = new int[sizeOfBoard];
        string[] cordinates = Console.ReadLine().Split().ToArray();
        int crossRoads = 0;
        while (cordinates[0] != "end")
        {
            crossRoads++;
            int row = int.Parse(cordinates[0]);
            int col = int.Parse(cordinates[1]);
            int rowCounter = row;
            int colCounter = col;
            int mask;

            while (rowCounter >= 0 && colCounter < sizeOfBoard)
            {
                mask = (bitMatrix[rowCounter] >> colCounter) & 1;
                if (mask == 1)
                {
                    crossRoads++;
                }
                bitMatrix[rowCounter] |= (1 << colCounter);
                rowCounter--;
                colCounter++;
            }
            rowCounter = row + 1;
            colCounter = col - 1;
            while (rowCounter < sizeOfBoard && colCounter >= 0)
            {
                mask = (bitMatrix[rowCounter] >> colCounter) & 1;
                if (mask == 1)
                {
                    crossRoads++;
                }
                bitMatrix[rowCounter] |= (1 << colCounter);
                rowCounter++;
                colCounter--;
            }
            rowCounter = row + 1;
            colCounter = col + 1;
            while (rowCounter < sizeOfBoard && colCounter < sizeOfBoard)
            {
                mask = (bitMatrix[rowCounter] >> colCounter) & 1;
                if (mask == 1)
                {
                    crossRoads++;
                }
                bitMatrix[rowCounter] |= (1 << colCounter);
                rowCounter++;
                colCounter++;
            }
            rowCounter = row - 1;
            colCounter = col - 1;
            while (rowCounter >= 0 && colCounter >= 0)
            {
                mask = (bitMatrix[rowCounter] >> colCounter) & 1;
                if (mask == 1)
                {
                    crossRoads++;
                }
                bitMatrix[rowCounter] |= (1 << colCounter);
                rowCounter--;
                colCounter--;
            }
            cordinates = Console.ReadLine().Split().ToArray();
        }

        for (int index = 0; index < sizeOfBoard; index++)
        {
            Console.WriteLine(bitMatrix[index]);
        }
        Console.WriteLine(crossRoads);
    }
}