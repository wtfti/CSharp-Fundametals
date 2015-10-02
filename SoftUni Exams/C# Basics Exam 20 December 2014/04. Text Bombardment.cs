using System;
using System.Linq;

class TextBombardment
{
    public static void Main()
    {
        string text = Console.ReadLine();
        int cols = int.Parse(Console.ReadLine());
        int rows = text.Length / cols;
        rows += text.Length % cols == 0 ? 0 : 1;
        char[,] matrix = new char[rows, cols];
        string bombs = Console.ReadLine();
        int[] bombCols = bombs.Split(' ').Select(int.Parse).ToArray();
        int letterCount = 0;

        for (int row = 0; row < rows; row++) // Fill Matrix :)
        {
            for (int col = 0; letterCount < text.Length && col < cols; col++)
            {
                matrix[row, col] = text[letterCount];
                letterCount++;
                if (letterCount >= text.Length)
                {
                    break;
                }
            }
            if (letterCount >= text.Length)
            {
                break;
            }
        }
        foreach (var number in bombCols)
        {
            int currentColBomb = Convert.ToInt32(number);
            int currentRow = 0;
            while (true) //Bombing
            {
                while (currentRow < rows && matrix[currentRow, currentColBomb] == ' ')
                {
                    currentRow++;
                }
                while (currentRow < rows && matrix[currentRow, currentColBomb] != ' ')
                {
                    matrix[currentRow, currentColBomb] = ' ';
                    currentRow++;
                }
                break;
            }
        }
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                char letter = matrix[row, col];
                if (letter != '\0')
                {
                    Console.Write(matrix[row, col]);
                }
            }
        }
    }
}