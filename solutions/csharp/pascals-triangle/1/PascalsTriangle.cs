public static class PascalsTriangle
{
    private static int GetSum(List<int> above, int index) => (index == 0 || index == above.Count) ? 1 : above[index-1] + above[index];
    
    public static IEnumerable<IEnumerable<int>> Calculate(int rows)
    {
        List<List<int>> triangle = new List<List<int>>();
        if (rows < 1) return triangle;

        triangle.Add(new List<int>() {1});
        
        for (int r = 1; r < rows; r++) {
            List<int> row = new List<int>();
            for (int i = 0; i <= r; i++) {
                row.Add(GetSum(triangle[^1], i));
            }
            triangle.Add(row);
        }
        
        return triangle;
    }

}