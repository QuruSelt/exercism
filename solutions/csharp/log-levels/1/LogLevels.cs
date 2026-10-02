static class LogLine
{
    public static string Message(string logLine)
    {
        return logLine.Substring(logLine.IndexOf(" ") + 1).Trim();
        // throw new NotImplementedException("Please implement the (static) LogLine.Message() method");
    }

    public static string LogLevel(string logLine)
    {
        switch (logLine.Substring(1, logLine.IndexOf("]") - 1))
        {
            case "ERROR":
                return "error";
            case "WARNING":
                return "warning";
            case "INFO":
                return "info";
            default:
                return "N/A";
        }
        // throw new NotImplementedException("Please implement the (static) LogLine.LogLevel() method");
    }

    public static string Reformat(string logLine)
    {
        return Message(logLine) + " (" + LogLevel(logLine) + ")";
        // throw new NotImplementedException("Please implement the (static) LogLine.Reformat() method");
    }
}
