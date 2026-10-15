public static class Pangram
{
    public static bool IsPangram(string input)
    {
        string lower = input.ToLower();
        char letter = 'a';
        while (letter <= 'z') {
            if (!lower.Contains(letter)) return false;
            letter++;
        }

        return true;
    }
}
