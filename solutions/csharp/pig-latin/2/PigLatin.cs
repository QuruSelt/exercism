public static class PigLatin
{
    public static (int, int) Rule(string word) // (Rule, Position)
    {
        int pos = 0;
        foreach (char c in word) {
            switch (c) {
                case 'x':
                    if (pos == 0 && word[pos+1] == 'r') return (1, pos);
                    break;
                case 'y':
                    if (pos == 0 && word[pos+1] == 't') return (1, pos);
                    if (pos != 0) return (4, pos);
                    break;
                case 'q':
                    if (word[pos+1] == 'u') return (3, pos+1);
                    break;
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    return (pos == 0 ? 1 : 2, pos);
            }

            pos = pos + 1;
        }
        return (0, 0);
    }

    public static string ApplyRule(string word, (int, int) ruleinfo)
    {
        var (rule, pos) = ruleinfo;
        switch (rule) {
            case 1:
                return $"{word}ay";
            case 2:
                return $"{word.Substring(pos)}{word.Substring(0, pos)}ay";
            case 3:
                return $"{word.Substring(pos+1)}{word.Substring(0, pos+1)}ay";
            case 4:
                return $"{word.Substring(pos)}{word.Substring(0, pos)}ay";
        }

        return word;
    }
    
    public static string Translate(string word)
    {
        string pigLatin = "";
        foreach (string w in word.Split(' ')) {
            pigLatin = $"{pigLatin} {ApplyRule(w, Rule(w))}";
        }
        return pigLatin.Substring(1);
        // throw new NotImplementedException("You need to implement this method.");
    }
}