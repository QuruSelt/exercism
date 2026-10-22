public class Anagram
{
    private string _word;
    private string _sortedWord;
    
    public Anagram(string baseWord)
    {
        _word = baseWord.ToLower();
        _sortedWord = SortString(_word);
    }

    public static string SortString(string input)
    {
        char[] characters = input.ToArray();
        Array.Sort(characters);
        return new string(characters);
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> anagrams = new List<string>();

        foreach (string word in potentialMatches) {
            string lower = word.ToLower();
            if (lower != _word && SortString(lower) == _sortedWord) anagrams.Add(word);
        }
            
        return anagrams.ToArray();
    }
}