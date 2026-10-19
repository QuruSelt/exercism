using System.Collections;

public static class FlattenArray
{
    public static IEnumerable Flatten(IEnumerable input)
    {
        List<object> flat = new List<object>();
        
        foreach (var element in input) {
            if (element == null) continue;
            else if (element is IEnumerable) {
                IEnumerable sub = Flatten((IEnumerable) element);
                foreach (var e in sub) flat.Add(e);
            }
            else flat.Add(element);
        }

        return flat;
    }
}