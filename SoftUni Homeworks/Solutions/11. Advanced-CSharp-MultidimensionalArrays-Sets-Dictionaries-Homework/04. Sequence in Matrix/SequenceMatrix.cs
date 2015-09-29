using System;
using System.Collections.Generic;
using System.Linq;

class SequenceMatrix
{
    static void Main()
    {
        string[,] stringMatrix = //new string[int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine())];
        {
            {"s", "qq", "s", },
            {"pp", "pp", "s",},
            {"pp", "qq", "s",}
        };
        //for (int row = 0; row < stringMatrix.GetLength(0); row++)
        //{
        //    for (int col = 0; col < stringMatrix.GetLength(1); col++)
        //    {
        //        stringMatrix[row, col] = Console.ReadLine();
        //    }
        //}
        List<string> bestResult = new List<string>();
        for (int row = 0; row < stringMatrix.GetLength(0); row++)
        {
            for (int col = 0; col < stringMatrix.GetLength(1); col++)
            {
                if (DiagonalSequence(stringMatrix, row, col).Count > bestResult.Count)
                {
                    bestResult.Clear();
                    DiagonalSequence(stringMatrix, row, col).ForEach(a => bestResult.Add(a));
                }
                if (ColumnSequence(stringMatrix, row, col).Count > bestResult.Count)
                {
                    bestResult.Clear();
                    ColumnSequence(stringMatrix, row, col).ForEach(a => bestResult.Add(a));
                }
                if (RowSequence(stringMatrix, row, col).Count > bestResult.Count)
                {
                    bestResult.Clear();
                    RowSequence(stringMatrix, row, col).ForEach(a => bestResult.Add(a));
                }
            }
        }
        Console.WriteLine(string.Join(", ", bestResult));
    }

    private static List<string> DiagonalSequence(string[,] matrix, int row, int col)
    {
        HashSet<string> elements = new HashSet<string>();
        int count = 0;
        List<string> result = new List<string>();
        for (; row < matrix.GetLength(0); row++, col++)
        {
            if (col >= matrix.GetLength(1))
            {
                break;
            }
            elements.Add(matrix[row, col]);
            count++;
        }
        string hashSetString = elements.First();
        for (int i = 0; i < count; i++)
        {
            result.Add(hashSetString);
        }
        return result;
    }

    private static List<string> ColumnSequence(string[,] matrix, int row, int col)
    {
        HashSet<string> elements = new HashSet<string>();
        int count = 0;
        List<string> result = new List<string>();
        for (; row < matrix.GetLength(0); row++)
        {
            elements.Add(matrix[row, col]);
            count++;
        }
        string hashSetString = elements.First();
        for (int i = 0; i < count; i++)
        {
            result.Add(hashSetString);
        }
        return result;
    }

    private static List<string> RowSequence(string[,] matrix, int row, int col)
    {
        HashSet<string> elements = new HashSet<string>();
        int count = 0;
        List<string> result = new List<string>();
        for (; col < matrix.GetLength(0); col++)
        {
            elements.Add(matrix[row, col]);
            count++;
        }
        string hashSetString = elements.First();
        for (int i = 0; i < count; i++)
        {
            result.Add(hashSetString);
        }
        return result;
    }
}