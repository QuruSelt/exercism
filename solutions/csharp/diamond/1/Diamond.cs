using System.Text;

public static class Diamond
{
    private static int TargetSpace(char c) => (int) (c-'A') * 2; 
    public static string Make(char target)
    {
        if (target < 'A' || target > 'Z') throw new ArgumentException();
        if (target == 'A') return "A";
        
        int targetSpace = TargetSpace(target);
        string EmptyLine = new string(' ', targetSpace + 1);

        StringBuilder diamond = new StringBuilder(EmptyLine);
        diamond[0] = target;
        diamond[targetSpace] = target;
        diamond.Append('\n');

        char letter = (char) (target - 1);
        int pos = 1;
        while (letter >= 'A') {
            StringBuilder line = new StringBuilder(EmptyLine);
            line[pos] = letter;
            line[targetSpace - pos] = letter;
            line.Append('\n');
            
            diamond.Insert(0, line.ToString());
            diamond.Append(line.ToString());
            pos++;
            letter--;
        }

        string txt = diamond.ToString();
        txt = txt.Remove(txt.Length - 1);
        return txt;
    }
}