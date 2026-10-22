public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        string[] proverb = new string[subjects.Length];
        if (subjects.Length == 0) return proverb;

        for (int i = 0; i < subjects.Length - 1; i++) {
            proverb[i] = $"For want of a {subjects[i]} the {subjects[i+1]} was lost.";
        }

        proverb[subjects.Length - 1] = $"And all for the want of a {subjects[0]}.";
        return proverb;
    }
}