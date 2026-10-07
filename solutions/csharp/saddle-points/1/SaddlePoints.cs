public static class SaddlePoints
{
    public static IEnumerable<(int, int)> Calculate(int[,] matrix)
    {
        List<(int, int)> validTrees = new List<(int, int)>();

        for (int row = 0; row < matrix.GetLength(0); row++) {
            List<int> indices = new List<int>();
            int highest = 0;
            for (int i = 0; i < matrix.GetLength(1); i++) {
                if (highest == matrix[row,i]) {
                    indices.Add(i);
                }
                if (highest < matrix[row,i]) {
                    highest = matrix[row,i];
                    indices = new List<int> {i};
                }
            }

            foreach (int candidate in indices) {
                bool valid = true;
                for (int col = 0; col < matrix.GetLength(0); col++) {
                    if (matrix[col, candidate] < highest) {
                        valid = false;
                        break;
                    }
                }
                if (valid) validTrees.Add((row+1, candidate+1));
            }
        }

        return validTrees;
    }
}
