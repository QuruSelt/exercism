public static class CollatzConjecture
{
    public static int Steps(int number) => number < 1 ? throw new ArgumentOutOfRangeException() :
        number == 1 ? 0 : 1 + (number % 2 == 0 ? Steps(number / 2) : Steps((3 * number) + 1));
}