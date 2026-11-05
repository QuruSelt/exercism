public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var count = new Dictionary<char, int>{ ['A'] = 0, ['C'] = 0, ['G'] = 0, ['T'] = 0 };

        try {
            foreach (char c in sequence) {
                count[c]++;
            }
        } catch (KeyNotFoundException e) {
            throw new ArgumentException();
        }

        return count;
    }
}