public static class CryptoSquare
{
    private static string NormalizeString(string str) {
        string text = "";
        foreach (char c in str) if (Char.IsLetterOrDigit(c)) text = $"{text}{Char.ToLower(c)}";
        return text;
    }
    
    public static string Ciphertext(string plaintext)
    {
        string norm = NormalizeString(plaintext);
        
        int c = 1;
        int r = 0;
        while (c * r < norm.Length) {
            if (c == r) c++;
            else r++;
        }

        string encoded = "";
        for (int i = 0; i < c; i++) {
            for (int k = 0; k < r; k++) {
                try {
                    encoded = $"{encoded}{norm[(k*c)+i]}";
                } catch (IndexOutOfRangeException e) {
                    encoded = $"{encoded} ";
                }
            }
            encoded = $"{encoded} ";
        }

        return encoded[..^1];
    }
}
