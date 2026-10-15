public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        string acronym = "";
        bool newWord = true;

        foreach (char c in phrase) {
            if (newWord && Char.IsLetter(c)) {
                acronym = $"{acronym}{Char.ToUpper(c)}";
                newWord = false;
            } else if (c == ' ' || c == '-') {
                newWord = true;
            }
        }

        return acronym;
    }
}