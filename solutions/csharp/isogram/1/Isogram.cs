public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        HashSet<char> seen = new HashSet<char>();
        foreach (char c in word.ToLower()) {
            if (seen.Contains(c)) return false;
            if (Char.IsLetter(c)) seen.Add(c);
        }

        return true;
    }
}
