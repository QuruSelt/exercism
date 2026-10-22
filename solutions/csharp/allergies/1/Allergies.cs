public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16, 
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private HashSet<Allergen> _allergies;
    public Allergies(int mask)
    {
        _allergies = new HashSet<Allergen>();
        int i = 1;
        while (i <= 128) {
            if ((mask & i) != 0) _allergies.Add((Allergen) i);
            i <<= 1;
        }
    }

    public bool IsAllergicTo(Allergen allergen) => _allergies.Contains(allergen);

    public Allergen[] List() => _allergies.ToArray();
}