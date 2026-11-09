public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (numbers.Length < sliceLength || sliceLength <= 0) throw new ArgumentException();

        var series = new List<string>();
        
        for (int i = 0; i <= numbers.Length - sliceLength; i++) {
            series.Add(numbers.Substring(i, sliceLength));
        }

        return series.ToArray();
    }
}