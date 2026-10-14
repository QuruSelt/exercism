public static class ResistorColorDuo
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
    
    public static int Value(string[] colors) =>  10 * ColorCode(colors[0]) +  ColorCode(colors[1]);
}
