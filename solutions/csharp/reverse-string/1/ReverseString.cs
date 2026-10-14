public static class ReverseString
{
    public static string Reverse(string input) {
        string res = "";
        
        foreach (char c in input) {
            res = c + res;
        }

        return res;
    }
}