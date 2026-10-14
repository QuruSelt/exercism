public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        int b = 0;
        int e = input.Length - 1;
        if (b > e) return -1;
        int m = (e + b) / 2;
        while (b < e && input[m] != value) {
            Console.WriteLine($"From {b} to {e}, we check {m}: {input[m]}");
            if (input[m] < value) b = m + 1;
            else e = m;
            m = (e + b) / 2;
        }

        if (input[m] == value) return m;
        return -1;
    }
}