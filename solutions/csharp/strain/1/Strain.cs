public static class Strain
{
    public static IEnumerable<T> Keep<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        List<T> kept = new List<T>();

        foreach (T element in collection) if (predicate(element)) kept.Add(element);

        return kept;
    }

    public static IEnumerable<T> Discard<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        List<T> discarded = new List<T>();

        foreach (T element in collection) if (!predicate(element)) discarded.Add(element);

        return discarded;
    }
}