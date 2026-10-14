public static class Bob
{
    public static bool HasLetters(string statement) => statement.Any(Char.IsLetter);
    public static bool IsYelled(string statement) => HasLetters(statement) && statement.ToUpper() == statement;
    public static bool IsQuestion(string statement) => statement[statement.Length-1] == '?';
    
    public static string Response(string statement)
    {
        statement = statement.Trim();
        if (string.IsNullOrEmpty(statement)) return "Fine. Be that way!";
        if (IsQuestion(statement)) {
            if (IsYelled(statement)) return "Calm down, I know what I'm doing!";
            return "Sure.";
        }
        if (IsYelled(statement)) return "Whoa, chill out!";
        return "Whatever.";
    }
}