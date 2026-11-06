public static class FoodChain
{
    private static Dictionary<int, string> animals = new Dictionary<int, string> {
        [1] = "fly",
        [2] = "spider",
        [3] = "bird",
        [4] = "cat",
        [5] = "dog",
        [6] = "goat",
        [7] = "cow",
    };
    private static Dictionary<int, string> swallows = new Dictionary<int, string> {
        [1] = "",
        [2] = "\nIt wriggled and jiggled and tickled inside her.",
        [3] = "\nHow absurd to swallow a bird!",
        [4] = "\nImagine that, to swallow a cat!",
        [5] = "\nWhat a hog, to swallow a dog!",
        [6] = "\nJust opened her throat and swallowed a goat!",
        [7] = "\nI don't know how she swallowed a cow!",
    };
    public static string Recite(int verseNumber)
    {
        if (verseNumber == 8) return "I know an old lady who swallowed a horse.\nShe's dead, of course!";

        string verse = $"I know an old lady who swallowed a {animals[verseNumber]}.{swallows[verseNumber]}";
        while (verseNumber > 1) {
            verse = $"{verse}\nShe swallowed the {animals[verseNumber]} to catch the {animals[verseNumber-1]}{(verseNumber == 3 ? " that wriggled and jiggled and tickled inside her" : "")}.";
            verseNumber--;
        }
        verse = $"{verse}\nI don't know why she swallowed the fly. Perhaps she'll die.";
        return verse;
    }

    public static string Recite(int startVerse, int endVerse)
    {
        string poem = "";
        while (startVerse <= endVerse) poem = $"{poem}{Recite(startVerse++)}\n\n";
        return poem.Substring(0, poem.Length-2);
    }
}