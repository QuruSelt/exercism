public static class AtbashCipher
{
    private static char Key(char c) => (char) (c > 'm' ? c - 2 * (c - 'm') + 1 : c + 2 * ('m' - c) + 1);
    
    public static string Encode(string plainValue)
    {
        string encoded = "";
        int l = 1;

        foreach (char c in plainValue) {
            if (Char.IsLetter(c)) {
                encoded = $"{encoded}{Key(Char.ToLower(c))}";
                if (l++ % 5 == 0) encoded = $"{encoded} ";
            }
            else if (Char.IsDigit(c)) {
                encoded = $"{encoded}{c}";
                if (l++ % 5 == 0) encoded = $"{encoded} ";
            }
        }

        return encoded.Length % 6 == 0 ? encoded[..^1] : encoded;
    }

    public static string Decode(string encodedValue)
    {
        string decoded = "";

        foreach(char c in encodedValue) {
            if (Char.IsLetter(c)) decoded = $"{decoded}{Key(c)}";
            else if (c != ' ') decoded = $"{decoded}{c}";
        }

        return decoded;
    }
}
