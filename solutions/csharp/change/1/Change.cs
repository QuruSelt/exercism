public static class Change
{
    public static int[]? DynamicChange(int[] coins, int target) {
        int[] changeSize = new int[target+1];
        int[] coinPath = new int[target+1];
        Array.Fill(changeSize, Int32.MaxValue);
        changeSize[0] = 0;

        for (int i = 1; i <= target; i++) {
            foreach (int c in coins) {
                if (i >= c && changeSize[i-c] != Int32.MaxValue) {
                    int tmp = changeSize[i-c]+1;
                    if (tmp < changeSize[i]) {
                        changeSize[i] = tmp;
                        coinPath[i] = c;
                    }
                }
            }
        }

        return changeSize[target] == Int32.MaxValue ? null : coinPath;
    }
    
    public static int[] FindFewestCoins(int[] coins, int target)
    {
        if (target != 0 && target < coins[0]) throw new ArgumentException();

        int[]? UsedCoins = DynamicChange(coins, target);
        if (UsedCoins == null) throw new ArgumentException();

        var change = new List<int>();
        while (target > 0) {
            change.Add(UsedCoins[target]);
            target -= UsedCoins[target];
        }
        
        change.Sort();
        return change.ToArray();
    }
}