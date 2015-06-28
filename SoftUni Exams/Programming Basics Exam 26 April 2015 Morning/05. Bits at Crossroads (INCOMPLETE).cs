using System;
using System.Linq;

class BitsAtCrossRoads
{
    public static void Main()
    {
        int sizeOfBoard = int.Parse(Console.ReadLine());
        int[,] bitMatrix = new int[sizeOfBoard, sizeOfBoard];
        string[] cordinates = Console.ReadLine().Split().ToArray();
        int crossRoads = 0;
        while (cordinates[0] != "end")
        {
            int row = int.Parse(cordinates[0]);
            int col = int.Parse(cordinates[1]);
            int rowCounter = row - 1;
            int colCounter = col + 1;

            bitMatrix[row, col] |= (1 << col);

            while (rowCounter >= 0 && colCounter < sizeOfBoard)
            {
                crossRoads += CalcCrossRoads(bitMatrix, rowCounter, colCounter);
                bitMatrix[rowCounter, colCounter] |= (1 << colCounter);
                rowCounter--;
                colCounter++;
            }
            //PrintMatrix(bitMatrix,sizeOfBoard);
            rowCounter = row + 1;
            colCounter = col - 1;
            while (rowCounter < sizeOfBoard && colCounter >= 0)
            {
                crossRoads += CalcCrossRoads(bitMatrix, rowCounter, colCounter);
                bitMatrix[rowCounter, colCounter] |= (1 << colCounter);
                rowCounter++;
                colCounter--;
            }
            rowCounter = row + 1;
            colCounter = col + 1;
            //PrintMatrix(bitMatrix, sizeOfBoard);
            while (rowCounter < sizeOfBoard && colCounter < sizeOfBoard)
            {
                crossRoads += CalcCrossRoads(bitMatrix, rowCounter, colCounter);
                bitMatrix[rowCounter, colCounter] |= (1 << colCounter);
                rowCounter++;
                colCounter++;

            }
            rowCounter = row - 1;
            colCounter = col - 1;
            //PrintMatrix(bitMatrix, sizeOfBoard);
            while (rowCounter >= 0 && colCounter >= 0)
            {
                crossRoads += CalcCrossRoads(bitMatrix, rowCounter, colCounter);
                bitMatrix[rowCounter, colCounter] |= (1 << colCounter);
                rowCounter--;
                colCounter--;
            }
            //PrintMatrix(bitMatrix, sizeOfBoard);
            cordinates = Console.ReadLine().Split().ToArray();
        }

        for (int row = 0; row < sizeOfBoard; row++)
        {
            int currentBit = 0;
            for (int cols = 0; cols < sizeOfBoard; cols++)
            {
                currentBit += bitMatrix[row, cols];
            }
            Console.WriteLine(currentBit);
        }
        Console.WriteLine(crossRoads);
    }

    private static int CalcCrossRoads(int[,] matrix, int currentRow, int currentCol)
    {
        int numberOfCrossroads = 0;
        if (((matrix[currentRow,currentCol] >> currentCol) & 1) == 1)
        {
            numberOfCrossroads++;
        }
        return numberOfCrossroads;
    }
}