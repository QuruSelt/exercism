public static class RotationalCipher
{
    public static char ShiftLower(char c, char shiftChar) => (char) ((char) ((char) ((char) (c + shiftChar) - 'a') % 26) + 'a');

    public static char ShiftUpper(char c, char shiftChar) => (char) ((char) ((char) ((char) (c + shiftChar) - 'A') % 26) + 'A');
    
    public static string Rotate(string text, int shiftKey)
    {
        string cipher = "";
        char shiftChar = (char) shiftKey;
        foreach (char c in text) {
            if (c >= 'a' && c <= 'z') {
                cipher = $"{cipher}{ShiftLower(c, shiftChar)}";
            }
            else if (c >= 'A' && c <= 'Z') {
                cipher = $"{cipher}{ShiftUpper(c, shiftChar)}";
            }
            else cipher = $"{cipher}{c}";
        }

        return cipher;
    }
}