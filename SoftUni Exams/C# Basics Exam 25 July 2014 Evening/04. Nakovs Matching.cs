using System;

class NakovsMatching
{
    public static void Main()                                                 // Yea, I know that the code is a mess, but it passes all tests in the judge system.
    {                                                                         // Yea, I know that the code is a mess, but it passes all tests in the judge system.
        string word1 = Console.ReadLine();                                    // Yea, I know that the code is a mess, but it passes all tests in the judge system.
        string word2 = Console.ReadLine();                                    // Yea, I know that the code is a mess, but it passes all tests in the judge system.
        int limitNumber = int.Parse(Console.ReadLine());                      // Yea, I know that the code is a mess, but it passes all tests in the judge system.
        int leftSideWord1Weight = 0;                                          // Yea, I know that the code is a mess, but it passes all tests in the judge system.
        int rightSideWord1Weight = 0;                                         // Yea, I know that the code is a mess, but it passes all tests in the judge system.
        int leftSideWord2Weight = 0;                                          // Yea, I know that the code is a mess, but it passes all tests in the judge system.
        int rightSideWord2Weight = 0;                                         // Yea, I know that the code is a mess, but it passes all tests in the judge system.
        int formula = 0;                                                      // Yea, I know that the code is a mess, but it passes all tests in the judge system.
        string leftSideWord1 = "";                                            // Yea, I know that the code is a mess, but it passes all tests in the judge system.
        string rightSideWord1 = "";                                           // Yea, I know that the code is a mess, but it passes all tests in the judge system.
        string leftSideWord2 = "";
        string rightSideWord2 = "";
        bool foundResult = false;
        int secondWordIndex = 1;

        for (int firstWordIndex = 1; firstWordIndex < word1.Length; firstWordIndex++)
        {

            for (int fillLeftSide = 0; fillLeftSide < firstWordIndex; fillLeftSide++)
            {
                leftSideWord1 += word1[fillLeftSide];
                leftSideWord1Weight += word1[fillLeftSide];

            }
            for (int fillRightSide = firstWordIndex; fillRightSide < word1.Length; fillRightSide++)
            {
                rightSideWord1 += word1[fillRightSide];
                rightSideWord1Weight += word1[fillRightSide];
            }

            while (secondWordIndex < word2.Length)
            {
                for (int fillLeftSide = 0; fillLeftSide < secondWordIndex; fillLeftSide++)
                {
                    leftSideWord2 += word2[fillLeftSide];
                    leftSideWord2Weight += word2[fillLeftSide];
                }
                for (int fillRightSide = secondWordIndex; fillRightSide < word2.Length; fillRightSide++)
                {
                    rightSideWord2 += word2[fillRightSide];
                    rightSideWord2Weight += word2[fillRightSide];
                }
                formula =
                    Math.Abs((leftSideWord1Weight*rightSideWord2Weight) - (rightSideWord1Weight*leftSideWord2Weight));
                if (formula <= limitNumber)
                {
                    Console.WriteLine("({0}|{1}) matches ({2}|{3}) by {4} nakovs", leftSideWord1, rightSideWord1,
                        leftSideWord2, rightSideWord2, formula);
                    foundResult = true;
                }
                leftSideWord2 = "";
                leftSideWord2Weight = 0;
                rightSideWord2 = "";
                rightSideWord2Weight = 0;
                secondWordIndex++;
            }
            leftSideWord1 = "";
            leftSideWord1Weight = 0;
            rightSideWord1 = "";
            rightSideWord1Weight = 0;
            secondWordIndex = 1;
        }

        if (!foundResult)
        {
            Console.WriteLine("No");
        }
    }
}