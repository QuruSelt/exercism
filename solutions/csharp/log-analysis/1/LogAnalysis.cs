public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string str, string delimiter)
    {
        int pos = str.IndexOf(delimiter);
        if (pos == -1) return "";
        return str.Substring(pos + delimiter.Length);
    }

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string str, string d1, string d2)
    {
        int start = str.IndexOf(d1);
        int end = str.IndexOf(d2);
        if (start == -1 || end == -1) return "";

        return str.Substring(start + d1.Length, end - (start + d1.Length));
    }
    
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str)
    {
        return str.SubstringAfter(": ");
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str)
    {
        return str.SubstringBetween("[", "]");
    }
}