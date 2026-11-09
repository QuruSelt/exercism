public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        var newMapping = new Dictionary<string, int>();

        foreach (var (key, value) in old) {
            foreach (var letter in value) {
                newMapping.Add(letter.ToLower(), key);
            }
        }

        return newMapping;
    }
}