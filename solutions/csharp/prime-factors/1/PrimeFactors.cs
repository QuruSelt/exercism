public static class PrimeFactors
{    
    public static long[] Factors(long number)
    {
        List<long> factors = new List<long>();

        while (number % 2 == 0) {
            factors.Add(2);
            number /= 2;
        }
        
        int p = 3;
        while (number > 1) {
            while (p <= number) {
                if (number % p == 0) {
                    factors.Add(p);
                    number /= p;
                    break;
                }
                p += 2;
            }
        }

        return factors.ToArray();
    }
}