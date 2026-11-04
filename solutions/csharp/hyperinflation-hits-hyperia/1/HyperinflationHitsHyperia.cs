public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try {
            return checked(@base * multiplier).ToString();
        } catch (OverflowException e) {
            return $"*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
            return float.IsFinite(@base * multiplier) ? (@base * multiplier).ToString() : $"*** Too Big ***";
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try {
            return checked(salaryBase * multiplier).ToString();
        } catch (OverflowException e) {
            return $"*** Much Too Big ***";
        }
    }
}
