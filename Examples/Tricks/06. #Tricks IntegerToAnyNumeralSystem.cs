private static string IntegerToAnyNumeralSystem(int number, int system)
{
    string result = "";
    while (number > 0)
    {
        result = number%system + result;
        number /= system;
    }
    return result;
}