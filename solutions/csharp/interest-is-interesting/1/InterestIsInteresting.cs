static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        switch (balance) {
            case (< 0.0m):
                return 3.213f;
            case (< 1000.0m):
                return 0.5f;
            case (< 5000.0m):
                return 1.621f;
            default:
                return 2.475f;
        }
    }

    public static decimal Interest(decimal balance) => balance * (decimal)(InterestRate(balance) / 100.0f);

    public static decimal AnnualBalanceUpdate(decimal balance) => balance + Interest(balance);

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int year = 0;
        while (balance < targetBalance) {
            balance = AnnualBalanceUpdate(balance);
            year += 1;
        }

        return year;
    }
}
