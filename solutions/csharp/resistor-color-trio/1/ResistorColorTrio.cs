public static class ResistorColorTrio
{
    public static long GetNum(string color) => color switch {
        "black" => 0,
        "brown" => 1,
        "red" => 2,
        "orange" => 3,
        "yellow" => 4,
        "green" => 5,
        "blue" => 6,
        "violet" => 7,
        "grey" => 8,
        "white" => 9,
        _ => 0,
    };
    
    public static string Label(string[] colors)
    {
        string label = "ohms";

        long val = GetNum(colors[0]) * 10 + GetNum(colors[1]);
        long zeroes = GetNum(colors[2]);
        while (zeroes > 0) {
            val *= 10;
            zeroes--;
        }
        
        switch (val) {
            case (>= 1_000_000_000):
                label = $" giga{label}";
                val /= 1_000_000_000;
                break;
            case (>= 1_000_000):
                label = $" mega{label}";
                val /= 1_000_000;
                break;
            case (>= 1_000):
                label = $" kilo{label}";
                val /= 1_000;
                break;
            default:
                label = $" {label}";
                break;
        }


        label = $"{val.ToString()}{label}";
        
        return label;
    }
}
