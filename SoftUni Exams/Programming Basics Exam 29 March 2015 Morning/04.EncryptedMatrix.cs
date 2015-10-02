using System;

class EncryptedMatrix
{
    public static void Main()
    {
        string input = Console.ReadLine();
        char direction = char.Parse(Console.ReadLine());
        string inputAtNumber = "";
        string result = "";
        int prevNum;
        int nextNum;
        foreach (var ch in input)
        {
            inputAtNumber += Convert.ToString(ch%10);
        }

        for (int index = 0; index < inputAtNumber.Length; index++)
        {
            int currentNum = Convert.ToInt32(inputAtNumber[index].ToString());
            if (currentNum % 2 == 0)
            {
                result += currentNum * currentNum;
            }
            else
            {
                if (index > 0 && index < inputAtNumber.Length - 1)
                {
                    prevNum = Convert.ToInt32(inputAtNumber[index-1].ToString());
                    nextNum = Convert.ToInt32(inputAtNumber[index+1].ToString());
                    result += (currentNum + prevNum + nextNum);
                }
                else if(index == 0 && index+1 != inputAtNumber.Length)
                {
                    nextNum = Convert.ToInt32(inputAtNumber[index + 1].ToString());
                    result += (currentNum + nextNum);
                }
                else if(index > 0 && index + 1 == inputAtNumber.Length)
                {
                    prevNum = Convert.ToInt32(inputAtNumber[index - 1].ToString());
                    result += (currentNum + prevNum);
                }
                else
                {
                    result += currentNum;
                }
            }
        }

        char[,] matrix = new char[result.Length,result.Length];
        int countNumbers = 0;
        if (direction == '/')
        {
            countNumbers = result.Length - 1;
        }
        for (int row = 0; row < result.Length; row++)
        {
            for (int col = 0; col < result.Length; col++)
            {
                if (direction == '\\')
                {
                    if (row == col)
                    {
                        matrix[row, col] = result[countNumbers];
                        countNumbers++;
                    }
                    else
                    {
                        matrix[row, col] = '0';
                    }
                }
                else
                {
                    if (result.Length - row -1 == col)
                    {
                        matrix[row, col] = result[countNumbers];
                        countNumbers--;
                    }
                    else
                    {
                        matrix[row, col] = '0';
                    }
                }
                Console.Write(matrix[row,col] + " ");
            }
            Console.WriteLine();
        }
    }
}