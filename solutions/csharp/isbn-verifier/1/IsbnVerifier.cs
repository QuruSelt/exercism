public static class IsbnVerifier
{
    private static string NormalizeString(string str) {
        string text = "";

        foreach (char c in str) {
            if (!Char.IsDigit(c) && c != '-' && c != 'X') return "";
            else if (c != '-') text = $"{text}{c}";
        }

        if (text.Length == 0) return "";
        
        foreach (char c in text[..^1]) {
            if (!Char.IsDigit(c)) return "";
        }

        return text;
    }
    
    public static bool IsValid(string number)
    {
        string norm = NormalizeString(number);

        if (norm.Length != 10) return false;

        int mult = 10;
        int check = 0;
        foreach (char c in norm) {
            int v = (int) (c - '0');
            if (c == 'X') v = 10;
            check = (check + (v * mult)) % 11;
            mult--;
        }

        return check == 0;
    }
}