public static int LimitValue(int value, int minLimit, int maxLimit)
{
    if (value < minLimit)
        return minLimit;
    else if (value > maxLimit)
        return maxLimit;
    else
        return value;
}