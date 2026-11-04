using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB) => $"                  {studentA} ♡ {studentB}                    ";

    public static string DisplayBanner(string studentA, string studentB) => string.Format(@"     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {0} +  {1}    **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *", studentA, studentB);

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours) {
        string str = $"{studentA} and {studentB} have been dating since";
        Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
        str = $"{str} {start.ToShortDateString()}";
        str = $"{str} - that's {hours:n2} hours";
        return str;
    }
}
