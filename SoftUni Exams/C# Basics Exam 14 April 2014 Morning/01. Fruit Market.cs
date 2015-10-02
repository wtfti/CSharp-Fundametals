using System;

class Fruits
{
    public static void Main()
    {
        string day = Console.ReadLine();
        double[] quantities = new double[3];
        string[] products = new string[3];
        //Price List
        decimal banana = 1.80m;
        decimal cucumber  = 2.75m;
        decimal tomato  = 3.20m;
        decimal orange  = 1.60m;
        decimal apple   = 0.86m;

        for (int i = 0; i < 3; i++)
        {
            quantities[i] = double.Parse(Console.ReadLine());
            products[i] = (Console.ReadLine());
        }

        switch (day)
        {
            case "Friday": //10%
                banana -= (banana*10)/100;
                cucumber -= (cucumber * 10) / 100;
                tomato -= (tomato * 10) / 100;
                orange -= (orange * 10) / 100;
                apple -= (apple * 10) / 100;
                break;
            case "Sunday": //5%
                banana -= (banana * 5) / 100;
                cucumber -= (cucumber * 5) / 100;
                tomato -= (tomato * 5) / 100;
                orange -= (orange * 5) / 100;
                apple -= (apple * 5) / 100;
                break;
            case "Tuesday": //20% fruits
                banana -= (banana * 20) / 100;
                orange -= (orange * 20) / 100;
                apple -= (apple * 20) / 100;
                break;
            case "Wednesday": //10% veg
                tomato -= (tomato * 10) / 100;
                cucumber -= (cucumber * 10) / 100;
                break;
            case "Thursday": //30% banan
                banana -= (banana * 30) / 100;
                break;
        }
        decimal sum = 0;
        int countQuantity = 0;
        foreach (var product in products)
        {
            switch (product)
            {
                case "banana":
                    sum += banana * (decimal)(quantities[countQuantity]);
                    break;
                case "cucumber":
                    sum += cucumber * (decimal)(quantities[countQuantity]);
                    break;
                case "tomato":
                    sum += tomato * (decimal)(quantities[countQuantity]);
                    break;
                case "orange":
                    sum += orange * (decimal)(quantities[countQuantity]);
                    break;
                case "apple":
                    sum += apple * (decimal)(quantities[countQuantity]);
                    break;
            }
            countQuantity++;
        }
        Console.WriteLine("{0:0.00}",sum);
    }
}
