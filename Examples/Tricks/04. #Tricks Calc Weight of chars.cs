    private static int CalcWeight(string str)
    {
        int weight = 0;
        foreach (var ch in str)
        {
            switch (ch)
            {
                case 's': weight += 3; break;
                case 'n': weight += 4; break;
                case 'k': weight += 1; break;
                case 'p': weight += 5; break;
            }
        }
        return weight;
    }
