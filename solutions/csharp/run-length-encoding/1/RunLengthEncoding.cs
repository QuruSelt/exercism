public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        string cipher = "";
        if (input.Length == 0) return cipher;
        char lastLetter = input[0];
        int count = 0;

        foreach (char c in input) {
            if (c == lastLetter) {
                count++;
            } else {
                cipher = $"{cipher}{(count == 1 ? "" : count.ToString())}{lastLetter}";
                lastLetter = c;
                count = 1;
            }
        }

        cipher = $"{cipher}{(count == 1 ? "" : count.ToString())}{lastLetter}";
        return cipher;
    }

    public static string Decode(string input)
    {
        string uncipher = "";
        if (input.Length == 0) return uncipher;
        int count = 0;

        foreach (char c in input) {
            if (c >= '0' && c <= '9') {
                count = count * 10 + (int) (c - '0');
            } else {
                if (count == 0) count++;
                for (int i = 0; i < count; i++) {
                    uncipher = $"{uncipher}{c}";
                }
                count = 0;
            }
        }
        
        return uncipher;
    }
}
