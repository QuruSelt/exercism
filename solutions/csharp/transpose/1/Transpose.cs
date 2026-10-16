public static class Transpose
{
    private static int GetMaxLength(string[] list) {
        int maxLength = 0;
        foreach (string s in list) maxLength = maxLength < s.Length ? s.Length : maxLength;
        return maxLength;
    }
    
    public static string String(string input)
    {
        string transpose = "";
        if (input.Length < 1) return transpose;
        string[] lines = input.Split('\n');

        for (int i = 0; i < GetMaxLength(lines); i++) {
            string row = "";
            int r = 0;
            while (r < lines.Length) {
                if (i >= lines[r].Length) row = $"{row} ";
                else row = $"{row}{lines[r][i]}";
                r++;
            }
            r--;
            while (i >= lines[r].Length && row[^1] == ' ') {
                row = row[..^1];
                r--;
            }
            transpose = $"{transpose}{row}\n";
        }
        
        return transpose[..^1];
    }
}