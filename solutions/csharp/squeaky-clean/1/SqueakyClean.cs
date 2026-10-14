public static class Identifier
{
    public static bool IsLowerGreek(char c) => c >= 'α' && c <= 'ω';
    public static string Clean(string identifier)
    {
        string res = "";

        for (int i = 0; i < identifier.Length; i++) {
            char c = identifier[i];
            switch (c) {
                case ' ':
                    res = $"{res}_";
                    break;
                case '\0':
                    res = $"{res}CTRL";
                    break;
                case '-':
                    i++;
                    res = $"{res}{Char.ToUpper(identifier[i])}";
                    break;
                default:
                    if (Char.IsLetter(c) && !IsLowerGreek(c)) res = $"{res}{c}";
                    break;
            }
        }

        return res;
    }
}
