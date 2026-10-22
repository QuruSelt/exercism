public static class AllYourBase
{
    private static int ToBaseTen(int[] digits, int b) {
        int n = 0;
        foreach (int d in digits) {
            if (d < 0 || d >= b) throw new ArgumentException();
            n = (n*b) + d;
        }
        return n;
    }
    
    private static int[] FromBaseTen(int n, int b) {
        List<int> digits = new List<int>();
        while (n > 0) {
            digits.Add(n % b);
            n /= b;
        }
        if (digits.Count() == 0) digits.Add(0);
        digits.Reverse();
        return digits.ToArray();
    }
    
    public static int[] Rebase(int inputBase, int[] inputDigits, int outputBase) {
        if (inputBase <2 || outputBase < 2) throw new ArgumentException();
        return FromBaseTen(ToBaseTen(inputDigits, inputBase), outputBase);
    }
}