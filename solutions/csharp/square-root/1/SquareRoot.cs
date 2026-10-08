public static class SquareRoot
{
    public static int Root(int number)
    {
        int i = 1;
        int v = 1;

        while (v < number) {
            v += 2*i + 1;
            i += 1;
        }

        if (v == number) return i;

        return 0;
    }
}
