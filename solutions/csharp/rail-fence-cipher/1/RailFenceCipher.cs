public class RailFenceCipher
{
    private int _rails;

    public RailFenceCipher(int rails) {
        _rails = rails;
    }

    public string Encode(string input)
    {
        string encoded = "";
        int[] spaces = {2 * (_rails - 1), 0};

        for (int r = 0; r < _rails; r++) {
            string row = "";
            int i = r;
            int c = 0;

            while (i < input.Length) {
                row = $"{row}{input[i]}";
                i += spaces[c % 2] == 0 ? spaces[(c+1) % 2] : spaces[c % 2];
                c++;
            }
            
            spaces[0] -= 2;
            spaces[1] += 2;
            encoded = $"{encoded}{row}";
        }

        return encoded;
    }

    public string Decode(string input)
    {
        char[] decoded = new char[input.Length];
        int[] spaces = {2 * (_rails - 1), 0};

        int k = 0;
        for (int r = 0; r < _rails; r++) {
            int i = r;
            int c = 0;

            while (i < input.Length) {
                decoded[i] = input[k];
                i += spaces[c % 2] == 0 ? spaces[(c+1) % 2] : spaces[c % 2];
                c++;
                k++;
            }
            
            spaces[0] -= 2;
            spaces[1] += 2;
        }

        return new String(decoded);
    }
}