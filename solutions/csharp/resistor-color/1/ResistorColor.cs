public static class ResistorColor
{
    private static Dictionary<string, int> _colorMap = new Dictionary<string, int> {
        {"black", 0},
        {"brown", 1},
        {"red", 2},
        {"orange", 3},
        {"yellow", 4},
        {"green", 5},
        {"blue", 6},
        {"violet", 7},
        {"grey", 8},
        {"white", 9}
    };
    
    public static int ColorCode(string color) => _colorMap[color];

    public static string[] Colors() => new string[] {"black", "brown", "red", "orange", "yellow", "green", "blue", "violet", "grey", "white"};
}