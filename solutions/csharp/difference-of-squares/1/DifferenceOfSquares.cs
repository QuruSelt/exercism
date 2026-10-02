using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int max) => ((max*(max+1))/2) * ((max*(max+1))/2);

    public static int CalculateSumOfSquares(int max) => Enumerable.Range(1, max).ToArray().Aggregate(0, (sum, n) => sum + (n * n));

    public static int CalculateDifferenceOfSquares(int max) => CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
}