using System.Collections.Generic;

public static class BottleSong
{
    private static string[] _numbers = {
        "no",
        "one",
        "two",
        "three",
        "four",
        "five",
        "six",
        "seven",
        "eight",
        "nine",
        "ten"
    };
    
    public static string GetNumber(int n, bool isLeading = true) => isLeading ? _numbers[n][0].ToString().ToUpper() + _numbers[n].Substring(1) : _numbers[n];
    
    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        List<string> song = new List<string>();
        
        for (int i = takeDown; i > 0; i--) {
            song.Add($"");
            song.Add($"{GetNumber(startBottles)} green bottle{(startBottles!=1 ? "s" : "")} hanging on the wall,");
            song.Add($"{GetNumber(startBottles)} green bottle{(startBottles!=1 ? "s" : "")} hanging on the wall,");
            song.Add($"And if one green bottle should accidentally fall,");
            song.Add($"There'll be {GetNumber(startBottles-1, false)} green bottle{(startBottles!=2 ? "s" : "")} hanging on the wall.");
            startBottles--;
        }

        song.RemoveAt(0);
        return song;
    }
}
