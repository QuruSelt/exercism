public static class NthPrime
{
    public static int Prime(int nth)
    {
        if (nth < 1) throw new ArgumentOutOfRangeException();
        if (nth == 1) return 2;
        var primes = new List<int>{2};

        int i = 3;
        while (primes.Count < nth) {
            bool IsPrime = true;
            foreach (var p in primes) {
                if (i % p == 0) {
                    IsPrime = false;
                    break;
                }
            }
            if (IsPrime) primes.Add(i);
            i += 2;
        }
        return primes[^1];
    }
}