using System;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        HashSet<int> values = new HashSet<int>();
        int sum = 0;
        foreach (int item in multiples) {
            if (item < 1) continue;
            int v = item;
            Console.WriteLine(item);
            while (v < max) {
                if (values.Add(v)) sum += v;
                v += item;
            }
        }

        return sum;
    }
}