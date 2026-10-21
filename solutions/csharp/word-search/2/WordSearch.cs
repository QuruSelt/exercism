public class WordSearch
{
    private static List<string> _rows;
    private static List<string> _cols;
    private static int _h;
    private static int _w;
    
    public WordSearch(string grid)
    {
        _rows = grid.Split('\n').ToList();
        _h = _rows.Count();
        _w = _rows[0].Length;

        _cols = new List<string>();

        for (int i = 0; i < _w; i++) {
            string col = "";
            for (int k = 0; k < _h; k++) {
                col = $"{col}{_rows[k][i]}";
            }
            _cols.Add(col);
        }
    }

    private static string ReverseStr(string str) {
        string reversed = "";
        foreach (char c in str) {
            reversed = $"{c}{reversed}";
        }
        return reversed;
    }

    private static ((int, int), (int, int))? FindInRow(string word) {
        string reverseWord = ReverseStr(word);
        int i = 1;
        foreach (string row in _rows) {
            int l2r = row.IndexOf(word);
            int r2l = row.IndexOf(reverseWord);
            if (l2r >= 0) return ((l2r + 1, i), (l2r + word.Length, i));
            if (r2l >= 0) return ((r2l + word.Length, i), (r2l + 1, i));
            i++;
        }
        return null;
    }

    private static ((int, int), (int, int))? FindInCol(string word) {
        string reverseWord = ReverseStr(word);
        int i = 1;
        foreach (string col in _cols) {
            int t2b = col.IndexOf(word);
            int b2t = col.IndexOf(reverseWord);
            if (t2b >= 0) return ((i, t2b + 1), (i, t2b + word.Length));
            if (b2t >= 0) return ((i, b2t + word.Length), (i, b2t + 1));
            i++;
        }
        return null;
    }

    private static ((int, int), (int, int))? FindInDiagTopLeftToBotRight(string word) {
        string reverseWord = ReverseStr(word);
        for (int j = 0; j <= _h - word.Length; j++) {
            for (int k = 0; k <= _w - word.Length; k++) {
                string diag = "";
                for (int n = 0; n < word.Length; n++) {
                    diag = $"{diag}{_rows[j+n][k+n]}";
                }
                int tl2br = diag.IndexOf(word);
                int br2tl = diag.IndexOf(reverseWord);
                if (tl2br >= 0) return ((k + 1, j + 1), (k + word.Length, j + word.Length));
                if (br2tl >= 0) return ((k + word.Length, j + word.Length), (k + 1, j + 1));
            }
        }
        return null;
    }

    private static ((int, int), (int, int))? FindInDiagBotLeftToTopRight(string word) {
        string reverseWord = ReverseStr(word);
        for (int j = _h - 1; j >= word.Length; j--) {
            for (int k = 0; k <= _w - word.Length; k++) {
                string diag = "";
                for (int n = 0; n < word.Length; n++) {
                    diag = $"{diag}{_rows[j-n][k+n]}";
                }
                Console.WriteLine(diag);
                int bl2tr = diag.IndexOf(word);
                int tr2bl = diag.IndexOf(reverseWord);
                if (bl2tr >= 0) return ((k + 1, j + 1), (k + word.Length, j - word.Length + 2));
                if (tr2bl >= 0) return ((k + word.Length, j - word.Length + 2), (k + 1, j + 1));
            }
        }
        return null;
    }

    private Func<string, ((int, int), (int, int))?>[] _searches = new Func<string, ((int, int), (int, int))?>[] {
        FindInRow,
        FindInCol,
        FindInDiagTopLeftToBotRight,
        FindInDiagBotLeftToTopRight
    };

    private ((int, int), (int, int))? FindWord(string word) {
        ((int, int), (int, int))? res = null;
        foreach (var function in _searches) {
            res = function(word);
            if (res != null) return res;
        }
        return res;
    }

    public Dictionary<string, ((int, int), (int, int))?> Search(string[] wordsToSearchFor)
    {
        var res = new Dictionary<string, ((int, int), (int, int))?>();
        foreach (string word in wordsToSearchFor) {
            res.Add(word, FindWord(word));
        }
        return res;
    }
}