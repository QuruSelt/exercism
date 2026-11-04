public static class Sieve
{
    public static int[] Primes(int limit)
    {
        var primes = new List<int>();

        for (int i = 2; i <= limit; i++) {
            if (primes.Any(p => i % p == 0)) continue;
            primes.Add(i);
        }
        
        return primes.ToArray();
    }
}