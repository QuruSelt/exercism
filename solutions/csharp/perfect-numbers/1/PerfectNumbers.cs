public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number < 1) throw new ArgumentOutOfRangeException();
        if (number == 1) return Classification.Deficient;
        int aliquot = 1;

        int i = 2;
        while (i*i < number) {
            if (number % i == 0) aliquot += i + (number / i);
            i++;
        }

        if (i*i == number) aliquot += i;

        if (aliquot == number) return Classification.Perfect;
        if (aliquot > number) return Classification.Abundant;
        return Classification.Deficient;
    }
}
