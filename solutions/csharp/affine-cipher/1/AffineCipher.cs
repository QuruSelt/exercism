public static class AffineCipher
{
    private static int m = 26;
    private static void CheckCoprime(int a) {
        if (a == 13 || a % 2 == 0) throw new ArgumentException();
    }
    private static int MMI(int a) {
        int x = 1;
        int v = a;
        while (v % m != 1) {
            v += a;
            x++;
        }
        return x;
    }
    
    public static string Encode(string plainText, int a, int b)
    {
        CheckCoprime(a);
        string cipheredText = "";
        int spacingCounter = 0;
        
        foreach (char c in plainText) {
            if (Char.IsAsciiLetterOrDigit(c)) {
                if (Char.IsDigit(c)) cipheredText += c;
                else {
                    int x = (int) (Char.ToLower(c) - 'a');
                    int y = (a * x + b) % m;
                    cipheredText += (char) (y + 'a');
                }
                if (++spacingCounter % 5 == 0) cipheredText += ' ';
            }
        }
        
        return cipheredText.TrimEnd();
    }

    public static string Decode(string cipheredText, int a, int b)
    {
        CheckCoprime(a);
        string plainText = "";

        foreach (char c in cipheredText) {
            if (Char.IsAsciiLetterOrDigit(c)) {
                if (Char.IsDigit(c)) plainText += c;
                else {
                    int y = (int) (Char.ToLower(c) - 'a');
                    int x = (MMI(a))*(y - b) % m;
                    while (x < 0) x += m;
                    plainText += (char) (x + 'a');
                }
            }
        }
        
        return plainText;
    }
}
