public static class Knapsack
{    
    public static int MaximumValue(int maximumWeight, (int weight, int value)[] items)
    {
        if (maximumWeight == 0 || items.Length == 0) return 0;
        int[,] values = new int[items.Length+1, maximumWeight+1];
        for (int w = 0; w < maximumWeight+1; w++) {
            values[0, w] = 0;
        }

        for (int i = 1; i < items.Length+1; i++) {
            for (int w = 0; w < maximumWeight+1; w++) {
                if (items[i-1].weight > w) {
                    values[i, w] = values[i-1, w];
                } else {
                    values[i, w] = Int32.Max(values[i-1, w], values[i-1, w-items[i-1].weight] + items[i-1].value);
                }
            }
        }

        return values[items.Length, maximumWeight];
    }
}
