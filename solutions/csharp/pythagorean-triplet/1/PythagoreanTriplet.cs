using System.Linq;

public static class PythagoreanTriplet
{
    public static IEnumerable<(int a, int b, int c)> TripletsWithSum(int sum)
    {
        List<(int a, int b, int c)> triplets = new List<(int a, int b, int c)>();
        int c = sum/3;
        c += sum - 3*c;
        int sq_c = c*c;
        while (c < sum) {
            int a = (sum - c)/2;
            int b = sum - c - a;
            int sq_a = a*a;
            int sq_b = b*b;
            while (a > 0 && b < c) {
                if ((sq_a + sq_b) == sq_c) {
                    triplets.Add((a:a,b:b,c:c));
                }
                sq_a -= 2*a-- - 1;
                sq_b += 2*b++ + 1;
            }
            sq_c += 2*c++ + 1;
        }

        return triplets.OrderBy(t => t.a);
    }
}